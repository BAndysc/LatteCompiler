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
        private readonly LatteType expectedReturnType;

        private readonly LatteExpressionTypeEvaluator expressionEvaluator;
        
        public StatementTypeChecker(IVariableEnvironment variables, IEnvironment functions,
            LatteType expectedReturnType)
        {
            this.variables = variables;
            this.functions = functions;
            this.expectedReturnType = expectedReturnType;
            expressionEvaluator = new LatteExpressionTypeEvaluator(variables, functions);
        }

        public override object Visit(IEmptyNode node)
        {
            return null;
        }

        private StatementTypeChecker GetBlockTypeChecker()
        {
            return new StatementTypeChecker(variables.CopyForBlock(), functions, expectedReturnType);
        }
        
        public override object Visit(IBlockNode node)
        {
            var blockChecker = GetBlockTypeChecker();

            node.Statements.Select(blockChecker.Visit).ToList();

            return null;
        }

        public override object Visit(IDeclarationNode node)
        {
            var declarationType = node.Type;

            if (declarationType == LatteType.Void)
                throw new InvalidVariableTypeException(declarationType, node.FilePlace);
            
            foreach (var item in node.Declarations)
            {
                var variableDefinition = new VariableDefinition(item.Name, declarationType);

                if (!variables.CanRedefine(variableDefinition))
                {
                    throw new VariableRedefinitionException(variables[variableDefinition.Name], variableDefinition, node.FilePlace);
                }

                if (item.Value != null)
                {
                    var itemValueType = expressionEvaluator.Visit(item.Value);
                    
                    if (itemValueType != declarationType)
                        throw new VariableDeclarationTypeMismatch(variableDefinition, itemValueType, node.FilePlace);
                }
                
                variables.Define(variableDefinition);
            }
            
            return null;
        }

        public override object Visit(IAssignmentNode node)
        {
            var type = expressionEvaluator.Visit(node.Value);
            
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
            var givenReturnType = expressionEvaluator.Visit(node.ReturnExpression);
            
            if (expectedReturnType != givenReturnType)
                throw new InvalidReturnTypeException(expectedReturnType, givenReturnType, node.FilePlace);

            return null;
        }

        public override object Visit(IVoidReturnNode node)
        {
            if (expectedReturnType != LatteType.Void)
                throw new InvalidReturnTypeException(expectedReturnType, LatteType.Void, node.FilePlace);

            return null;
        }

        public override object Visit(IIfNode node)
        {
            var conditionType = expressionEvaluator.Visit(node.Condition);

            if (conditionType != LatteType.Bool)
                throw new InvalidConditionTypeException(LatteType.Bool, conditionType, node.FilePlace);
            
            GetBlockTypeChecker().Visit(node.Statement);

            return null;
        }

        public override object Visit(IIfElseNode node)
        {
            var conditionType = expressionEvaluator.Visit(node.Condition);

            if (conditionType != LatteType.Bool)
                throw new InvalidConditionTypeException(LatteType.Bool, conditionType, node.FilePlace);
            
            GetBlockTypeChecker().Visit(node.Statement);
            GetBlockTypeChecker().Visit(node.ElseStatement);

            return null;
        }

        public override object Visit(IWhileNode node)
        {
            var conditionType = expressionEvaluator.Visit(node.Condition);

            if (conditionType != LatteType.Bool)
                throw new InvalidConditionTypeException(LatteType.Bool, conditionType, node.FilePlace);
            
            GetBlockTypeChecker().Visit(node.Statement);

            return null;
        }

        public override object Visit(IExpressionStatementNode nodeNode)
        {
            expressionEvaluator.Visit(nodeNode.Expression);
            return null;
        }
    }
}