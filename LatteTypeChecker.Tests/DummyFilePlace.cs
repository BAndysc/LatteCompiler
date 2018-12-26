using LatteBase.AST;

namespace LatteTypeChecker.Tests
{
    internal class DummyFilePlace : IFilePlace
    {
        public int LineNumber { get; }
        public string Text { get; }
    }
}