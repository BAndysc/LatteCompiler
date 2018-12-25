using LatteAntlr.AST;
using LatteBase.AST;

namespace LatteAntlr.Exceptions
{
    public class IntegerOutOfRangeException : SyntaxException
    {
        private readonly string number;

        public IntegerOutOfRangeException(string number, IFilePlace filePlace) : base(filePlace)
        {
            this.number = number;
        }

        public override string ToString()
        {
            return $"Number too big for int32 {number}. {base.ToString()}";
        }
    }
}