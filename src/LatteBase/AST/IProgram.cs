using System.Collections.Generic;

namespace LatteBase.AST
{
    public interface IProgram
    {
        IEnumerable<ITopFunctionNode> Functions { get; }
    }

}