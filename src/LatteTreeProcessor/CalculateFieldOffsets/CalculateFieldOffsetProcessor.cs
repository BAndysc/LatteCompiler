using System.Collections.Generic;
using System.Linq;
using Common;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Transformers;
using LatteBase.Visitors;

namespace LatteTreeProcessor.CalculateFieldOffsets
{
    internal interface IFunction
    {
        string Name { get; }
        ILatteType ReturnType { get; } 
    }

    internal class Function : IFunction
    {
        public Function(string name, ILatteType returnType)
        {
            Name = name;
            ReturnType = returnType;
        }

        public string Name { get; }
        public ILatteType ReturnType { get; }
    }
    
    internal interface IFunctionsEnvironment
    {
        IFunction GetFunction(string name);
    }

    internal class FunctionsEnvironment : IFunctionsEnvironment
    {
        private Dictionary<string, IFunction> functions = new Dictionary<string, IFunction>();
        
        public IFunction GetFunction(string name)
        {
            return functions[name];
        }

        public void DefineFunction(IFunction function)
        {
            functions.Add(function.Name, function);
        }
    }
    
    internal interface IClassEnvironment
    {
        IClassDefinition GetClass(string name);
    }

    internal class ClassEnvironment : IClassEnvironment
    {
        private Dictionary<string, IClassDefinition> classes = new Dictionary<string, IClassDefinition>();
        
        public IClassDefinition GetClass(string name)
        {
            return classes[name];
        }

        public void Define(IClassDefinition @class)
        {
            classes.Add(@class.ClassName, @class);
        }
    }
    
    
    internal interface IClassDefinition
    {
        string ClassName { get; }
        IClassDefinition SuperClass { get; }
        int Size { get; }
        int GetFieldOffset(string fieldName);
        ILatteType GetFieldType(string fieldName);
        IFunction GetMethod(string methodName);
        int GetMethodOffset(string methodName);
        bool HasMethod(string methodName);
        IEnumerable<string> GetAllMethods();
    }

    internal interface IClassField
    {
        string FieldName { get; }
        ILatteType FieldType { get; }
    }

    internal class ClassField : IClassField
    {
        public ClassField(string fieldName, ILatteType fieldType)
        {
            FieldName = fieldName;
            FieldType = fieldType;
        }

        public string FieldName { get; }
        public ILatteType FieldType { get; }
    }
    
    internal class ClassDefinition : IClassDefinition
    {
        public ClassDefinition(string className, IClassDefinition superClass, IEnumerable<IClassField> fields, IEnumerable<IFunction> methods)
        {
            ClassName = className;
            SuperClass = superClass;
            int offset = superClass?.Size ?? 0;
            foreach (var field in fields)
            {
                fieldToOffset.Add(field.FieldName, offset);
                fieldToType.Add(field.FieldName, field.FieldType);
                offset += 4; // @todo: based on type
            }

            int methodOffset = 0;
            foreach (var method in methods)
            {
                this.methods.Add(method.Name, method);
                if (!(superClass?.HasMethod(method.Name) ?? false))
                {
                    methodToOffset[method.Name] = methodOffset;
                    methodOffset += 4;
                }
            }

            Size = offset;
        }

        public int GetMethodOffset(string methodName)
        {
            if (SuperClass != null && SuperClass.HasMethod(methodName))
                return SuperClass.GetMethodOffset(methodName);

            int offset = methodToOffset[methodName];
            
            return (SuperClass?.GetAllMethods().Count() * 4 ?? 0) + offset;
        }

        public bool HasMethod(string methodName)
        {
            return methods.ContainsKey(methodName) || (SuperClass != null && SuperClass.HasMethod(methodName));
        }

        public IEnumerable<string> GetAllMethods()
        {
            return methods.Keys.Union(SuperClass == null ? new string[] { } : SuperClass.GetAllMethods())
                .Distinct();
        }

        private Dictionary<string, int> fieldToOffset = new Dictionary<string, int>();
        private Dictionary<string, ILatteType> fieldToType = new Dictionary<string, ILatteType>();
        private Dictionary<string, IFunction> methods = new Dictionary<string, IFunction>(); 
        private Dictionary<string, int> methodToOffset = new Dictionary<string, int>(); 
        
        public string ClassName { get; }
        public IClassDefinition SuperClass { get; }
        public int Size { get; }
        public int GetFieldOffset(string fieldName)
        {
            if (!fieldToOffset.ContainsKey(fieldName))
                return SuperClass.GetFieldOffset(fieldName);
            return fieldToOffset[fieldName];
        }

        public ILatteType GetFieldType(string fieldName)
        {
            if (!fieldToType.ContainsKey(fieldName))
                return SuperClass.GetFieldType(fieldName);
            return fieldToType[fieldName];
        }

        public IFunction GetMethod(string methodName)
        {
            if (methods.ContainsKey(methodName))
                return methods[methodName];
            
            return SuperClass?.GetMethod(methodName);
        }
    }
    
