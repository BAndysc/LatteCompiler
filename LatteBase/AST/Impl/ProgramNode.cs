using System.Collections.Generic;
using LatteBase.AST;

namespace LatteBase.AST.Impl
{
    public class ProgramNode : IProgram
    {
        public ProgramNode(IEnumerable<ITopFunctionNode> functions)
        {
            Functions = functions;
        }

        public IEnumerable<ITopFunctionNode> Functions { get; }
    }
}