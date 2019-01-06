using LatteBase.AST;

namespace LatteBase.Visitors
{
    public abstract class ExpressionVisitor<T>
    {
        public abstract T Visit(IIntNode node);
        public abstract T Visit(ITrueNode node);
        public abstract T Visit(IFalseNode node);
        public abstract T Visit(IStringNode node);
        public abstract T Visit(IVariableNode node);
        public abstract T Visit(INegateNode node);
        public abstract T Visit(ILogicalNegateNode node);
        public abstract T Visit(IAndNode node);
        public abstract T Visit(IOrNode node);
        public abstract T Visit(IBinaryNode node);
        public abstract T Visit(ICompareNode node);
        public abstract T Visit(IFunctionCallNode node);

        public T Visit(IExpressionNode node)
        {
            return Visit((dynamic)node);
        }
    }
}