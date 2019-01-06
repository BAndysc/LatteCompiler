using System;
using LatteBase;
using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class InvalidVariableTypeException : TypeCheckerException
    {
        private readonly LatteType declarationType;

        public InvalidVariableTypeException(LatteType declarationType, IFilePlace filePlace) : base(filePlace)
        {
            this.declarationType = declarationType;
        }

        public override string ToString()
        {
            return $"Cannot declare variables of type {declarationType}. {base.ToString()}";
        }
    }
}