using System;
using LatteBase;
using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class InvalidConditionTypeException : TypeCheckerException
    {
        private readonly ILatteType expectedType;
        private readonly ILatteType givenType;

        public InvalidConditionTypeException(ILatteType expectedType, ILatteType givenType, IFilePlace filePlace) : base(filePlace)
        {
            this.expectedType = expectedType;
            this.givenType = givenType;
        }

        public override string ToString()
        {
            return $"Expected {expectedType} in condition, but given {givenType}.\n{base.ToString()}";
        }
    }
}