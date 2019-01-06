using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace TestPrograms.Optimization
{
    public class TestProgramProviderOptimize1
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
            return new ProgramNode(new TopFunctionNode(d, LatteType.Int, "main",
                new IfNode(d, new TrueNode(d), new ReturnNode(d, zero))));
        }
    }
}