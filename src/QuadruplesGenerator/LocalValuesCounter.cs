using System;
using System.Linq;
using LatteBase.AST;
using LatteBase.Visitors;

namespace QuadruplesGenerator
{
    public class LocalValuesCounter : StatementVisitor<int>
    {
        private readonly ValueMaxCounter valueMax;

        public LocalValuesCounter(ValueMaxCounter counter)
        {
            valueMax = counter;
        }
        
        public override int Visit(IEmptyNode node)
        {
            return 0;
        }

        public override int Visit(IBlockNode node)
        {
            int toReturn = 0;
            foreach (var stmt in node.Statements)
            {
                toReturn += Visit(stmt);
            }

            valueMax.Sub(toReturn);
            
            return 0;
        }

        public override int Visit(IDeclarationNode node)
        {
            var count = node.Declarations.Count();
            valueMax.Add(count);
            return count;
        }

        public override int Visit(IAssignmentNode node)
        {
            return 0;
        }

        public override int Visit(IStructAssignmentNode node)
        {
            return 0;
        }

        public override int Visit(IIncrementNode node)
        {
            return 0;
        }

        public override int Visit(IDecrementNode node)
        {
            return 0;
        }

        public override int Visit(IReturnNode node)
        {
            return 0;
        }

        public override int Visit(IVoidReturnNode node)
        {
            return 0;
        }

        public override int Visit(IIfNode node)
        {
            return Visit(node.Statement);
        }

        public override int Visit(IIfElseNode node)
        {
            return Math.Max(Visit(node.Statement), Visit(node.ElseStatement));
        }

        public override int Visit(IWhileNode node)
        {
            return Visit(node.Statement);
        }

        public override int Visit(IExpressionStatementNode nodeNode)
        {
            return 0;
        }
    }
}