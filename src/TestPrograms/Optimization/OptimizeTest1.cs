using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace TestPrograms.Optimization
{
    public class TestProgramProviderOptimize1 : ITestProgramProvider
    {
        /*
         * int main() {
         *     if (true)
         *         return 0;
         * }
         */
        public IProgram GetProgram()
        {
            var d = new DummyFilePlace();
            var zero = new IntNode(0, d);
            return new ProgramNode(new FunctionDefinition(d, LatteType.Int, "main",
                new BlockNode(new DummyFilePlace(), new IfNode(d, new TrueNode(d), new BlockNode(new DummyFilePlace(), new ReturnNode(d, zero))))));
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