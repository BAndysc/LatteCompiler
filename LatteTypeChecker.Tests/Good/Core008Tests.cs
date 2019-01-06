using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;
using TestPrograms.Good;

namespace LatteTypeChecker.Tests.Good
{
    public class Core008Tests
    {
        [Test]
        public void Core008Test()
        {
            var program = new TestProgramProviderCore008().GetProgram();
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}