using System;
using LatteBase;
using LatteBase.AST;
using LatteTypeChecker.Models;
using IFunctionDefinition = LatteTypeChecker.Models.IFunctionDefinition;

namespace LatteTypeChecker.Exceptions
{
    public class FunctionCallTypeMismatch : TypeCheckerException
    {
        private readonly IFunctionDefinition function;
        private readonly int argumentIndex;
        private readonly ILatteType givenArgumentType;

        public FunctionCallTypeMismatch(IFunctionDefinition function, int argumentIndex, ILatteType givenArgumentType, IFilePlace filePlace) : base(filePlace)
        {
            this.function = function;
            this.argumentIndex = argumentIndex;
            this.givenArgumentType = givenArgumentType;
        }

        public override string ToString()
        {
            return $"While calling function {function.Name}, for argument no. {argumentIndex} ({function.ArgumentTypes[argumentIndex]} {function.ArgumentNames[argumentIndex]}) given type {givenArgumentType}.\n{base.ToString()}";
        }
    }
}