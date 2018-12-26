using System.Linq;
using LatteAntlr.Visitors;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace LatteAntlr.AST.Generators
{
    internal class BlockGenerator : LatteBaseBlockVisitor<IStatement>
    {
        public override IStatement VisitBlock(LatteParser.BlockContext context)
        {
            var generator = new StatementGenerator();
            var statements = context.stmt().Select(generator.Visit).ToList();
            return new BlockNode(new FilePlace(context), statements);
        }
    }
}