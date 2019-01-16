using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class DuplicateClassDefinitionException : TypeCheckerException
    {
        private readonly IClassDefinitionNode @class;

        public DuplicateClassDefinitionException(IClassDefinitionNode @class, IFilePlace filePlace) : base(filePlace)
        {
            this.@class = @class;
        }

        public override string ToString()
        {
            return $"Duplicate class definition: {@class.ClassName}.\n{base.ToString()}";
        }
    }
}