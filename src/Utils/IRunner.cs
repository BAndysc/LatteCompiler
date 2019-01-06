namespace Utils
{
    public interface IRunner
    {
        bool Run(string command, string arguments, out string standardOut, string[] inputs = null);
    }
}