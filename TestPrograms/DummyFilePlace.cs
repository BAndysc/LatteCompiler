using LatteBase.AST;

namespace TestPrograms
{
    internal class DummyFilePlace : IFilePlace
    {
        public int LineNumber { get; }
        public string Text { get; }
    }
}