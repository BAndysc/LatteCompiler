using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace TestPrograms.Optimization
{
    public class TestProgramProviderOptimize3 : ITestProgramProvider
    {
        /*
         * int main() {
         *     if (3 < 4)
         *         return 0;
         * }
         */
        public IProgram GetProgram()
        {
            var d = new DummyFilePlace();
            var zero = new IntNode(0, d);
            return new ProgramNode(new FunctionDefinition(d, LatteType.Int, "main",
                new IfNode(d, new CompareNode(RelOperator.LessThan, new IntNode(3, d), new IntNode(4, d), d),
                    new BlockNode(new DummyFilePlace(), new ReturnNode(d, zero)))));
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