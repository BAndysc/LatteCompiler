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
        public abstract T Visit(IExpressionStatementNode node);
        public abstract T Visit(IStructAssignmentNode node);
        public abstract T Visit(IStructAssignmentWithOffsetNode node);
        public abstract T Visit(IStructIncrementNode node);
        public abstract T Visit(IStructIncrementWithOffsetNode node);
        public abstract T Visit(IStructDecrementNode node);
        public abstract T Visit(IStructDecrementWithOffsetNode node);
        

        public T Visit(IStatement node)
        {
            return Visit((dynamic)node);
        }
    }
    
    public abstract class StatementVoidVisitor
    {
        public abstract void Visit(IEmptyNode node);
        public abstract void Visit(IBlockNode node);
        public abstract void Visit(IDeclarationNode node);
        public abstract void Visit(IAssignmentNode node);
        public abstract void Visit(IIncrementNode node);
        public abstract void Visit(IDecrementNode node);
        public abstract void Visit(IReturnNode node);
        public abstract void Visit(IVoidReturnNode node);
        public abstract void Visit(IIfNode node);
        public abstract void Visit(IIfElseNode node);
        public abstract void Visit(IWhileNode node);
        public abstract void Visit(IExpressionStatementNode node);
        public abstract void Visit(IStructAssignmentNode node);
        public abstract void Visit(IStructAssignmentWithOffsetNode node);
        public abstract void Visit(IStructIncrementNode node);
        public abstract void Visit(IStructIncrementWithOffsetNode node);
        public abstract void Visit(IStructDecrementNode node);
        public abstract void Visit(IStructDecrementWithOffsetNode node);

        public void Visit(IStatement node)
        {
            Visit((dynamic)node);
        }
    }
}