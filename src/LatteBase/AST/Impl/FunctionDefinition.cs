using System.Collections.Generic;
using System.Linq;
using LatteBase;
using LatteBase.AST;

namespace LatteBase.AST.Impl
{
    public class FunctionArgument : IFunctionArgument
    {
        public FunctionArgument(LatteType type, string name)
        {
            Type = type;
            Name = name;
        }

        public LatteType Type { get; }
        public string Name { get; }
    }
    
    public class FunctionDefinition : Node, IFunctionDefinition
    {
        public FunctionDefinition(IFilePlace place, LatteType type, string name, IEnumerable<IFunctionArgument> arguments, IStatement body) : base(place)
        {
            ReturnType = type;
            Name = name;
            Arguments = arguments;
            Body = body;
        }

        public FunctionDefinition(IFilePlace place, LatteType type, string name, IStatement body,
            params IFunctionArgument[] arguments) : this(place, type, name, arguments.ToList(), body)
        {
            
        }
        
        public LatteType ReturnType { get; }
        public string Name { get; }
        public IEnumerable<IFunctionArgument> Arguments { get; }
        public IStatement Body { get; }
    }
}