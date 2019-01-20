using System.Collections.Generic;
using System.Linq;
using LatteBase;

namespace LatteTypeChecker.Models
{
    public class ClassDefinition : IClassDefinition
    {
        private Dictionary<string, IFunctionDefinition> methods;
        
        public ClassDefinition(string name, IList<IClassField> fields)
        {
            methods = new Dictionary<string, IFunctionDefinition>();
            Name = name;
            Type = new LatteType(name);
            Fields = fields;
        }

        public string Name { get; }
        public IList<IClassField> Fields { get; }
        public IEnumerable<IFunctionDefinition> Methods => methods.Values;
        public ILatteType Type { get; }

        public bool HasField(string fieldName)
        {
            return GetField(fieldName) != null;
        }

        public IClassField GetField(string fieldName)
        {
            return Fields.FirstOrDefault(t => t.FieldName == fieldName);
        }

        public bool HasMethod(string methodName)
        {
            return methods.ContainsKey(methodName);
        }

        public IFunctionDefinition GetMethod(string methodName)
        {
            return methods[methodName];
        }

        public void DefineMethod(IFunctionDefinition functionDef)
        {
            methods[functionDef.Name] = functionDef;
        }
    }
}