using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace TestPrograms.Optimization
{
    public class TestProgramProviderOptimize3
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
            return new ProgramNode(new TopFunctionNode(d, LatteType.Int, "main",
                new IfNode(d, new CompareNode(RelOperator.LessThan, new IntNode(3, d), new IntNode(4, d), d), new ReturnNode(d, zero))));
        }
    }
}