using System.Linq;
using LatteAntlr.Visitors;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace LatteAntlr.AST.Generators
{
    internal class ProgramGenerator : LatteBaseProgramVisitor<IProgram>
    {
        public override IProgram VisitProgram(LatteParser.ProgramContext context)
        {
            var functionGenerator = new TopFunctionGenerator();

            var functions = context.topDef().Select(functionGenerator.Visit).ToList();
            
            return new ProgramNode(functions);
        }
    }
}