using LatteAntlr.Visitors;
using LatteBase;

namespace LatteAntlr.AST.Generators
{
    internal class LatteTypeGenerator : LatteBaseTypeVisitor<ILatteType>
    {
        public override ILatteType VisitTTypeName(LatteParser.TTypeNameContext context)
        {
            switch (context.GetText())
            {
                case "int":
                    return LatteType.Int;
                case "void":
                    return LatteType.Void;
                case "boolean":
                    return LatteType.Bool;
                case "string":
                    return LatteType.String;
            }
            
            return new LatteType(context.GetText());
        }

        public override ILatteType VisitTArray(LatteParser.TArrayContext context)
        {
            return new LatteType(Visit(context.type_()));
        }
    }
}