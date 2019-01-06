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
    public class Bad013Tests
    {
        [Test]
        public void Bad013Test()
        {
            var program = new TestProgramProviderBad013().GetProgram();
            Assert.Catch<InvalidOperatorUsageException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}