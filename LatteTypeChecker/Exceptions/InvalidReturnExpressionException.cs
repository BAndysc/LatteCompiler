using System;
using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class InvalidReturnExpressionException : TypeCheckerException
    {
        public InvalidReturnExpressionException(IFilePlace filePlace) : base(filePlace)
        {
        }

        public override string ToString()
        {
            return $"Return without expression expected. {base.ToString()}";
        }
    }
}