using LatteBase;

namespace LatteTypeChecker.Models
{
    public interface IClassField
    {
        string FieldName { get; }
        LatteType FieldType { get; }
    }
}