using System.Linq;
using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using LatteTypeChecker.Exceptions;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Visitors
{
    public class StatementTypeChecker : StatementVisitor<object>
    {
        private readonly IVariableEnvironment variables;
        private readonly IEnvironment functions;

        public StatementTypeChecker(IVariableEnvironment variables, IEnvironment functions)
        {
            this.variables = variables;
            this.functions = functions;
        }

        public override object Visit(IEmptyNode node)
        {
            return null;
        }

        public override object Visit(IBlockNode node)
        {
            var blockChecker = new StatementTypeChecker(variables.CopyForBlock(), functions);

            node.Statements.Select(blockChecker.Visit).ToList();

            return null;
        }

        public override object Visit(IDeclarationNode node)
        {
            var latteType = node.Type;

            foreach (var item in node.Declarations)
            {
                var variableDefinition = new VariableDefinition(item.Name, latteType);

                if (!variables.CanRedefine(variableDefinition))
                {
                    throw new VariableRedefinitionException(variables[variableDefinition.Name], variableDefinition, node.FilePlace);
                }
                
                variables.Define(variableDefinition);
            }
            
            return null;
        }

        public override object Visit(IAssignmentNode node)
        {
            var type = new LatteExpressionTypeEvaluator(variables, functions).Visit(node.Value);
            
            var variable = new VariableDefinition(node.Variable, type);
            
            if (!variables.IsDefined(variable))
                throw new UndeclaredVariableException(variable, node.FilePlace);

            if (variables[node.Variable].Type != type)
            {
                throw new TypeMismatchException(variables[node.Variable], variable, node.FilePlace);
            }
            
            return null;
        }

        public override object Visit(IIncrementNode node)
        {
            var variable = new VariableDefinition(node.Variable, LatteType.Int);
            
            if (!variables.IsDefined(variable))
                throw new UndeclaredVariableException(variable, node.FilePlace);

            if (variables[node.Variable].Type != LatteType.Int)
                throw new TypeMismatchException(variables[node.Variable], variable, node.FilePlace);

            return null;
        }

        public override object Visit(IDecrementNode node)
        {
            var variable = new VariableDefinition(node.Variable, LatteType.Int);
            
            if (!variables.IsDefined(variable))
                throw new UndeclaredVariableException(variable, node.FilePlace);

            if (variables[node.Variable].Type != LatteType.Int)
                throw new TypeMismatchException(variables[node.Variable], variable, node.FilePlace);

            return null;
        }

        public override object Visit(IReturnNode node)
        {
            throw new System.NotImplementedException();
        }

        public override object Visit(IVoidReturnNode node)
        {
            throw new System.NotImplementedException();
        }

        public override object Visit(IIfNode node)
        {
            throw new System.NotImplementedException();
        }

        public override object Visit(IIfElseNode node)
        {
            throw new System.NotImplementedException();
        }

        public override object Visit(IWhileNode node)
        {
            throw new System.NotImplementedException();
        }

        public override object Visit(IExpressionStatementNode nodeNode)
        {
            new LatteExpressionTypeEvaluator(variables, functions).Visit(nodeNode.Expression);
            return null;
        }
    }
}