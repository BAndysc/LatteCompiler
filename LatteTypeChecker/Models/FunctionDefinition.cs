using System;
using LatteBase;

namespace LatteTypeChecker.Models
{
    public struct FunctionDefinition : IFunctionDefinition
    {
        public LatteType ReturnType { get; }
        public string Name { get; }

        public FunctionDefinition(LatteType returnType, string name)
        {
            ReturnType = returnType;
            Name = name;
        }
    }
}