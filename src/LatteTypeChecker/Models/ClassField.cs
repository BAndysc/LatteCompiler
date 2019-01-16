using LatteBase;

namespace LatteTypeChecker.Models
{
    public class ClassField : IClassField
    {
        public ClassField(LatteType fieldType, string fieldName)
        {
            FieldType = fieldType;
            FieldName = fieldName;
        }

        public string FieldName { get; }
        public LatteType FieldType { get; }
    }
}