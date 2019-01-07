using System;
using LatteBase.AST;

namespace LatteAntlr.Exceptions
{
    public class SyntaxException : Exception
    {
        public readonly IFilePlace FilePlace;

        protected SyntaxException(IFilePlace filePlace)
        {
            this.FilePlace = filePlace;
        }

        public override string ToString()
        {
            return $"Here: (line: {FilePlace.LineNumber}): {FilePlace.Text}\n";
        }
    }
}