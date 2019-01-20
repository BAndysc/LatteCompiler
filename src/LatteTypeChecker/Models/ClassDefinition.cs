using System.Collections.Generic;
using System.Linq;
using LatteBase;

namespace LatteTypeChecker.Models
{
    public class ClassDefinition : IClassDefinition
    {
        private Dictionary<string, IFunctionDefinition> methods;
        
        public ClassDefinition(string name, IClassDefinition superClass, IList<IClassField> fields)
        {
            methods = new Dictionary<string, IFunctionDefinition>();
            Name = name;
            SuperClass = superClass;
            Type = new LatteType(name);
            Fields = fields;
        }

        public string Name { get; }
        public IClassDefinition SuperClass { get; }
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

        public int GetBaseClassFieldsCount()
        {
            if (SuperClass == null)
                return 0;

            return SuperClass.Fields.Count + SuperClass.GetBaseClassFieldsCount();
        }

        public bool HasMethod(string methodName)
        {
            return methods.ContainsKey(methodName) || (SuperClass != null && SuperClass.HasMethod(methodName));
        }

        public IFunctionDefinition GetMethod(string methodName)
        {
            if (methods.ContainsKey(methodName))
                return methods[methodName];

            return SuperClass?.GetMethod(methodName);
        }

        public ILatteType GetBaseTypeWithMethod(string methodName)
        {
            if (methods.ContainsKey(methodName))
                return Type;

            return SuperClass?.GetBaseTypeWithMethod(methodName);
        }

        public void DefineMethod(IFunctionDefinition functionDef)
        {
            methods[functionDef.Name] = functionDef;
        }
    }
}