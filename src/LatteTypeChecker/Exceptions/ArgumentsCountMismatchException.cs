using System;
using LatteBase.AST;
using LatteTypeChecker.Models;
using IFunctionDefinition = LatteTypeChecker.Models.IFunctionDefinition;

namespace LatteTypeChecker.Exceptions
{
    public class ArgumentsCountMismatchException : TypeCheckerException
    {
        private readonly IFunctionDefinition function;
        private readonly int givenCount;

        public ArgumentsCountMismatchException(IFunctionDefinition function, int givenCount, IFilePlace filePlace) : base(filePlace)
        {
            this.function = function;
            this.givenCount = givenCount;
        }

        public override string ToString()
        {
            return
                $"Function {function.Name} takes {function.ArgumentTypes.Count} arguments, but {givenCount} given.\n{base.ToString()}";
        }
    }
}