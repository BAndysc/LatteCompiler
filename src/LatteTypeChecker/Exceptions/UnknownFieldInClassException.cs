using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class UnknownFieldInClassException : TypeCheckerException
    {
        public readonly IClassDefinition Class;
        public readonly string FieldName;

        public UnknownFieldInClassException(IFilePlace source, IClassDefinition @class, string fieldName) : base(source)
        {
            this.Class = @class;
            this.FieldName = fieldName;
        }

        public override string ToString()
        {
            return $"Field {FieldName} undefined in class {Class.Name}.\n{base.ToString()}";
        }
    }
}