using System;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class StartingFunctionInvalidArgumentsCountException : Exception
    {
        private readonly IFunctionDefinition function;

        public StartingFunctionInvalidArgumentsCountException(IFunctionDefinition function)
        {
            this.function = function;
        }

        public override string ToString()
        {
            return $"Starting function {function.Name} take arguments, shouldn't take any.";
        }
    }
}