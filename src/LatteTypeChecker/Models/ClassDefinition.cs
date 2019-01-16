using System.Collections.Generic;

namespace LatteTypeChecker.Models
{
    public class ClassDefinition : IClassDefinition
    {
        public ClassDefinition(string name, IList<IClassField> fields)
        {
            Name = name;
            Fields = fields;
        }

        public string Name { get; }
        public IList<IClassField> Fields { get; }
    }
}