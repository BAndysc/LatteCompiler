using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteTypeChecker.Visitors
{
    internal class IsExpressionExitCall : ExpressionVisitor<bool>
    {
        public override bool Visit(IIntNode node)
        {
            return false;
        }

        public override bool Visit(ITrueNode node)
        {
            return false;
        }

        public override bool Visit(IFalseNode node)
        {
            return false;
        }

        public override bool Visit(IStringNode node)
        {
            return false;
        }

        public override bool Visit(IVariableNode node)
        {
            return false;
        }

        public override bool Visit(INegateNode node)
        {
            return false;
        }

        public override bool Visit(ILogicalNegateNode node)
        {
            return false;
        }

        public override bool Visit(IAndNode node)
        {
            return false;
        }

        public override bool Visit(IOrNode node)
        {
            return false;
        }

        public override bool Visit(IBinaryNode node)
        {
            return false;
        }

        public override bool Visit(ICompareNode node)
        {
            return false;
        }

        public override bool Visit(IFunctionCallNode node)
        {
            return node.FunctionName == "error";
        }
    }
}