    public class CalculateFieldOffsetProcessor : ProgramVisitor<IProgram>
    {
        public override IProgram Visit(IProgram program)
        {
            ClassEnvironment classes = new ClassEnvironment();
            FunctionsEnvironment functions = new FunctionsEnvironment();
            foreach (var @class in program.Classes)
            {
                IClassDefinition superClass = null;
                if (@class.SuperClass != null)
                    superClass = classes.GetClass(@class.SuperClass);

                var fields = @class.Fields.Select(t => new ClassField(t.FiledName, t.FieldType));
                var methods = @class.Methods.Select(t => new Function(t.Name, t.ReturnType));
                
                var cls = new ClassDefinition(@class.ClassName, superClass, fields, methods);
                classes.Define(cls);
            }

            foreach (var function in program.Functions)
                functions.DefineFunction(new Function(function.Name, function.ReturnType));
            
            IList<IFunctionDefinitionNode> globalFunctions = new List<IFunctionDefinitionNode>();
            IList<IClassDefinitionNode> _classes = new List<IClassDefinitionNode>();
            
            foreach (var @class in program.Classes)
            {
                IList<IFunctionDefinitionNode> _methods = new List<IFunctionDefinitionNode>();
                foreach (var method in @class.Methods)
                {
                    var variables = new VariableEnvironment();
                    foreach (var arg in method.Arguments)
                        variables.Define(new VariableDefinition(arg.Name, arg.Type));
                    variables.Define(new VariableDefinition("this", new LatteType(@class.ClassName)));
                    
                    var transformed = 
                        new FieldOffsetStatementVisitor(classes, functions, variables).Visit(method.Body);
                    
                    _methods.Add(new FunctionDefinitionNode(method.FilePlace,
                        method.ReturnType,
                        method.Name,
                        method.Arguments,
                        transformed));
                }
                
                _classes.Add(new ClassDefinitionNode(@class.FilePlace,
                    @class.ClassName,
                    @class.SuperClass,
                    _methods,
                    @class.Fields.ToArray()));
            }
            
            foreach (var fun in program.Functions)
            {
                var variables = new VariableEnvironment();
                foreach (var arg in fun.Arguments)
                    variables.Define(new VariableDefinition(arg.Name, arg.Type));
                    
                var transformed = 
                    new FieldOffsetStatementVisitor(classes, functions, variables).Visit(fun.Body);
                    
                globalFunctions.Add(new FunctionDefinitionNode(fun.FilePlace,
                    fun.ReturnType,
                    fun.Name,
                    fun.Arguments,
                    transformed));
            }
            
            return new ProgramNode(globalFunctions, _classes);
        }
    }

    internal class FieldOffsetExpressionVisitor : ExpressionTransformer
    {
        private readonly IVariableEnvironment variables;
        private readonly IClassEnvironment classes;
        private readonly IFunctionsEnvironment functions;

        private readonly LatteTypeEvaluator typeEvaluator;
        
        public FieldOffsetExpressionVisitor(IVariableEnvironment variables, IClassEnvironment classes, IFunctionsEnvironment functions)
        {
            this.variables = variables;
            this.classes = classes;
            this.functions = functions;
            typeEvaluator = new LatteTypeEvaluator(variables, classes, functions);
        }
        
        public override IExpressionNode Visit(IObjectFieldNode node)
        {
            var objType = typeEvaluator.Visit(node.Object);

            if (objType.IsArray) // length
            {
                return base.Visit(new ObjectFieldWithOffsetNode(node.FilePlace, node.Object, node.FieldName, -4 /* hack - 4 is added later because of vtable */));
            }
            
            var @class = classes.GetClass(objType.Name);
            return base.Visit(new ObjectFieldWithOffsetNode(node.FilePlace, node.Object, node.FieldName, @class.GetFieldOffset(node.FieldName)));
        }

        public override IExpressionNode Visit(IMethodCallNode node)
        {
            var objType = typeEvaluator.Visit(node.Object);
            return base.Visit(new MethodCallWithOffsetNode(node.FilePlace, node.Object, node.MethodName, node.Arguments, objType, classes.GetClass(objType.Name).GetMethodOffset(node.MethodName)));
        }
    }

    internal class LatteTypeEvaluator : ExpressionVisitor<ILatteType>
    {
        private readonly IVariableEnvironment variables;
        private readonly IClassEnvironment classes;
        private readonly IFunctionsEnvironment functions;

        public LatteTypeEvaluator(IVariableEnvironment variables, IClassEnvironment classes, IFunctionsEnvironment functions)
        {
            this.variables = variables;
            this.classes = classes;
            this.functions = functions;
        }
        
        public override ILatteType Visit(IIntNode node)
        {
            return LatteType.Int;
        }

