using LatteBase.AST;

namespace LatteBase.Visitors
{
    public abstract class StatementVisitor<T>
    {
        public abstract T Visit(IEmptyNode node);
        public abstract T Visit(IBlockNode node);
        public abstract T Visit(IDeclarationNode node);
        public abstract T Visit(IAssignmentNode node);
        public abstract T Visit(IIncrementNode node);
        public abstract T Visit(IDecrementNode node);
        public abstract T Visit(IReturnNode node);
        public abstract T Visit(IVoidReturnNode node);
        public abstract T Visit(IIfNode node);
        public abstract T Visit(IIfElseNode node);
        public abstract T Visit(IWhileNode node);
        public abstract T Visit(IExpressionStatementNode nodeNode);

        public T Visit(IStatement node)
        {
            return Visit((dynamic)node);
        }
    }
}