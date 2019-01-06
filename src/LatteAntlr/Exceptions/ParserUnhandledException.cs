using System;
using System.Text;

namespace LatteAntlr.Exceptions
{
    internal class ParserUnhandledException : Exception
    {
        private int line;
        private Type type;
        private string text;
        
        public ParserUnhandledException(int line, Type type, string text)
        {
            this.line = line;
            this.type = type;
            this.text = text;
        }

        public override string ToString()
        {
            return $"Unhandled at line: {line} ({type.FullName}): {indentText(text, 4)}";
        }

        private string indentText(string str, int spaces)
        {
            string[] lines = str.Split('\n');

            StringBuilder space = new StringBuilder();

            for (int i = 0; i < spaces; ++i)
                space.Append(" ");

            return string.Join($"\n{space}", lines);
        }
    }
}