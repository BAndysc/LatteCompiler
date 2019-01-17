using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    public class IsReturnStatement : StatementVisitor<bool>
    {
        public override bool Visit(IEmptyNode node)
        {
            return false;
        }

        public override bool Visit(IBlockNode node)
        {
            return false;
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
            return true;
        }

        public override bool Visit(IVoidReturnNode node)
        {
            return true;
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
    }
}