using System.Collections.Generic;
using System.Linq;
using LatteAntlr.Visitors;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace LatteAntlr.AST.Generators
{
    internal class TopFunctionGenerator : LatteBaseTopDefVisitor<ITopFunctionNode>
    {
        public override ITopFunctionNode VisitTopDef(LatteParser.TopDefContext context)
        {
            var typeGenerator = new LatteTypeGenerator();
            
            var type = typeGenerator.Visit(context.type_());
            var name = context.ID().GetText();

            var arguments = new List<FunctionArgument>();

            if (context.arg() != null)
            {
                var argsTypes = context.arg().type_().Select(typeGenerator.Visit);
                var argsNames = context.arg().ID().Select(t => t.GetText());
                arguments = argsTypes.Zip(argsNames, (type_, name_) => new FunctionArgument(type_, name_)).ToList();                
            }
            
            var statement = new BlockGenerator().Visit(context.block());
            return new TopFunctionNode(new FilePlace(context), type, name, arguments, statement);
        }
    }
}