        public override ILatteType Visit(ITrueNode node)
        {
            return LatteType.Bool;
        }

        public override ILatteType Visit(IFalseNode node)
        {
            return LatteType.Bool;
        }

        public override ILatteType Visit(IStringNode node)
        {
            return LatteType.String;
        }

        public override ILatteType Visit(IVariableNode node)
        {
            return variables[node.Variable].Type;
        }

        public override ILatteType Visit(INegateNode node)
        {
            return Visit(node.Expression);
        }

        public override ILatteType Visit(ILogicalNegateNode node)
        {
            return Visit(node.Expression);
        }

        public override ILatteType Visit(IAndNode node)
        {
            return Visit(node.Left);
        }

        public override ILatteType Visit(IOrNode node)
        {
            return Visit(node.Left);
        }

        public override ILatteType Visit(IBinaryNode node)
        {
            return Visit(node.Left);
        }

        public override ILatteType Visit(ICompareNode node)
        {
            return LatteType.Bool;
        }

        public override ILatteType Visit(IFunctionCallNode node)
        {
            return functions.GetFunction(node.FunctionName).ReturnType;
        }

        public override ILatteType Visit(INullNode node)
        {
            return LatteType.Null;
        }

        public override ILatteType Visit(INewObjectNode node)
        {
            return new LatteType(node.TypeName);
        }

        public override ILatteType Visit(ICastExpressionNode node)
        {
            return node.CastType;
        }

        public override ILatteType Visit(IObjectFieldNode node)
        {
            var obType = Visit(node.Object);

            if (obType.IsArray) // length
                return LatteType.Int;
            
            var @class = classes.GetClass(obType.Name);

            return @class.GetFieldType(node.FieldName);
        }

        public override ILatteType Visit(IObjectFieldWithOffsetNode node)
        {
            return Visit((IObjectFieldNode) node);
        }

        public override ILatteType Visit(IMethodCallNode node)
        {
            var obType = Visit(node.Object);

            var @class = classes.GetClass(obType.Name);

            return @class.GetMethod(node.MethodName).ReturnType;
        }

        public override ILatteType Visit(IMethodCallWithOffsetNode node)
        {
            var obType = Visit(node.Object);

            var @class = classes.GetClass(obType.Name);

            return @class.GetMethod(node.MethodName).ReturnType;
        }

        public override ILatteType Visit(IArrayAccessNode node)
        {
            var array = Visit(node.Array);
            return array.BaseType;
        }

        public override ILatteType Visit(INewArrayNode node)
        {
            return new LatteType(node.ArrayType);
        }
    }
    
    internal class FieldOffsetStatementVisitor : StatementTransformer
    {
        private readonly IClassEnvironment classes;
        private readonly IFunctionsEnvironment functions;
        private readonly IVariableEnvironment variables;
        private readonly LatteTypeEvaluator typeEvaluator;

        public FieldOffsetStatementVisitor(IClassEnvironment classes, IFunctionsEnvironment functions,
            IVariableEnvironment variables)
        {
            this.classes = classes;
            this.functions = functions;
            this.variables = variables;
            typeEvaluator = new LatteTypeEvaluator(variables, classes, functions);
            ExpressionVisitor = new FieldOffsetExpressionVisitor(variables, classes, functions);
        }
        
        protected override StatementVisitor<IStatement> GetTransformerForBlock()
        {
            return new FieldOffsetStatementVisitor(classes, functions, variables.CopyForBlock());
        }

        protected override ExpressionVisitor<IExpressionNode> ExpressionVisitor { get; }


        public override IStatement Visit(IDeclarationNode node)
        {
            foreach (var decl in node.Declarations)
                variables.Define(new VariableDefinition(decl.Name, node.Type));
            return base.Visit(node);
        }

        public override IStatement Visit(IStructAssignmentNode node)
        {
            var objectType = typeEvaluator.Visit(node.Object);
            var @class = classes.GetClass(objectType.Name);
            var newNode = new StructAssignmentWithOffsetNode(node.FilePlace, node.Object, node.FieldName, node.Value, @class.GetFieldOffset(node.FieldName));
            return base.Visit(newNode);
        }

        public override IStatement Visit(IStructIncrementNode node)
        {
            var objectType = typeEvaluator.Visit(node.Object);
            var @class = classes.GetClass(objectType.Name);
            var newNode = new StructIncrementWithOffsetNode(node.FilePlace, node.Object, node.FieldName, @class.GetFieldOffset(node.FieldName));
            return base.Visit(newNode);
        }

        public override IStatement Visit(IStructDecrementNode node)
        {
            var objectType = typeEvaluator.Visit(node.Object);
            var @class = classes.GetClass(objectType.Name);
            var newNode = new StructDecrementWithOffsetNode(node.FilePlace, node.Object, node.FieldName, @class.GetFieldOffset(node.FieldName));
            return base.Visit(newNode);
        }
    }
    
    
}