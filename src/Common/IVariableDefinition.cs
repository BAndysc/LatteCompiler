
using LatteBase;

namespace Common
{
    public interface IVariableDefinition
    {
        string Name { get; }
        ILatteType Type { get; }
    }
}