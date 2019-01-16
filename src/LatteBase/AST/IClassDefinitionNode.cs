using System.Collections.Generic;

namespace LatteBase.AST
{
    public interface IClassDefinitionNode : INode
    {
        string ClassName { get; }
        IEnumerable<IClassFieldNode> Fields { get; }
    }
}