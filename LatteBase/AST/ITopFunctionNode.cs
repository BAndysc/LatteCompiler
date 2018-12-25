using System.Collections.Generic;

namespace LatteBase.AST
{
    public interface IFunctionArgument
    {
        LatteType Type { get; }
        string Name { get; }
    }
    
    public interface ITopFunctionNode : INode
    {
        LatteType ReturnType { get; }
        string Name { get; }
        IEnumerable<IFunctionArgument> Arguments { get; }
        IStatement Body { get; }
    }
}