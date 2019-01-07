using System;
using LatteBase.AST;

namespace LatteAntlr.Exceptions
{
    public class ParserException : SyntaxException
    {
        private Exception innerException;
        
        public ParserException(Exception exception, IFilePlace filePlace) : base(filePlace)
        {
            innerException = exception;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + innerException.Message;
        }
    }
}