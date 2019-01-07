using System.Linq;
using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using LatteTypeChecker.Exceptions;
using LatteTypeChecker.Visitors;

namespace LatteTypeChecker
{
    internal class ReturnPresenceChecker : ProgramVisitor<bool>
    {
        public override bool Visit(IProgram program)
        {
            var blockVisitor = new ReturnStatementPresenceChecker();
            
            foreach (var function in program.Functions)
            {                
                bool hasReturned = blockVisitor.Visit(function.Body);

                if (!hasReturned && function.ReturnType != LatteType.Void)
                    throw new ExpectedReturnInFunctionException(function.Name, function.FilePlace);
            }

            return true;
        }
    }

    internal class ReturnStatementPresenceChecker : StatementVisitor<bool>
    {
        public override bool Visit(IEmptyNode node)
        {
            return false;
        }

        public override bool Visit(IBlockNode node)
        {
            return node.Statements.Select(Visit).Aggregate(false, (aggregate, value) => aggregate | value);
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
            var returnInIf = Visit(node.Statement);
            var returnInElse = Visit(node.ElseStatement);

            return returnInIf && returnInElse;
        }

        public override bool Visit(IWhileNode node)
        {
            return false;
        }

        public override bool Visit(IExpressionStatementNode node)
        {
            return new IsExpressionExitCall().Visit(node.Expression);
        }
    }
}