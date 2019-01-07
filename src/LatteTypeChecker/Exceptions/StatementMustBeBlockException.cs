using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class StatementMustBeBlockException : TypeCheckerException
    {
        public StatementMustBeBlockException(IFilePlace place) : base(place)
        {
        }

        public override string ToString()
        {
            return $"Expected block.\n{base.ToString()}";
        }
    }
}