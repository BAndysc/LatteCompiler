using System;
using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    public class BoolCompileTimeEvaluator : ExpressionVisitor<bool?>
    {
        public override bool? Visit(IIntNode node)
        {
            return null;
        }

        public override bool? Visit(ITrueNode node)
        {
            return true;
        }

        public override bool? Visit(IFalseNode node)
        {
            return false;
        }

        public override bool? Visit(IStringNode node)
        {
            return null;
        }

        public override bool? Visit(IVariableNode node)
        {
            return null;   
        }

        public override bool? Visit(INegateNode node)
        {
            return null;
        }

        public override bool? Visit(ILogicalNegateNode node)
        {
            var compileValue = Visit(node.Expression);

            if (!compileValue.HasValue)
                return null;

            return !compileValue.Value;
        }

        public override bool? Visit(IAndNode node)
        {
            var compileValueLeft = Visit(node.Left);

            if (!compileValueLeft.HasValue)
                return null;

            if (compileValueLeft.Value == false)
                return false;

            var compileValueRight = Visit(node.Right);

            if (!compileValueRight.HasValue)
                return null;
            
            return compileValueRight.Value == true;
        }

        public override bool? Visit(IOrNode node)
        {
            var compileValueLeft = Visit(node.Left);

            if (!compileValueLeft.HasValue)
                return null;

            if (compileValueLeft.Value == true)
                return true;

            var compileValueRight = Visit(node.Right);

            if (!compileValueRight.HasValue)
                return null;
            
            return compileValueRight.Value == true;
        }

        public override bool? Visit(IBinaryNode node)
        {
            return null;
        }

        public override bool? Visit(ICompareNode node)
        {
            var boolLeft = Visit(node.Left);
            var boolRight = Visit(node.Right);

            var intLeft = new IntCompileTimeEvaluator().Visit(node.Left);
            var intRight = new IntCompileTimeEvaluator().Visit(node.Right);

            if (boolLeft.HasValue && boolRight.HasValue)
            {
                if (node.Operator == RelOperator.Equals)
                    return boolLeft.Value == boolRight.Value;
                else if (node.Operator == RelOperator.NotEquals)
                    return boolLeft.Value != boolRight.Value;
            }

            if (intLeft.HasValue && intRight.HasValue)
            {
                switch (node.Operator)
                {
                    case RelOperator.LessThan:
                        return intLeft.Value < intRight.Value;
                    case RelOperator.LessEquals:
                        return intLeft.Value <= intRight.Value;
                    case RelOperator.GreaterThan:
                        return intLeft.Value > intRight.Value;
                    case RelOperator.GreaterEquals:
                        return intLeft.Value >= intRight.Value;
                    case RelOperator.Equals:
                        return intLeft.Value == intRight.Value;
                    case RelOperator.NotEquals:
                        return intLeft.Value != intRight.Value;
                }
            }

            return null;
        }

        public override bool? Visit(IFunctionCallNode node)
        {
            return null;
        }

        public override bool? Visit(INullNode node)
        {
            return null;
        }

        public override bool? Visit(INewObjectNode node)
        {
            return null;
        }

        public override bool? Visit(ICastExpressionNode node)
        {
            return Visit(node.Expression);
        }

        public override bool? Visit(IObjectFieldNode node)
        {
            return null;
        }

        public override bool? Visit(IObjectFieldWithOffsetNode node)
        {
            return null;
        }

        public override bool? Visit(IMethodCallNode node)
        {
            return null;
        }

        public override bool? Visit(IMethodCallWithOffsetNode node)
        {
            return null;
        }

        public override bool? Visit(IArrayAccessNode node)
        {
            return null;
        }

        public override bool? Visit(INewArrayNode node)
        {
            return null;
        }

        public override bool? Visit(IStringCompareNode node)
        {
            return null;
        }
    }
}