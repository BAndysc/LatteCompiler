using System;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class RepeatedArgumentNameInFunctionDefinitionException : TypeCheckerException
    {
        private readonly FunctionDefinition function;

        public RepeatedArgumentNameInFunctionDefinitionException(FunctionDefinition function, IFilePlace filePlace) : base(filePlace)
        {
            this.function = function;
        }

        public override string ToString()
        {
            return $"Function {function.Name} has not distinct parameter names: {string.Join(", ", function.ArgumentNames)} {base.ToString()}";
        }
    }
}