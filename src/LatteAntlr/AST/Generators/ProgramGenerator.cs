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
            var classGenerator = new ClassDefinitionGenerator();

            var functions = context.topDef().Select(functionGenerator.Visit).Where(t => t != null).ToList();
            var classes = context.topDef().Select(classGenerator.Visit).Where(t => t != null).ToList();
           
            classes.Sort((a, b) =>
            {
                if (string.IsNullOrEmpty(a.SuperClass))
                    return -1;
                if (a.ClassName == b.SuperClass)
                    return -1;
                return 1;
            });
            
            return new ProgramNode(functions, classes);
        }
    }
}