using System.Collections.Generic;
using System.Linq;
using Common;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.CodeGenerators;
using LatteBase.Transformers;
using LatteBase.Visitors;

namespace LatteTreeProcessor
{
    public class ReplaceClassFieldAccessors : ProgramVisitor<IProgram>
    {
        public override IProgram Visit(IProgram program)
        {
            var classes = new List<IClassDefinitionNode>();
            
            foreach (var @class in program.Classes)
            {
                var methodVisitor = new MethodVisitor(@class);

                var methods = new List<IFunctionDefinitionNode>();
                foreach (var method in @class.Methods)
                {
                    methods.Add(methodVisitor.Visit(method));
                }
                classes.Add(new ClassDefinitionNode(@class.FilePlace, @class.ClassName, @class.SuperClass,
                    methods, @class.Fields.ToArray()));
            }

            var newProg = new ProgramNode(program.Functions, classes);

            var gen = new ProgramCodeGenerator().Visit(newProg);
            
            return newProg;
        }
    }

    internal class MethodVisitor : FunctionDefinitionVisitor<IFunctionDefinitionNode>
    {
        private readonly IClassDefinitionNode @class;

        public MethodVisitor(IClassDefinitionNode @class)
        {
            this.@class = @class;
        }
        
        public override IFunctionDefinitionNode Visit(IFunctionDefinitionNode function)
        {
            IVariableEnvironment variables = new VariableEnvironment();
            
            variables.Define(new VariableDefinition("this", new LatteType(@class.ClassName)));
            
            foreach (var argument in function.Arguments)
                variables.Define(new VariableDefinition(argument.Name, argument.Type));

            var statementVisitor = new StatementVisitor(@class, variables);
            var statements = statementVisitor.Visit(function.Body);
            
            return new FunctionDefinitionNode(
                function.FilePlace,
                function.ReturnType,
                function.Name,
                statements,
                function.Arguments.ToArray());
        }
    }

    internal class StatementVisitor : StatementTransformer
    {
        private readonly IClassDefinitionNode @class;
        private readonly IVariableEnvironment variables;
        protected override ExpressionVisitor<IExpressionNode> ExpressionVisitor { get; }
        
        public StatementVisitor(IClassDefinitionNode @class, IVariableEnvironment variables)
        {
            this.@class = @class;
            this.variables = variables;
            ExpressionVisitor = new ExpressionVisitor(@class, variables);
        }

        protected override StatementVisitor<IStatement> GetTransformerForBlock()
        {
            return new StatementVisitor(@class, variables.CopyForBlock());
        }

        public override IStatement Visit(IDeclarationNode node)
        {
            foreach (var decl in node.Declarations)
                variables.Define(new VariableDefinition(decl.Name, node.Type));

            return base.Visit(node);
        }

        public override IStatement Visit(IAssignmentNode node)
        {
            if (variables.IsDefined(node.Variable))
                return base.Visit(node);

            return new StructAssignmentNode(node.FilePlace, new VariableNode("this", node.FilePlace), node.Variable, ExpressionVisitor.Visit(node.Value));
        }

        public override IStatement Visit(IIncrementNode node)
        {
            if (variables.IsDefined(node.Variable))
                return base.Visit(node);
            
            return new StructIncrementNode(node.FilePlace, new VariableNode("this", node.FilePlace), node.Variable);
        }

        public override IStatement Visit(IDecrementNode node)
        {
            if (variables.IsDefined(node.Variable))
                return base.Visit(node);
            
            return new StructDecrementNode(node.FilePlace, new VariableNode("this", node.FilePlace), node.Variable);
        }
        
        
    }

    internal class ExpressionVisitor : ExpressionVisitor<IExpressionNode>
    {
        private readonly IClassDefinitionNode @class;
        private readonly IVariableEnvironment variables;

        public ExpressionVisitor(IClassDefinitionNode @class, IVariableEnvironment variables)
        {
            this.@class = @class;
            this.variables = variables;
        }

        public override IExpressionNode Visit(IIntNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(ITrueNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IFalseNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IStringNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IVariableNode node)
        {
            if (variables.IsDefined(node.Variable))
                return node;
            return new ObjectFieldNode(node.FilePlace, new VariableNode("this", node.FilePlace), node.Variable);
        }

        public override IExpressionNode Visit(IObjectFieldWithOffsetNode node)
        {  
            return new ObjectFieldWithOffsetNode(node.FilePlace, Visit(node.Object), node.FieldName, node.FieldOffset);
        }
        
        public override IExpressionNode Visit(INegateNode node)
        {
            return new NegateNode(Visit(node.Expression), node.FilePlace);
        }

        public override IExpressionNode Visit(ILogicalNegateNode node)
        {
            return new LogicalNegateNode(Visit(node.Expression), node.FilePlace);
        }

        public override IExpressionNode Visit(IAndNode node)
        {
            return new AndNode(Visit(node.Left), Visit(node.Right), node.FilePlace);
        }

        public override IExpressionNode Visit(IOrNode node)
        {
            return new OrNode(Visit(node.Left), Visit(node.Right), node.FilePlace);
        }

        public override IExpressionNode Visit(IBinaryNode node)
        {
            return new BinaryNode(node.Operator, Visit(node.Left), Visit(node.Right), node.FilePlace);
        }

        public override IExpressionNode Visit(ICompareNode node)
        {
            return new CompareNode(node.Operator, Visit(node.Left), Visit(node.Right), node.FilePlace);
        }

        public override IExpressionNode Visit(IFunctionCallNode node)
        {
            return new FunctionCallNode(node.FunctionName, node.Arguments.Select(Visit).ToList(), node.FilePlace);
        }

        public override IExpressionNode Visit(INullNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(INewObjectNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(ICastExpressionNode node)
        {
            return new CastExpressionNode(node.FilePlace, node.CastType, Visit(node.Expression));
        }

        public override IExpressionNode Visit(IObjectFieldNode node)
        {
            return new ObjectFieldNode(node.FilePlace, Visit(node.Object), node.FieldName);
        }

        public override IExpressionNode Visit(IMethodCallNode node)
        {
            return new MethodCallNode(node.FilePlace, Visit(node.Object), node.MethodName, node.Arguments.Select(Visit));
        }

        public override IExpressionNode Visit(IMethodCallWithOffsetNode node)
        {
            return new MethodCallWithOffsetNode(node.FilePlace, Visit(node.Object), node.MethodName, node.Arguments.Select(Visit), node.ObjectType, node.MethodOffset);
        }
    }
    
}