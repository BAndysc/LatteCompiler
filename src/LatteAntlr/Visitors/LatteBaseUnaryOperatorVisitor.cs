namespace LatteAntlr.Visitors
{
    internal class LatteBaseUnaryOperatorVisitor<T> : LatteLimitedVisitor<T>
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

        public sealed override T VisitInt(LatteParser.IntContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitStr(LatteParser.StrContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitBool(LatteParser.BoolContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitVoid(LatteParser.VoidContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitItem(LatteParser.ItemContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEId(LatteParser.EIdContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEFunCall(LatteParser.EFunCallContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitERelOp(LatteParser.ERelOpContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitETrue(LatteParser.ETrueContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEOr(LatteParser.EOrContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEInt(LatteParser.EIntContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEUnOp(LatteParser.EUnOpContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEStr(LatteParser.EStrContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEMulOp(LatteParser.EMulOpContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEAnd(LatteParser.EAndContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEParen(LatteParser.EParenContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEFalse(LatteParser.EFalseContext context)
        {
            return ThrowInvalidContext(context);
        }

        public sealed override T VisitEAddOp(LatteParser.EAddOpContext context)
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
    }
}