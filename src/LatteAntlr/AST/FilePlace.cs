using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using LatteBase.AST;

namespace LatteAntlr.AST
{
    internal class FilePlace : IFilePlace
    {
        public int LineNumber { get; }
        public string Text { get; }

        public FilePlace(int line, string text)
        {
            LineNumber = line;
            Text = text;
        }
        
        public FilePlace(ParserRuleContext context)
        {
            LineNumber = context.Start.Line;
            Text = context.Start.InputStream.GetText(new Interval(context.Start.StartIndex, context.Stop.StopIndex));
        }
    }
}