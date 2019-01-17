using LatteBase;
using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class FieldTypeMismatchException : TypeCheckerException
    {
        public readonly string FieldName;
        public readonly ILatteType FieldType;
        public readonly ILatteType ValueType;

        public FieldTypeMismatchException(IFilePlace source, string fieldName, ILatteType fieldType, ILatteType valueType) : base(source)
        {
            this.FieldName = fieldName;
            this.FieldType = fieldType;
            this.ValueType = valueType;
        }

        public override string ToString()
        {
            return $"Field {FieldName} has type {FieldType} but trying to assign {ValueType}.\n{base.ToString()}";
        }
    }
}