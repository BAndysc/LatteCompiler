using System.Collections.Generic;
using System.Linq;

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
        
        public bool HasField(string fieldName)
        {
            return GetField(fieldName) != null;
        }

        public IClassField GetField(string fieldName)
        {
            return Fields.FirstOrDefault(t => t.FieldName == fieldName);
        }
    }
}