using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;
using TestPrograms.Good;

namespace LatteTypeChecker.Tests.Good
{
    public class Core005Tests
    {
        [Test]
        public void Core005Test()
        {
            var program = new TestProgramProviderCore005().GetProgram();
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}