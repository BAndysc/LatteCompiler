using LatteBase.AST;

namespace TestPrograms
{
    public interface ITestProgramProvider
    {
        IProgram GetProgram();
        string GetOutput();
        string GetInput();
    }
}