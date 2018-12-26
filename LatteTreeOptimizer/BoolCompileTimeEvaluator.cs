using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    internal class BoolCompileTimeEvaluator : ExpressionVisitor<bool?>
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
            return null;
        }

        public override bool? Visit(IFunctionCallNode node)
        {
            return null;
        }
    }
}