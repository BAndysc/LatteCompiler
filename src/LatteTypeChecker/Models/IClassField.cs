using LatteBase;

namespace LatteTypeChecker.Models
{
    public interface IClassField
    {
        string FieldName { get; }
        ILatteType FieldType { get; }
    }
}