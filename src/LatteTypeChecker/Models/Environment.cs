using System.Collections.Generic;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Models
{
    public class Environment : IEnvironment
    {
        private readonly Dictionary<string, IFunctionDefinition> definedFunctions = new Dictionary<string, IFunctionDefinition>();

        public bool IsDefined(string functionName)
        {
            return definedFunctions.ContainsKey(functionName);
        }

        public bool IsDefined(IFunctionDefinition function)
        {
            return IsDefined(function.Name);
        }

        public void Define(IFunctionDefinition function)
        {
            definedFunctions[function.Name] = function;
        }

        public IFunctionDefinition this[string functionName] => definedFunctions[functionName];
    }
}