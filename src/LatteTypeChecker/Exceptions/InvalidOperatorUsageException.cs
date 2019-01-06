using LatteBase;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class InvalidOperatorUsageException : TypeCheckerException
    {
        private readonly LatteType givenType;
        private readonly LatteType[] expectedType;

        public InvalidOperatorUsageException(
            LatteType givenType,
            IFilePlace source,
            params LatteType[] expectedType) : base(source)
        {
            this.givenType = givenType;
            this.expectedType = expectedType;
        }

        public override string ToString()
        {
            return $"Given operator is valid only for types {string.Join(", ", expectedType)}, but given {givenType}. {base.ToString()}";
        }
    }
}