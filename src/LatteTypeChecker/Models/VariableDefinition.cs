
using LatteBase;

namespace LatteTypeChecker.Models
{
    public struct VariableDefinition : IVariableDefinition
    {
        public string Name { get; }
        public LatteType Type { get; }

        public VariableDefinition(string name, LatteType type)
        {
            Name = name;
            Type = type;
        }
    }
}