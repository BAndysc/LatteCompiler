using System;
using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    public class IntCompileTimeEvaluator : ExpressionVisitor<int?>
    {
        public override int? Visit(IIntNode node)
        {
            return node.Value;
        }

        public override int? Visit(ITrueNode node)
        {
            return null;
        }

        public override int? Visit(IFalseNode node)
        {
            return null;
        }

        public override int? Visit(IStringNode node)
        {
            return null;
        }

        public override int? Visit(IVariableNode node)
        {
            return null;
        }

        public override int? Visit(INegateNode node)
        {
            var value = Visit(node.Expression);

            if (value.HasValue)
                return -value.Value;

            return null;
        }

        public override int? Visit(IAndNode node)
        {
            return null;
        }

        public override int? Visit(IOrNode node)
        {
            return null;
        }

        public override int? Visit(IBinaryNode node)
        {
            var leftValue = Visit(node.Left);
            var rightValue = Visit(node.Right);

            if (leftValue.HasValue && rightValue.HasValue)
            {
                switch (node.Operator)
                {
                    case BinaryOperator.Add:
                        return leftValue.Value + rightValue.Value;
                    case BinaryOperator.Sub:
                        return leftValue.Value - rightValue.Value;
                    case BinaryOperator.Mul:
                        return leftValue.Value * rightValue.Value;
                    case BinaryOperator.Div:
                        return leftValue.Value / rightValue.Value;
                    case BinaryOperator.Mod:
                        return leftValue.Value % rightValue.Value;
                }
            }

            return null;
        }

        public override int? Visit(ICompareNode node)
        {
            return null;
        }

        public override int? Visit(IFunctionCallNode node)
        {
            return null;
        }
    }
}