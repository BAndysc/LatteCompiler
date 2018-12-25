using System;
using LatteBase;
using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class InvalidReturnTypeException : TypeCheckerException
    {
        private readonly LatteType expectedReturnType;
        private readonly LatteType givenReturnType;

        public InvalidReturnTypeException(LatteType expectedReturnType, LatteType givenReturnType, IFilePlace filePlace) : base(filePlace)
        {
            this.expectedReturnType = expectedReturnType;
            this.givenReturnType = givenReturnType;
        }

        public override string ToString()
        {
            return $"Expected return type: {expectedReturnType}, but given: {givenReturnType}. {base.ToString()}";
        }
    }
}