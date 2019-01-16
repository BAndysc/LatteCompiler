using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class DuplicateClassFieldException : TypeCheckerException
    {
        private readonly string fieldName;
        private readonly string className;

        public DuplicateClassFieldException(string fieldName, string className, IFilePlace source) : base(source)
        {
            this.fieldName = fieldName;
            this.className = className;
        }

        public override string ToString()
        {
            return $"In class {className} duplicate field: {fieldName}.\n {base.ToString()}";
        }
    }
}