using System.Collections.Generic;

namespace LatteBase.AST
{
    public interface IProgram
    {
        IEnumerable<IFunctionDefinitionNode> Functions { get; }
        IEnumerable<IClassDefinitionNode> Classes { get; }
    }

}