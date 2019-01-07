using System;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class ExpectedReturnInFunctionException : TypeCheckerException
    {
        private readonly string function;

        public ExpectedReturnInFunctionException(string function, IFilePlace filePlace) : base(filePlace)
        {
            this.function = function;
        }

        public override string ToString()
        {
            return $"No return in function {function}.\n{base.ToString()}";
        }
    }
}