using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;

namespace LatteAntlr.AST
{
    internal class FunctionArgument : IFunctionArgument
    {
        public FunctionArgument(LatteType type, string name)
        {
            Type = type;
            Name = name;
        }

        public LatteType Type { get; }
        public string Name { get; }
    }
    
    internal class TopFunctionNode : Node, ITopFunctionNode
    {
        public TopFunctionNode(IFilePlace place, LatteType type, string name, IEnumerable<IFunctionArgument> arguments, IStatement body) : base(place)
        {
            ReturnType = type;
            Name = name;
            Arguments = arguments;
            Body = body;
        }

        public LatteType ReturnType { get; }
        public string Name { get; }
        public IEnumerable<IFunctionArgument> Arguments { get; }
        public IStatement Body { get; }
    }
}