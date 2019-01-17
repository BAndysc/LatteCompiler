using System.Collections.Generic;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Models
{
    public class Environment : IEnvironment
    {
        private readonly Dictionary<string, IFunctionDefinition> definedFunctions = new Dictionary<string, IFunctionDefinition>();

        private readonly Dictionary<string, IClassDefinition> definedClasses = new Dictionary<string, IClassDefinition>();

        
        public bool IsFunctionDefined(string functionName)
        {
            return definedFunctions.ContainsKey(functionName);
        }

        public bool IsFunctionDefined(IFunctionDefinition function)
        {
            return IsFunctionDefined(function.Name);
        }

        public void DefineFunction(IFunctionDefinition function)
        {
            definedFunctions[function.Name] = function;
        }

        public IFunctionDefinition this[string functionName] => definedFunctions[functionName];

        
        public bool IsClassDefined(string className)
        {
            return definedClasses.ContainsKey(className);
        }

        public void DefineClass(IClassDefinition @class)
        {
            definedClasses[@class.Name] = @class;
        }

        public IClassDefinition GetClass(string className)
        {
            return definedClasses[className];
        }
    }
}