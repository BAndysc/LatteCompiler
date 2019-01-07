using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class UndeclaredFunctionException : TypeCheckerException
    {
        private readonly string function;

        public UndeclaredFunctionException(string function, IFilePlace place) : base(place)
        {
            this.function = function;
        }

        public override string ToString()
        {
            return $"Expected function {function}.\n{base.ToString()}";
        }
    }
}