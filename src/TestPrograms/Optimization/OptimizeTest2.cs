using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace TestPrograms.Optimization
{
    // Those tests would fail if there was no optimization
    // for compile time evaluation of expressions

    public class TestProgramProviderOptimize2 : ITestProgramProvider
    {
        /*
         * int main() {
         *     if (!(true == false))
         *         return 0;
         * }
         */
        public IProgram GetProgram()
        {
            var d = new DummyFilePlace();
            var zero = new IntNode(0, d);
            return new ProgramNode(new FunctionDefinitionNode(d, LatteType.Int, "main",
                new IfNode(d,
                    new LogicalNegateNode(new CompareNode(RelOperator.Equals, new TrueNode(d), new FalseNode(d), d), d),
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