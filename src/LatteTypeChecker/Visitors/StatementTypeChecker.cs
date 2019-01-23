using System.Linq;
using Common;
using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using LatteTypeChecker.Exceptions;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Visitors
{
    public class StatementTypeChecker : StatementVoidVisitor
    {
        private readonly IVariableEnvironment variables;
        private readonly IEnvironment functions;
        private readonly ILatteType expectedReturnType;

        private readonly LatteExpressionTypeEvaluator expressionEvaluator;
        
        public StatementTypeChecker(IVariableEnvironment variables, IEnvironment functions,
            ILatteType expectedReturnType)
        {
            this.variables = variables;
            this.functions = functions;
            this.expectedReturnType = expectedReturnType;
            expressionEvaluator = new LatteExpressionTypeEvaluator(variables, functions);
        }

        public override void Visit(IEmptyNode node)
        {
        }

        private StatementTypeChecker GetBlockTypeChecker()
        {
            return new StatementTypeChecker(variables.CopyForBlock(), functions, expectedReturnType);
        }
        
        public override void Visit(IBlockNode node)
        {
            var blockChecker = GetBlockTypeChecker();

            foreach (var stmt in node.Statements)
                blockChecker.Visit(stmt);
        }

        public override void Visit(IDeclarationNode node)
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
                    
                    if (!functions.IsTypeAssignable(itemValueType, declarationType))
                        throw new VariableDeclarationTypeMismatch(variableDefinition, itemValueType, node.FilePlace);
                }
                
                variables.Define(variableDefinition);
            }
        }

        public override void Visit(IAssignmentNode node)
        {
            var type = expressionEvaluator.Visit(node.Value);
            
            var variable = new VariableDefinition(node.Variable, type);
            
            if (!variables.IsDefined(variable))
                throw new UndeclaredVariableException(variable, node.FilePlace);

            if (!functions.IsTypeAssignable(type, variables[node.Variable].Type))
            {
                throw new VariableDeclarationTypeMismatch(variables[node.Variable], variable.Type, node.FilePlace);
            }
        }

        public override void Visit(IStructAssignmentNode node)
        {
            var classType = expressionEvaluator.Visit(node.Object);
            var valueType = expressionEvaluator.Visit(node.Value);

            var classDef = functions.GetClass(classType.Name);

            if (!classDef.HasField(node.FieldName))
                throw new UnknownFieldInClassException(node.FilePlace, classDef, node.FieldName);

            var fieldType = classDef.GetField(node.FieldName).FieldType;
            
            if (!functions.IsTypeAssignable(valueType, fieldType))
                throw new FieldTypeMismatchException(node.FilePlace, node.FieldName, fieldType, valueType);
        }
        
        public override void Visit(IStructAssignmentWithOffsetNode node)
        {
            var classType = expressionEvaluator.Visit(node.Object);
            var valueType = expressionEvaluator.Visit(node.Value);

            var classDef = functions.GetClass(classType.Name);

            if (!classDef.HasField(node.FieldName))
                throw new UnknownFieldInClassException(node.FilePlace, classDef, node.FieldName);

            var fieldType = classDef.GetField(node.FieldName).FieldType;
            
            if (!functions.IsTypeAssignable(valueType, fieldType))
                throw new FieldTypeMismatchException(node.FilePlace, node.FieldName, fieldType, valueType);
        }
        
        public override void Visit(IIncrementNode node)
        {
            var variable = new VariableDefinition(node.Variable, LatteType.Int);
            
            if (!variables.IsDefined(variable))
                throw new UndeclaredVariableException(variable, node.FilePlace);

            if (variables[node.Variable].Type != LatteType.Int)
                throw new TypeMismatchException(variables[node.Variable], variable, node.FilePlace);
        }

        public override void Visit(IDecrementNode node)
        {
            var variable = new VariableDefinition(node.Variable, LatteType.Int);
            
            if (!variables.IsDefined(variable))
                throw new UndeclaredVariableException(variable, node.FilePlace);

            if (variables[node.Variable].Type != LatteType.Int)
                throw new TypeMismatchException(variables[node.Variable], variable, node.FilePlace);
        }

        public override void Visit(IReturnNode node)
        {
            if (expectedReturnType == LatteType.Void)
                throw new InvalidReturnExpressionException(node.FilePlace);   
            
            var givenReturnType = expressionEvaluator.Visit(node.ReturnExpression);
            
            if (!functions.IsTypeAssignable(givenReturnType, expectedReturnType))
                throw new InvalidReturnTypeException(expectedReturnType, givenReturnType, node.FilePlace);
        }

        public override void Visit(IVoidReturnNode node)
        {
            if (expectedReturnType != LatteType.Void)
                throw new InvalidReturnTypeException(expectedReturnType, LatteType.Void, node.FilePlace);
        }

        public override void Visit(IIfNode node)
        {
            var conditionType = expressionEvaluator.Visit(node.Condition);

            if (conditionType != LatteType.Bool)
                throw new InvalidConditionTypeException(LatteType.Bool, conditionType, node.FilePlace);
            
            if (!new IsStatementBlockNode().Visit(node.Statement))
                throw new StatementMustBeBlockException(node.Statement.FilePlace);
            
            GetBlockTypeChecker().Visit(node.Statement);
        }

        public override void Visit(IIfElseNode node)
        {
            var conditionType = expressionEvaluator.Visit(node.Condition);

            if (conditionType != LatteType.Bool)
                throw new InvalidConditionTypeException(LatteType.Bool, conditionType, node.FilePlace);
            
            if (!new IsStatementBlockNode().Visit(node.Statement))
                throw new StatementMustBeBlockException(node.Statement.FilePlace);
            
            if (!new IsStatementBlockNode().Visit(node.ElseStatement))
                throw new StatementMustBeBlockException(node.ElseStatement.FilePlace);
            
            GetBlockTypeChecker().Visit(node.Statement);
            GetBlockTypeChecker().Visit(node.ElseStatement);
        }

        public override void Visit(IWhileNode node)
        {
            var conditionType = expressionEvaluator.Visit(node.Condition);

            if (conditionType != LatteType.Bool)
                throw new InvalidConditionTypeException(LatteType.Bool, conditionType, node.FilePlace);
            
            if (!new IsStatementBlockNode().Visit(node.Statement))
                throw new StatementMustBeBlockException(node.Statement.FilePlace);
            
            GetBlockTypeChecker().Visit(node.Statement);
        }

        public override void Visit(IExpressionStatementNode nodeNode)
        {
            expressionEvaluator.Visit(nodeNode.Expression);
        }

        public override void Visit(IStructIncrementNode node)
        {
            var classType = expressionEvaluator.Visit(node.Object);

            var classDef = functions.GetClass(classType.Name);

            if (!classDef.HasField(node.FieldName))
                throw new UnknownFieldInClassException(node.FilePlace, classDef, node.FieldName);

            var fieldType = classDef.GetField(node.FieldName).FieldType;
            
            if (!functions.IsTypeAssignable(LatteType.Int, fieldType))
                throw new FieldTypeMismatchException(node.FilePlace, node.FieldName, fieldType, LatteType.Int);
        }

        public override void Visit(IStructIncrementWithOffsetNode node)
        {
            Visit((IStructIncrementNode) node);
        }

        public override void Visit(IStructDecrementNode node)
        {
            var classType = expressionEvaluator.Visit(node.Object);

            var classDef = functions.GetClass(classType.Name);

            if (!classDef.HasField(node.FieldName))
                throw new UnknownFieldInClassException(node.FilePlace, classDef, node.FieldName);

            var fieldType = classDef.GetField(node.FieldName).FieldType;
            
            if (!functions.IsTypeAssignable(LatteType.Int, fieldType))
                throw new FieldTypeMismatchException(node.FilePlace, node.FieldName, fieldType, LatteType.Int);
        }

        public override void Visit(IStructDecrementWithOffsetNode node)
        {
            Visit((IStructDecrementNode) node);
        }

        public override void Visit(IArrayAssignmentNode node)
        {
            var arrayType = expressionEvaluator.Visit(node.Array);
            var indexType = expressionEvaluator.Visit(node.Index);
            var valueType = expressionEvaluator.Visit(node.Value);
            
            if (!arrayType.IsArray)
                throw new InplaceTypeCheckerException(node.FilePlace, $"Using not array in array context. Given {arrayType}!");
            
            if (indexType != LatteType.Int)
                throw new InplaceTypeCheckerException(node.FilePlace, "Array index is not an int!");

            if (!functions.IsTypeAssignable(valueType, arrayType.BaseType))
                throw new InplaceTypeCheckerException(node.FilePlace, $"Type {valueType} is not assignable to {arrayType.BaseType}");
        }

        public override void Visit(IForEachNode node)
        {
            var arrayType = expressionEvaluator.Visit(node.Array);
            
            if (!arrayType.IsArray)
                throw new InplaceTypeCheckerException(node.FilePlace, $"Type in foreach is not array! Given: {arrayType}");
            
            if (!functions.IsTypeAssignable(arrayType.BaseType, node.IteratorType))
                throw new InplaceTypeCheckerException(node.FilePlace, $"{arrayType.BaseType} is not assignable to {node.IteratorType}");

            var blockChecker = GetBlockTypeChecker();
            if (!blockChecker.variables.CanRedefine(new VariableDefinition(node.IteratorName, node.IteratorType)))
                throw new InplaceTypeCheckerException(node.FilePlace, $"Cannot redefine variable {node.IteratorName} in for-each");
            blockChecker.variables.Define(new VariableDefinition(node.IteratorName, node.IteratorType));
            blockChecker.Visit(node.Body);
        }
    }
}