using LatteAntlr.Visitors;

namespace LatteAntlr.AST
{
    internal class IsLogicalNegationVisitor : LatteBaseUnaryOperatorVisitor<bool>
    {
        public override bool VisitUnaryMinus(LatteParser.UnaryMinusContext context)
        {
            return false;
        }

        public override bool VisitUnaryNeg(LatteParser.UnaryNegContext context)
        {
            return true;
        }
    }
}