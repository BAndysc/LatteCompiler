using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// int main()
// {
//     exit();
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderExitAsReturn : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", 
                new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "error"))));
        }

        public string GetOutput()
        {
            return "";
        }

        public string GetInput()
        {
            return null;
        }
    }
}