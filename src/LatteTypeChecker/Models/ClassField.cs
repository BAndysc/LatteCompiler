using LatteBase;

namespace LatteTypeChecker.Models
{
    public class ClassField : IClassField
    {
        public ClassField(ILatteType fieldType, string fieldName)
        {
            FieldType = fieldType;
            FieldName = fieldName;
        }

        public string FieldName { get; }
        public ILatteType FieldType { get; }
    }
}