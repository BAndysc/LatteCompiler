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
    }
}