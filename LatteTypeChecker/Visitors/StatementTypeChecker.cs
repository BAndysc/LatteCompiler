using System.Linq;
using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using LatteTypeChecker.Exceptions;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Visitors
{
    public class StatementTypeChecker : StatementVisitor<bool>
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

        public override bool Visit(IEmptyNode node)
        {
            return false;
        }

        private StatementTypeChecker GetBlockTypeChecker()
        {
            return new StatementTypeChecker(variables.CopyForBlock(), functions, expectedReturnType);
        }
        
        public override bool Visit(IBlockNode node)
        {
            var blockChecker = GetBlockTypeChecker();

            return node.Statements.Select(blockChecker.Visit).Aggregate(false, (aggregate, value) => aggregate | value);
        }

        public override bool Visit(IDeclarationNode node)
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
            
            return false;
        }

        public override bool Visit(IAssignmentNode node)
        {
            var type = expressionEvaluator.Visit(node.Value);
            
            var variable = new VariableDefinition(node.Variable, type);
            
            if (!variables.IsDefined(variable))
                throw new UndeclaredVariableException(variable, node.FilePlace);

            if (variables[node.Variable].Type != type)
            {
                throw new TypeMismatchException(variables[node.Variable], variable, node.FilePlace);
            }
            
            return false;
        }

        public override bool Visit(IIncrementNode node)
        {
            var variable = new VariableDefinition(node.Variable, LatteType.Int);
            
            if (!variables.IsDefined(variable))
                throw new UndeclaredVariableException(variable, node.FilePlace);

            if (variables[node.Variable].Type != LatteType.Int)
                throw new TypeMismatchException(variables[node.Variable], variable, node.FilePlace);

            return false;
        }

        public override bool Visit(IDecrementNode node)
        {
            var variable = new VariableDefinition(node.Variable, LatteType.Int);
            
            if (!variables.IsDefined(variable))
                throw new UndeclaredVariableException(variable, node.FilePlace);

            if (variables[node.Variable].Type != LatteType.Int)
                throw new TypeMismatchException(variables[node.Variable], variable, node.FilePlace);

            return false;
        }

        public override bool Visit(IReturnNode node)
        {
            var givenReturnType = expressionEvaluator.Visit(node.ReturnExpression);
            
            if (expectedReturnType != givenReturnType)
                throw new InvalidReturnTypeException(expectedReturnType, givenReturnType, node.FilePlace);

            return true;
        }

        public override bool Visit(IVoidReturnNode node)
        {
            if (expectedReturnType != LatteType.Void)
                throw new InvalidReturnTypeException(expectedReturnType, LatteType.Void, node.FilePlace);

            return true;
        }

        public override bool Visit(IIfNode node)
        {
            var conditionType = expressionEvaluator.Visit(node.Condition);

            if (conditionType != LatteType.Bool)
                throw new InvalidConditionTypeException(LatteType.Bool, conditionType, node.FilePlace);
            
            GetBlockTypeChecker().Visit(node.Statement);

            return false;
        }

        public override bool Visit(IIfElseNode node)
        {
            var conditionType = expressionEvaluator.Visit(node.Condition);

            if (conditionType != LatteType.Bool)
                throw new InvalidConditionTypeException(LatteType.Bool, conditionType, node.FilePlace);
            
            var returnInIf = GetBlockTypeChecker().Visit(node.Statement);
            var returnInElse = GetBlockTypeChecker().Visit(node.ElseStatement);

            return returnInIf && returnInElse;
        }

        public override bool Visit(IWhileNode node)
        {
            var conditionType = expressionEvaluator.Visit(node.Condition);

            if (conditionType != LatteType.Bool)
                throw new InvalidConditionTypeException(LatteType.Bool, conditionType, node.FilePlace);
            
            GetBlockTypeChecker().Visit(node.Statement);

            return false;
        }

        public override bool Visit(IExpressionStatementNode nodeNode)
        {
            expressionEvaluator.Visit(nodeNode.Expression);
            return false;
        }
    }
}