using System;
using LatteBase;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class StartingFunctionWrongReturnTypeException : Exception
    {
        private readonly IFunctionDefinition functionDefinition;
        private readonly LatteType expectedType;

        public StartingFunctionWrongReturnTypeException(IFunctionDefinition functionDefinition, LatteType expectedType)
        {
            this.functionDefinition = functionDefinition;
            this.expectedType = expectedType;
        }

        public override string ToString()
        {
            return
                $"STarting function: {functionDefinition.Name} returns {functionDefinition.ReturnType}, expected {expectedType}";
        }
    }
}