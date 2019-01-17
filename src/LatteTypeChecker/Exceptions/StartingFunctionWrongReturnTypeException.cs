using System;
using LatteBase;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class StartingFunctionWrongReturnTypeException : Exception
    {
        private readonly IFunctionDefinition functionDefinition;
        private readonly ILatteType expectedType;

        public StartingFunctionWrongReturnTypeException(IFunctionDefinition functionDefinition, ILatteType expectedType)
        {
            this.functionDefinition = functionDefinition;
            this.expectedType = expectedType;
        }

        public override string ToString()
        {
            return
                $"Starting function: {functionDefinition.Name} returns {functionDefinition.ReturnType}, expected {expectedType}";
        }
    }
}