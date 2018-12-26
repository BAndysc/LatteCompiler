using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    internal class ExpressionOptimizer : ExpressionVisitor<IExpressionNode>
    {
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
            return node;
        }

        public override IExpressionNode Visit(INegateNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IAndNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IOrNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IBinaryNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(ICompareNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IFunctionCallNode node)
        {
            return node;
        }
    }
}