using System.Collections.Generic;

namespace QuadruplesCommon
{
    public class QuadrupleClass
    {
        public readonly string ClassName;
        public readonly IEnumerable<int> FieldsSize;
        public readonly IEnumerable<string> FieldsName;
        public readonly QuadrupleClass SuperClass;

        public QuadrupleClass(string className, IEnumerable<int> fieldsSize, IEnumerable<string> fieldsName, QuadrupleClass superClass)
        {
            ClassName = className;
            FieldsSize = fieldsSize;
            FieldsName = fieldsName;
            SuperClass = superClass;
        }

        public override string ToString()
        {
            return $"class {ClassName} = {{{string.Join(", ", FieldsSize)}}}";
        }
    }
    
}