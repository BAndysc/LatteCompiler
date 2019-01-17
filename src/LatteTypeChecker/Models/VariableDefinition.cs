
using LatteBase;

namespace LatteTypeChecker.Models
{
    public struct VariableDefinition : IVariableDefinition
    {
        public string Name { get; }
        public ILatteType Type { get; }

        public VariableDefinition(string name, ILatteType type)
        {
            Name = name;
            Type = type;
        }
    }
}