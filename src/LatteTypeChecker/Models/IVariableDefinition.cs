
using LatteBase;

namespace LatteTypeChecker.Models
{
    public interface IVariableDefinition
    {
        string Name { get; }
        ILatteType Type { get; }
    }
}