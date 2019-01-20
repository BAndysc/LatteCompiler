using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using LatteAntlr.Exceptions;

namespace LatteAntlr.Visitors
{
    internal class LatteBaseEmptyVisitor<T> : AbstractParseTreeVisitor<T>, ILatteVisitor<T>
    {
        protected virtual T ReportError(ParserRuleContext context)
        {
            throw new ParserUnhandledException(context.Start.Line, context.GetType(),
                context.Start.InputStream.GetText(new Interval(context.Start.StartIndex, context.Stop.StopIndex)));
        }
        
        public virtual T VisitProgram(LatteParser.ProgramContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitTopDef(LatteParser.TopDefContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitMethodDef(LatteParser.MethodDefContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitArg(LatteParser.ArgContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitBlock(LatteParser.BlockContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEmpty(LatteParser.EmptyContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitBlockStmt(LatteParser.BlockStmtContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitDecl(LatteParser.DeclContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitAss(LatteParser.AssContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitStructAss(LatteParser.StructAssContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitIncr(LatteParser.IncrContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitDecr(LatteParser.DecrContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitRet(LatteParser.RetContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitVRet(LatteParser.VRetContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitCond(LatteParser.CondContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitCondElse(LatteParser.CondElseContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitWhile(LatteParser.WhileContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitSExp(LatteParser.SExpContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitTTypeName(LatteParser.TTypeNameContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitType(LatteParser.TTypeNameContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitItem(LatteParser.ItemContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEId(LatteParser.EIdContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEFunCall(LatteParser.EFunCallContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitERelOp(LatteParser.ERelOpContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitETrue(LatteParser.ETrueContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitECast(LatteParser.ECastContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEOr(LatteParser.EOrContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEInt(LatteParser.EIntContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEUnOp(LatteParser.EUnOpContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEStr(LatteParser.EStrContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEMulOp(LatteParser.EMulOpContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEAnd(LatteParser.EAndContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEMethodCall(LatteParser.EMethodCallContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEObjectField(LatteParser.EObjectFieldContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEParen(LatteParser.EParenContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEFalse(LatteParser.EFalseContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEAddOp(LatteParser.EAddOpContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitENull(LatteParser.ENullContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitENewObject(LatteParser.ENewObjectContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitUnaryMinus(LatteParser.UnaryMinusContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitUnaryNeg(LatteParser.UnaryNegContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitPlus(LatteParser.PlusContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitMinus(LatteParser.MinusContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitMultiply(LatteParser.MultiplyContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitDivide(LatteParser.DivideContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitModulo(LatteParser.ModuloContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitLessThan(LatteParser.LessThanContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitLessEquals(LatteParser.LessEqualsContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitGreaterThan(LatteParser.GreaterThanContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitGreaterEquals(LatteParser.GreaterEqualsContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitEquals(LatteParser.EqualsContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitNotEquals(LatteParser.NotEqualsContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitAddOp(LatteParser.AddOpContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitMulOp(LatteParser.MulOpContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitRelOp(LatteParser.RelOpContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitFunctionDef(LatteParser.FunctionDefContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitClassDef(LatteParser.ClassDefContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitFieldOrMethodDef(LatteParser.FieldOrMethodDefContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitFieldDef(LatteParser.FieldDefContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitStructIncr(LatteParser.StructIncrContext context)
        {
            return ReportError(context);
        }

        public virtual T VisitStructDecr(LatteParser.StructDecrContext context)
        {
            return ReportError(context);
        }
    }
}