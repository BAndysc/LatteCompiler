using LatteBase;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Models
{
    public interface IEnvironment
    {
        bool IsFunctionDefined(string functionName);
        bool IsFunctionDefined(IFunctionDefinition function);
        void DefineFunction(IFunctionDefinition function);
        IFunctionDefinition this[string functionName] { get; }

        bool IsClassDefined(string className);
        void DefineClass(IClassDefinition @class);
        IClassDefinition GetClass(string className);
        bool IsTypeAssignable(ILatteType type, ILatteType toType);
        bool IsTypeDefined(ILatteType latteType);
    }
}