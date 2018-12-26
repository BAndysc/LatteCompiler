using System.Linq;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    public class TreeOptimizer : ProgramVisitor<IProgram>
    {
        public override IProgram Visit(IProgram program)
        {
            var functionOptimizer = new FunctionOptimizer();
            return new ProgramNode(program.Functions.Select(functionOptimizer.Visit));
        }
    }
}