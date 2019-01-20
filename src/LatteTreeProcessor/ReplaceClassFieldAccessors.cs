using System.Collections.Generic;
using System.Linq;
using Common;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.CodeGenerators;
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

    internal class StatementVisitor : StatementVisitor<IStatement>
    {
        private readonly IClassDefinitionNode @class;
        private readonly IVariableEnvironment variables;
        private readonly ExpressionVisitor expressionVisitor;

        public StatementVisitor(IClassDefinitionNode @class, IVariableEnvironment variables)
        {
            this.@class = @class;
            this.variables = variables;
            expressionVisitor = new ExpressionVisitor(@class, variables);
        }

        public override IStatement Visit(IEmptyNode node)
        {
            return node;
        }

        public override IStatement Visit(IBlockNode node)
        {
            var visitor = new StatementVisitor(@class, variables.CopyForBlock());
            return new BlockNode(node.FilePlace, node.Statements.Select(visitor.Visit).ToList());
        }

        public override IStatement Visit(IDeclarationNode node)
        {
            var declarations = new List<ISingleDeclaration>();

            foreach (var decl in node.Declarations)
            {
                declarations.Add(new SingleDeclaration(decl.Name, decl.Value == null ? null : expressionVisitor.Visit(decl.Value)));
                variables.Define(new VariableDefinition(decl.Name, node.Type));
            }
            
            return new DeclarationNode(node.FilePlace, node.Type, declarations);
        }

        public override IStatement Visit(IAssignmentNode node)
        {
            if (variables.IsDefined(node.Variable))
                return new AssignmentNode(node.FilePlace, node.Variable, expressionVisitor.Visit(node.Value));

            return new StructAssignmentNode(node.FilePlace, new VariableNode("this", node.FilePlace), node.Variable, expressionVisitor.Visit(node.Value));
        }

        public override IStatement Visit(IIncrementNode node)
        {
            return node; // @TODO
        }

        public override IStatement Visit(IDecrementNode node)
        {
            return node; // @TODO
        }

        public override IStatement Visit(IReturnNode node)
        {
            return new ReturnNode(node.FilePlace, expressionVisitor.Visit(node.ReturnExpression));
        }

        public override IStatement Visit(IVoidReturnNode node)
        {
            return node;
        }

        public override IStatement Visit(IIfNode node)
        {
            return new IfNode(node.FilePlace, expressionVisitor.Visit(node.Condition), Visit(node.Statement));
        }

        public override IStatement Visit(IIfElseNode node)
        {
            return new IfElseNode(node.FilePlace, expressionVisitor.Visit(node.Condition), Visit(node.Statement), Visit(node.ElseStatement));
        }

        public override IStatement Visit(IWhileNode node)
        {
            return new WhileNode(node.FilePlace, expressionVisitor.Visit(node.Condition), Visit(node.Statement));
        }

        public override IStatement Visit(IExpressionStatementNode node)
        {
            return new ExpressionStatementNode(node.FilePlace, expressionVisitor.Visit(node.Expression));
        }

        public override IStatement Visit(IStructAssignmentNode node)
        {
            return new StructAssignmentNode(node.FilePlace, expressionVisitor.Visit(node.Object), node.FieldName, expressionVisitor.Visit(node.Value));
        }

        public override IStatement Visit(IStructAssignmentWithOffsetNode node)
        {
            return new StructAssignmentWithOffsetNode(node.FilePlace, expressionVisitor.Visit(node.Object), node.FieldName, expressionVisitor.Visit(node.Value), node.FieldOffset);
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
            return node;
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
            return node;
        }

        public override IExpressionNode Visit(IMethodCallNode node)
        {
            return new MethodCallNode(node.FilePlace, Visit(node.Object), node.MethodName, node.Arguments.Select(Visit), node.ObjectType);
        }
    }
    
}