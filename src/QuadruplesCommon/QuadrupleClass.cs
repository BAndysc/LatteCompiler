using System.Collections.Generic;
using System.Linq;

namespace QuadruplesCommon
{
    public class QuadrupleClass
    {
        public readonly string ClassName;
        public readonly IEnumerable<int> FieldsSize;
        public readonly IEnumerable<string> FieldsName;
        public readonly IEnumerable<string> Methods;
        public readonly QuadrupleClass SuperClass;

        public Label VTable { get; set; }
        
        public QuadrupleClass(string className, IEnumerable<int> fieldsSize, IEnumerable<string> fieldsName, IEnumerable<string> methods, QuadrupleClass superClass)
        {
            ClassName = className;
            FieldsSize = fieldsSize;
            FieldsName = fieldsName;
            Methods = methods;
            SuperClass = superClass;
        }

        public override string ToString()
        {
            return $"class {ClassName} = {{{string.Join(", ", FieldsSize)}}}";
        }

        public IEnumerable<string> AllMethods()
        {
            return (SuperClass == null ? new string[] { } : SuperClass.AllMethods()).Union(Methods).Distinct();
        }

        public QuadrupleClass GetDefiningClass(string method)
        {
            if (Methods.Contains(method))
                return this;
            return SuperClass?.GetDefiningClass(method);
        }
        
        public int VtableSize()
        {
            return AllMethods().Count();
        }
    }
    
}