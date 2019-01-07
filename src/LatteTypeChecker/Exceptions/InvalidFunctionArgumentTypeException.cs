using System;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class InvalidFunctionArgumentTypeException : TypeCheckerException
    {
        private readonly IFunctionDefinition function;
        private readonly IFunctionArgument argument;

        public InvalidFunctionArgumentTypeException(IFunctionDefinition function, IFunctionArgument argument, IFilePlace filePlace) : base(filePlace)
        {
            this.function = function;
            this.argument = argument;
        }

        public override string ToString()
        {
            return $"Invalid argument type in function {function.Name}: {argument.Name} has invalid type {argument.Type}.\n{base.ToString()}";
        }
    }
}