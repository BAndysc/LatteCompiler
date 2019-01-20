using System.Collections.Generic;

namespace LatteBase.AST
{
    public interface IClassDefinitionNode : INode
    {
        string ClassName { get; }
        string SuperClass { get; }
        IEnumerable<IClassFieldNode> Fields { get; }
        IEnumerable<IFunctionDefinitionNode> Methods { get; }
    }
}