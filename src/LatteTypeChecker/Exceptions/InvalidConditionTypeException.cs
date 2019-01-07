using System;
using LatteBase;
using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class InvalidConditionTypeException : TypeCheckerException
    {
        private readonly LatteType expectedType;
        private readonly LatteType givenType;

        public InvalidConditionTypeException(LatteType expectedType, LatteType givenType, IFilePlace filePlace) : base(filePlace)
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