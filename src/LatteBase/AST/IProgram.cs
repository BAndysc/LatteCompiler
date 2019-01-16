using System.Collections.Generic;

namespace LatteBase.AST
{
    public interface IProgram
    {
        IEnumerable<IFunctionDefinition> Functions { get; }
        IEnumerable<IClassDefinitionNode> Classes { get; }
    }

}