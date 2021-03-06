using System.Collections.Generic;
using System.Linq;
using LatteAntlr.Visitors;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace LatteAntlr.AST.Generators
{
    internal class TopFunctionGenerator : LatteBaseFunctionDefVisitor<IFunctionDefinitionNode>
    {
        public override IFunctionDefinitionNode VisitFunctionDef(LatteParser.FunctionDefContext context)
        {
            var typeGenerator = new LatteTypeGenerator();

            var type__ = context.type_();
            var type = typeGenerator.Visit(type__);
            var name = context.ID().GetText();

            var arguments = new List<FunctionArgument>();

            if (context.arg() != null)
            {
                var argsTypes = context.arg().type_().Select(typeGenerator.Visit);
                var argsNames = context.arg().ID().Select(t => t.GetText());
                arguments = argsTypes.Zip(argsNames, (type_, name_) => new FunctionArgument(type_, name_)).ToList();                
            }
            
            var statement = new BlockGenerator().Visit(context.block());
            return new FunctionDefinitionNode(new FilePlace(context), type, name, arguments, statement);
        }

        public override IFunctionDefinitionNode VisitClassDef(LatteParser.ClassDefContext context)
        {
            return null;
        }
    }
}