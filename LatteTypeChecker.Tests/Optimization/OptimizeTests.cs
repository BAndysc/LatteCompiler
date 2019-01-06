using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using NUnit.Framework;

namespace LatteTypeChecker.Tests.Optimization
{
    // Those tests would fail if there was no optimization
    // for compile time evaluation of expressions
    public class OptimizeTests
    {
        /*
         * int main() {
         *     if (true)
         *         return 0;
         * }
         */
        [Test]
        public void Test1()
        {
            var d = new DummyFilePlace();
            var zero = new IntNode(0, d);
            var program = new ProgramNode(new TopFunctionNode(d, LatteType.Int, "main",
                new IfNode(d, new TrueNode(d), new ReturnNode(d, zero))));
            
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
        
        /*
         * int main() {
         *     if (!(true == false))
         *         return 0;
         * }
         */
        [Test]
        public void Test2()
        {
            var d = new DummyFilePlace();
            var zero = new IntNode(0, d);
            var program = new ProgramNode(new TopFunctionNode(d, LatteType.Int, "main",
                new IfNode(d, new LogicalNegateNode(new CompareNode(RelOperator.Equals, new TrueNode(d), new FalseNode(d), d), d), new ReturnNode(d, zero))));
            
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
        
        /*
         * int main() {
         *     if (3 < 4)
         *         return 0;
         * }
         */
        [Test]
        public void Test3()
        {
            var d = new DummyFilePlace();
            var zero = new IntNode(0, d);
            var program = new ProgramNode(new TopFunctionNode(d, LatteType.Int, "main",
                new IfNode(d, new CompareNode(RelOperator.LessThan, new IntNode(3, d), new IntNode(4, d), d), new ReturnNode(d, zero))));
            
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}