
using LatteBase;

namespace LatteTypeChecker.Models
{
    public interface IFunctionDefinition
    {
        LatteType ReturnType { get; }
        string Name { get; }
    }
}