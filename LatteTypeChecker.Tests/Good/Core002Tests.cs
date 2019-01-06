using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;
using TestPrograms.Good;

namespace LatteTypeChecker.Tests.Good
{
    public class Core002Tests
    {
        [Test]
        public void Core002Test()
        {
            var program = new TestProgramProviderCore002().GetProgram();
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}