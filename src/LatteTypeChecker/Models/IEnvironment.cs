using LatteTypeChecker.Models;

namespace LatteTypeChecker.Models
{
    public interface IEnvironment
    {
        bool IsDefined(string functionName);
        bool IsDefined(IFunctionDefinition function);
        void Define(IFunctionDefinition function);
        IFunctionDefinition this[string functionName] { get; }
    }
}