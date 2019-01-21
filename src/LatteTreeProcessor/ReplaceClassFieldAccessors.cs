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

    internal class ExpressionVisitor : ExpressionTransformer
    {
        private readonly IClassDefinitionNode @class;
        private readonly IVariableEnvironment variables;

        public ExpressionVisitor(IClassDefinitionNode @class, IVariableEnvironment variables)
        {
            this.@class = @class;
            this.variables = variables;
        }

        public override IExpressionNode Visit(IVariableNode node)
        {
            if (variables.IsDefined(node.Variable))
                return node;
            return new ObjectFieldNode(node.FilePlace, new VariableNode("this", node.FilePlace), node.Variable);
        }
    }
    
}