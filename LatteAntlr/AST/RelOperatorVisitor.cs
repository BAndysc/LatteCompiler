using LatteAntlr.Visitors;
using LatteBase.AST;

namespace LatteAntlr.AST
{
    internal class RelOperatorVisitor : LatteBaseRelOperatorVisitor<RelOperator>
    {
        public override RelOperator VisitLessThan(LatteParser.LessThanContext context)
        {
            return RelOperator.LessThan;
        }

        public override RelOperator VisitLessEquals(LatteParser.LessEqualsContext context)
        {
            return RelOperator.LessEquals;
        }

        public override RelOperator VisitGreaterThan(LatteParser.GreaterThanContext context)
        {
            return RelOperator.GreaterThan;
        }

        public override RelOperator VisitGreaterEquals(LatteParser.GreaterEqualsContext context)
        {
            return RelOperator.GreaterEquals;
        }

        public override RelOperator VisitEquals(LatteParser.EqualsContext context)
        {
            return RelOperator.Equals;
        }

        public override RelOperator VisitNotEquals(LatteParser.NotEqualsContext context)
        {
            return RelOperator.NotEquals;
        }
    }
}