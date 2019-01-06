using System;
using LatteBase.AST;

namespace LatteAntlr.Exceptions
{
    public class SyntaxException : Exception
    {
        private readonly IFilePlace filePlace;

        protected SyntaxException(IFilePlace filePlace)
        {
            this.filePlace = filePlace;
        }

        public override string ToString()
        {
            return $"Here: (line: {filePlace.LineNumber}): {filePlace.Text}";
        }
    }
}