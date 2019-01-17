using System;
using System.Collections.Generic;
using LatteBase;

namespace LatteTypeChecker.Models
{
    public struct FunctionDefinition : IFunctionDefinition
    {
        public ILatteType ReturnType { get; }
        public string Name { get; }
        public IList<ILatteType> ArgumentTypes { get; }
        public IList<string> ArgumentNames { get; }

        public FunctionDefinition(ILatteType returnType, string name, IList<ILatteType> argumentTypes = null, IList<string> argumentNames = null)
        {
            ReturnType = returnType;
            Name = name;
            ArgumentTypes = argumentTypes;
            ArgumentNames = argumentNames;

            if (argumentTypes == null)
                ArgumentTypes = new List<ILatteType>();
            if (argumentNames == null)
                ArgumentNames = new List<string>();
            
            if (ArgumentNames.Count != ArgumentTypes.Count)
                throw new InvalidOperationException();
        }
    }
}