using System;
using LatteBase;
using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class InvalidReturnTypeException : TypeCheckerException
    {
        private readonly ILatteType expectedReturnType;
        private readonly ILatteType givenReturnType;

        public InvalidReturnTypeException(ILatteType expectedReturnType, ILatteType givenReturnType, IFilePlace filePlace) : base(filePlace)
        {
            this.expectedReturnType = expectedReturnType;
            this.givenReturnType = givenReturnType;
        }

        public override string ToString()
        {
            return $"Expected return type: {expectedReturnType}, but given: {givenReturnType}.\n{base.ToString()}";
        }
    }
}