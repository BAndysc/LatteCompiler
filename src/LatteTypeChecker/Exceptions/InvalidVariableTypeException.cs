using System;
using LatteBase;
using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class InvalidVariableTypeException : TypeCheckerException
    {
        private readonly ILatteType declarationType;

        public InvalidVariableTypeException(ILatteType declarationType, IFilePlace filePlace) : base(filePlace)
        {
            this.declarationType = declarationType;
        }

        public override string ToString()
        {
            return $"Cannot declare variables of type {declarationType}.\n{base.ToString()}";
        }
    }
}