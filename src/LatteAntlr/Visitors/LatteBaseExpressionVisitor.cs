namespace LatteAntlr.Visitors
{
    internal class LatteBaseExpressionVisitor<T> : LatteLimitedVisitor<T>
    {
        public sealed override T VisitProgram(LatteParser.ProgramContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitTopDef(LatteParser.TopDefContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitArg(LatteParser.ArgContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitBlock(LatteParser.BlockContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEmpty(LatteParser.EmptyContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitBlockStmt(LatteParser.BlockStmtContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitDecl(LatteParser.DeclContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitAss(LatteParser.AssContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitIncr(LatteParser.IncrContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitDecr(LatteParser.DecrContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitRet(LatteParser.RetContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitVRet(LatteParser.VRetContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitCond(LatteParser.CondContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitCondElse(LatteParser.CondElseContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitWhile(LatteParser.WhileContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitSExp(LatteParser.SExpContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitItem(LatteParser.ItemContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitAddOp(LatteParser.AddOpContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitMulOp(LatteParser.MulOpContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitRelOp(LatteParser.RelOpContext context)
        {
            return ThrowInvalidContext(context);
        }
        
        public sealed override T VisitPlus(LatteParser.PlusContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitMinus(LatteParser.MinusContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitMultiply(LatteParser.MultiplyContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitDivide(LatteParser.DivideContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitModulo(LatteParser.ModuloContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitLessThan(LatteParser.LessThanContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitLessEquals(LatteParser.LessEqualsContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitGreaterThan(LatteParser.GreaterThanContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitGreaterEquals(LatteParser.GreaterEqualsContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEquals(LatteParser.EqualsContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitNotEquals(LatteParser.NotEqualsContext context)
        {
            return ThrowInvalidContext(context);
        }
        
        public sealed override T VisitUnaryMinus(LatteParser.UnaryMinusContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitUnaryNeg(LatteParser.UnaryNegContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitType(LatteParser.TTypeNameContext context)
        {
            return ThrowInvalidContext(context);
        }
        
        public sealed override T VisitStructAss(LatteParser.StructAssContext context)
        {
            return ThrowInvalidContext(context);
        }
    }
}