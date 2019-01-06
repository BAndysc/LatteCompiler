using System;
using System.Collections.Generic;
using LatteBase;

namespace LatteTypeChecker.Models
{
    public struct FunctionDefinition : IFunctionDefinition
    {
        public LatteType ReturnType { get; }
        public string Name { get; }
        public IList<LatteType> ArgumentTypes { get; }
        public IList<string> ArgumentNames { get; }

        public FunctionDefinition(LatteType returnType, string name, IList<LatteType> argumentTypes = null, IList<string> argumentNames = null)
        {
            ReturnType = returnType;
            Name = name;
            ArgumentTypes = argumentTypes;
            ArgumentNames = argumentNames;

            if (argumentTypes == null)
                ArgumentTypes = new List<LatteType>();
            if (argumentNames == null)
                ArgumentNames = new List<string>();
            
            if (ArgumentNames.Count != ArgumentTypes.Count)
                throw new InvalidOperationException();
        }
    }
}