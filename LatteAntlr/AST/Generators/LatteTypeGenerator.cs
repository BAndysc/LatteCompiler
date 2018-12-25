using LatteAntlr.Visitors;
using LatteBase;

namespace LatteAntlr.AST.Generators
{
    internal class LatteTypeGenerator : LatteBaseTypeVisitor<LatteType>
    {
        public override LatteType VisitInt(LatteParser.IntContext context)
        {
            return LatteType.Int;
        }

        public override LatteType VisitStr(LatteParser.StrContext context)
        {
            return LatteType.String;
        }

        public override LatteType VisitBool(LatteParser.BoolContext context)
        {
            return LatteType.Bool;
        }

        public override LatteType VisitVoid(LatteParser.VoidContext context)
        {
            return LatteType.Void;
        }
    }
}