using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using LatteTypeChecker.Exceptions;
using NUnit.Framework;
using TestPrograms.Bad;

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad020Tests
    {
        [Test]
        public void Bad020Test()
        {
            var program = new TestProgramProviderBad020().GetProgram();
            Assert.Catch<InvalidOperatorUsageException>(() => new StaticAnalysisChecker().Visit(program));
        }
    }
}