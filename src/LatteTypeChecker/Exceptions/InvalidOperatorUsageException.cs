using System.Linq;
using LatteBase;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class InvalidOperatorUsageException : TypeCheckerException
    {
        private readonly ILatteType givenType;
        private readonly ILatteType[] expectedType;

        public InvalidOperatorUsageException(
            ILatteType givenType,
            IFilePlace source,
            params ILatteType[] expectedType) : base(source)
        {
            this.givenType = givenType;
            this.expectedType = expectedType;
        }

        public override string ToString()
        {
            return $"Given operator is valid only for types {string.Join(", ", expectedType.Select(t => t.Name))}, but given {givenType}.\n{base.ToString()}";
        }
    }
}