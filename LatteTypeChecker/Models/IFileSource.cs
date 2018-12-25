namespace LatteTypeChecker.Models
{
    public interface IFileSource
    {
        int LineNumber { get; }
        string Line { get; }
    }
}