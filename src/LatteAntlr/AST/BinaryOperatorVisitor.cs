using LatteAntlr.Visitors;
using LatteBase.AST;

namespace LatteAntlr.AST
{
    internal class BinaryOperatorVisitor : LatteBaseBinaryOperatorVisitor<BinaryOperator>
    {
        public override BinaryOperator VisitPlus(LatteParser.PlusContext context)
        {
            return BinaryOperator.Add;
        }

        public override BinaryOperator VisitMinus(LatteParser.MinusContext context)
        {
            return BinaryOperator.Sub;   
        }

        public override BinaryOperator VisitMultiply(LatteParser.MultiplyContext context)
        {
            return BinaryOperator.Mul;   
        }

        public override BinaryOperator VisitDivide(LatteParser.DivideContext context)
        {
            return BinaryOperator.Div;   
        }

        public override BinaryOperator VisitModulo(LatteParser.ModuloContext context)
        {
            return BinaryOperator.Mod;   
        }
    }
}