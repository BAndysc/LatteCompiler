using System.Collections.Generic;

namespace LatteBase.AST
{
    public interface IFunctionArgument
    {
        ILatteType Type { get; }
        string Name { get; }
    }
    
    public interface IFunctionDefinitionNode : INode
    {
        ILatteType ReturnType { get; }
        string Name { get; }
        IEnumerable<IFunctionArgument> Arguments { get; }
        IStatement Body { get; }
    }
}