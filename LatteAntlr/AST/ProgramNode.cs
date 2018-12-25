using System.Collections.Generic;
using LatteBase.AST;

namespace LatteAntlr.AST
{
    internal class ProgramNode : IProgram
    {
        public ProgramNode(IEnumerable<ITopFunctionNode> functions)
        {
            Functions = functions;
        }

        public IEnumerable<ITopFunctionNode> Functions { get; }
    }
}