namespace LatteBase.AST
{
    public interface IFilePlace
    {
        int LineNumber { get; }
        string Text { get; }
    }
}