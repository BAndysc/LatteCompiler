using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;
using TestPrograms.Good;

namespace LatteTypeChecker.Tests.Good
{
    public class Core022Tests
    {
        [Test]
        public void Core022Test()
        {
            var program = new TestProgramProviderCore022().GetProgram();
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}