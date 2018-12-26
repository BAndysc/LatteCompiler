using System.Linq;
using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using LatteTypeChecker.Exceptions;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Visitors
{
    public class LatteExpressionTypeEvaluator : ExpressionVisitor<LatteType>
    {
        private readonly IVariableEnvironment variables;
        private readonly IEnvironment functions;

        public LatteExpressionTypeEvaluator(IVariableEnvironment variables, IEnvironment functions)
        {
            this.variables = variables;
            this.functions = functions;
        }

        public override LatteType Visit(IIntNode node)
        {
            return LatteType.Int;
        }

        public override LatteType Visit(ITrueNode node)
        {
            return LatteType.Bool;
        }

        public override LatteType Visit(IFalseNode node)
        {
            return LatteType.Bool;
        }

        public override LatteType Visit(IStringNode node)
        {
            return LatteType.String;
        }

        public override LatteType Visit(IVariableNode node)
        {
            if (!variables.IsDefined(node.Variable))
                throw new UndeclaredVariableAnyTypeException(node.Variable, node.FilePlace);
            
            return variables[node.Variable].Type;
        }

        public override LatteType Visit(INegateNode node)
        {
            var exprType = Visit(node.Expression);
            
            if (exprType != LatteType.Bool && exprType != LatteType.Int)
                throw new InvalidOperatorUsageException(exprType, node.FilePlace, LatteType.Bool, LatteType.Int);

            return exprType;
        }

        public override LatteType Visit(IAndNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (left != LatteType.Bool)
                throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Bool);

            if (right != LatteType.Bool)
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Bool);
            
            return LatteType.Bool;
        }

        public override LatteType Visit(IOrNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (left != LatteType.Bool)
                throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Bool);

            if (right != LatteType.Bool)
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Bool);
            
            return LatteType.Bool;
        }

        public override LatteType Visit(IBinaryNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            
            if (left != LatteType.Int && (left != LatteType.String || node.Operator != BinaryOperator.Add))
                throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Int, LatteType.String);

            if (right != LatteType.Int && (right != LatteType.String || node.Operator != BinaryOperator.Add))
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Int, LatteType.String);
            
            if (left != right)
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Int, LatteType.String);
            
            return left;
        }

        public override LatteType Visit(ICompareNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (node.Operator == RelOperator.Equals || node.Operator == RelOperator.NotEquals)
            {
                if (left != LatteType.Int && left != LatteType.Bool)
                    throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Int, LatteType.Bool);

                if (right != LatteType.Int && right != LatteType.Bool)
                    throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Int, LatteType.Bool);
            }
            else
            {
                if (left != LatteType.Int)
                    throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Int);

                if (right != LatteType.Int)
                    throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Int);    
            }
                        
            return LatteType.Bool;
        }

        public override LatteType Visit(IFunctionCallNode node)
        { 
            if (!functions.IsDefined(node.FunctionName))
                throw new UndeclaredFunctionException(node.FunctionName, node.FilePlace);
            
            var function = functions[node.FunctionName];

            if (function.ArgumentTypes.Count != node.Arguments.Count)
                throw new ArgumentsCountMismatchException(function, node.Arguments.Count, node.FilePlace);

            for (int i = 0; i < function.ArgumentTypes.Count; ++i)
            {
                var givenArgumentType = Visit(node.Arguments[i]);
                var expectedArgumentType = function.ArgumentTypes[i];

                if (givenArgumentType != expectedArgumentType)
                    throw new FunctionCallTypeMismatch(function, i, givenArgumentType, node.FilePlace);
            }
            
            return function.ReturnType;
        }
    }
}