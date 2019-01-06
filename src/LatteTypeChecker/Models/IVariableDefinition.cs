
using LatteBase;

namespace LatteTypeChecker.Models
{
    public interface IVariableDefinition
    {
        string Name { get; }
        LatteType Type { get; }
    }
}