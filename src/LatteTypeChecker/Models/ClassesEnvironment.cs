using System.Collections.Generic;

namespace LatteTypeChecker.Models
{
    public class ClassesEnvironment : IClassesEnvironment
    {
        private readonly Dictionary<string, IClassDefinition> classes;

        public ClassesEnvironment()
        {
            this.classes = new Dictionary<string, IClassDefinition>();
        }

        public bool IsDefined(string @class)
        {
            return classes.ContainsKey(@class);
        }

        public IClassDefinition GetClass(string className)
        {
            return classes[className];
        }

        public void DefineClass(IClassDefinition @class)
        {
            classes[@class.Name] = @class;
        }
    }
}