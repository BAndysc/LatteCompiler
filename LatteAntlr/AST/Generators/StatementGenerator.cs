using System.Linq;
using LatteAntlr.Visitors;
using LatteBase.AST;

namespace LatteAntlr.AST.Generators
{
    internal class StatementGenerator : LatteBaseStatementVisitor<IStatement>
    {
        public override IStatement VisitEmpty(LatteParser.EmptyContext context)
        {
            return new EmptyNode(new FilePlace(context));
        }

        public override IStatement VisitBlockStmt(LatteParser.BlockStmtContext context)
        {
            var statements = context.block().stmt().Select(Visit).ToList();
            return new BlockNode(new FilePlace(context), statements);
        }

        public override IStatement VisitDecl(LatteParser.DeclContext context)
        {
            var type = new LatteTypeGenerator().Visit(context.type_());
            
            var visitor = new ExpressionGenerator();

            var declarations = context.item().Select(item => new SingleDeclaration(item.ID().GetText(), item.expr() == null ? null : visitor.Visit(item.expr()))).ToList();
            
            return new DeclarationNode(new FilePlace(context), type, declarations);
        }

        public override IStatement VisitAss(LatteParser.AssContext context)
        {
            var visitor = new ExpressionGenerator();
            var expr = visitor.Visit(context.expr());
            
            return new AssignmentNode(new FilePlace(context), context.ID().GetText(), expr);
        }

        public override IStatement VisitIncr(LatteParser.IncrContext context)
        {
            return new IncrementNode(new FilePlace(context), context.ID().GetText());
        }

        public override IStatement VisitDecr(LatteParser.DecrContext context)
        {
            return new IncrementNode(new FilePlace(context), context.ID().GetText());
        }

        public override IStatement VisitRet(LatteParser.RetContext context)
        {
            var visitor = new ExpressionGenerator();
            var expr = visitor.Visit(context.expr());
            
            return new ReturnNode(new FilePlace(context), expr);
        }

        public override IStatement VisitVRet(LatteParser.VRetContext context)
        {
            return new VoidReturnNode(new FilePlace(context));
        }

        public override IStatement VisitCond(LatteParser.CondContext context)
        {
            var visitor = new ExpressionGenerator();
            var condition = visitor.Visit(context.expr());
            
            return new IfNode(new FilePlace(context), condition, Visit(context.stmt()));
        }

        public override IStatement VisitCondElse(LatteParser.CondElseContext context)
        {
            var visitor = new ExpressionGenerator();
            var condition = visitor.Visit(context.expr());
            
            return new IfElseNode(new FilePlace(context), condition, Visit(context.stmt()[0]), Visit(context.stmt()[1]));
        }

        public override IStatement VisitWhile(LatteParser.WhileContext context)
        {
            var visitor = new ExpressionGenerator();
            var condition = visitor.Visit(context.expr());
            
            return new WhileNode(new FilePlace(context), condition, Visit(context.stmt()));
        }

        public override IStatement VisitSExp(LatteParser.SExpContext context)
        {
            var visitor = new ExpressionGenerator();
            var expression = visitor.Visit(context.expr());
            
            return new ExpressionStatementNode(new FilePlace(context), expression);
        }
    }
}