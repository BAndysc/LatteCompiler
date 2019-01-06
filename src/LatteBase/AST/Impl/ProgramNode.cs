using System.Collections.Generic;
using System.Linq;
using LatteBase.AST;

namespace LatteBase.AST.Impl
{
    public class ProgramNode : IProgram
    {
        public ProgramNode(IEnumerable<ITopFunctionNode> functions)
        {
            Functions = functions;
        }

        public ProgramNode(params ITopFunctionNode[] functions) : this(functions.ToList())
        {
        }
        
        public IEnumerable<ITopFunctionNode> Functions { get; }
    }
}