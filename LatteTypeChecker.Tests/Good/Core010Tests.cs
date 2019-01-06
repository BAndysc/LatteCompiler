using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;
using TestPrograms.Good;

namespace LatteTypeChecker.Tests.Good
{
    public class Core010Tests
    {
        [Test]
        public void Core010Test()
        {
            var program = new TestProgramProviderCore010().GetProgram();
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}