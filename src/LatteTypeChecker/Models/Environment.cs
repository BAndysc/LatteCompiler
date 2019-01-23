using System.Collections.Generic;
using LatteBase;
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

        public bool IsTypeAssignable(ILatteType type, ILatteType toType)
        {
            if (type.Equals(toType))
                return true;

            if (IsSimpleType(type) || IsSimpleType(toType))
                return false;

            if (type == LatteType.Null)
                return true;
            
            IClassDefinition classDefinition = GetClass(type.Name);
            while (classDefinition != null)
            {
                if (classDefinition.Type.Equals(toType))
                    return true;

                classDefinition = classDefinition.SuperClass;
            }
            
            return false;
        }

        public bool IsTypeDefined(ILatteType latteType)
        {
            if (latteType == LatteType.Int)
                return true;
            if (latteType == LatteType.String)
                return true;
            if (latteType == LatteType.Bool)
                return true;
            if (latteType == LatteType.Void)
                return true;
            if (latteType == LatteType.Null)
                return true;
            if (latteType.IsArray)
                return IsTypeDefined(latteType.BaseType);
            return IsClassDefined(latteType.Name);
        }

        private bool IsSimpleType(ILatteType type)
        {
            return (type == LatteType.Int || type == LatteType.Bool || type == LatteType.String);
        }
    }
}