using System.Linq;
using LatteAntlr.Visitors;
using LatteBase.AST;
using LatteBase.AST.Impl;

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

        public override IStatement VisitStructAss(LatteParser.StructAssContext context)
        {
            var visitor = new ExpressionGenerator();
            var obj = visitor.Visit(context.expr()[0]);
            var value = visitor.Visit(context.expr()[1]);
            var fieldName = context.ID().GetText();

            return new StructAssignmentNode(new FilePlace(context), obj, fieldName, value);
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
            return new DecrementNode(new FilePlace(context), context.ID().GetText());
        }

        public override IStatement VisitStructIncr(LatteParser.StructIncrContext context)
        {
            return new StructIncrementNode(new FilePlace(context), new ExpressionGenerator().Visit(context.expr()), context.ID().GetText());
        }

        public override IStatement VisitStructDecr(LatteParser.StructDecrContext context)
        {
            return new StructDecrementNode(new FilePlace(context), new ExpressionGenerator().Visit(context.expr()), context.ID().GetText());
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
            
            return new IfNode(new FilePlace(context), condition, new BlockNode(new FilePlace(context), Visit(context.stmt())));
        }

        public override IStatement VisitCondElse(LatteParser.CondElseContext context)
        {
            var visitor = new ExpressionGenerator();
            var condition = visitor.Visit(context.expr());
            
            return new IfElseNode(new FilePlace(context), condition,
                new BlockNode(new FilePlace(context), Visit(context.stmt()[0])),
                new BlockNode(new FilePlace(context), Visit(context.stmt()[1])));
        }

        public override IStatement VisitWhile(LatteParser.WhileContext context)
        {
            var visitor = new ExpressionGenerator();
            var condition = visitor.Visit(context.expr());
            
            return new WhileNode(new FilePlace(context), condition, new BlockNode(new FilePlace(context), Visit(context.stmt())));
        }

        public override IStatement VisitSExp(LatteParser.SExpContext context)
        {
            var visitor = new ExpressionGenerator();
            var expression = visitor.Visit(context.expr());
            
            return new ExpressionStatementNode(new FilePlace(context), expression);
        }

        public override IStatement VisitArrayAss(LatteParser.ArrayAssContext context)
        {
            var visitor = new ExpressionGenerator();
            var array = visitor.Visit(context.expr()[0]);
            var index = visitor.Visit(context.expr()[1]);
            var value = visitor.Visit(context.expr()[2]);
            return new ArrayAssignmentNode(new FilePlace(context), array, index, value);
        }

        public override IStatement VisitForEach(LatteParser.ForEachContext context)
        {
            var type_ = new LatteTypeGenerator().Visit(context.type_());
            var name = context.ID().GetText();
            var array = new ExpressionGenerator().Visit(context.expr());
            var stmt = Visit(context.stmt());
            
            return new ForEachNode(new FilePlace(context), type_, name, array, new BlockNode(new FilePlace(context), stmt));
        }
    }
}