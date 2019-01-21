using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteTypeChecker.Visitors
{
    internal class IsStatementBlockNode : StatementVisitor<bool>
    {
        public override bool Visit(IEmptyNode node)
        {
            return false;
        }

        public override bool Visit(IBlockNode node)
        {
            return true;
        }

        public override bool Visit(IDeclarationNode node)
        {
            return false;
        }

        public override bool Visit(IAssignmentNode node)
        {
            return false;
        }

        public override bool Visit(IIncrementNode node)
        {
            return false;
        }

        public override bool Visit(IDecrementNode node)
        {
            return false;
        }

        public override bool Visit(IReturnNode node)
        {
            return false;
        }

        public override bool Visit(IVoidReturnNode node)
        {
            return false;
        }

        public override bool Visit(IIfNode node)
        {
            return false;
        }

        public override bool Visit(IIfElseNode node)
        {
            return false;
        }

        public override bool Visit(IWhileNode node)
        {
            return false;
        }

        public override bool Visit(IExpressionStatementNode nodeNode)
        {
            return false;
        }

        public override bool Visit(IStructAssignmentNode node)
        {
            return false;
        }

        public override bool Visit(IStructAssignmentWithOffsetNode node)
        {
            return false;
        }

        public override bool Visit(IStructIncrementNode node)
        {
            return false;
        }

        public override bool Visit(IStructIncrementWithOffsetNode node)
        {
            return false;
        }

        public override bool Visit(IStructDecrementNode node)
        {
            return false;
        }

        public override bool Visit(IStructDecrementWithOffsetNode node)
        {
            return false;
        }

        public override bool Visit(IArrayAssignmentNode node)
        {
            return false;
        }

        public override bool Visit(IForEachNode node)
        {
            return false;
        }
    }
}