using System;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public abstract class TypeCheckerException : Exception
    {
        protected readonly IFilePlace _place;

        protected TypeCheckerException(IFilePlace source)
        {
            _place = source;
        }

        public override string ToString()
        {
            return $"Here (line {_place.LineNumber}): {_place.Text}\n";
        }
    }
}