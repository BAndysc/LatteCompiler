using LatteTypeChecker.Models;

namespace LatteTypeChecker.Models
{
    public interface IVariableEnvironment
    {
        bool IsDefined(IVariableDefinition variable);

        bool IsDefined(string name);
        
        void Define(IVariableDefinition variable);
        bool CanRedefine(IVariableDefinition item);
        
        IVariableDefinition this[string variableName] { get; }
        IVariableEnvironment CopyForBlock();
    }
}