using System;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class ExpectedReturnInFunctionException : TypeCheckerException
    {
        private readonly IFunctionDefinition function;

        public ExpectedReturnInFunctionException(IFunctionDefinition function, IFilePlace filePlace) : base(filePlace)
        {
            this.function = function;
        }

        public override string ToString()
        {
            return $"No return in function {function.Name}. {base.ToString()}";
        }
    }
}