using System.Collections.Generic;

namespace QuadruplesCommon
{
    public class QuadrupleClass
    {
        public readonly string ClassName;
        public readonly IEnumerable<int> FieldsSize;
        public readonly IEnumerable<string> FieldsName;

        public QuadrupleClass(string className, IEnumerable<int> fieldsSize, IEnumerable<string> fieldsName)
        {
            ClassName = className;
            FieldsSize = fieldsSize;
            FieldsName = fieldsName;
        }

        public override string ToString()
        {
            return $"class {ClassName} = {{{string.Join(", ", FieldsSize)}}}";
        }
    }
    
}