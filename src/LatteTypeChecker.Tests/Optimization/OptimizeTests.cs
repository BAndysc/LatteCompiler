using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using NUnit.Framework;
using TestPrograms.Optimization;

namespace LatteTypeChecker.Tests.Optimization
{
    // Those tests would fail if there was no optimization
    // for compile time evaluation of expressions
    public class OptimizeTests
    {
        [Test]
        public void Test1()
        {
            var program = new TestProgramProviderOptimize1().GetProgram();
            
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
        
        [Test]
        public void Test2()
        {
            var program = new TestProgramProviderOptimize2().GetProgram();
            
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
        
        [Test]
        public void Test3()
        {
            var program = new TestProgramProviderOptimize3().GetProgram();
            
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}