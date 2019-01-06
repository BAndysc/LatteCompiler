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
    public class Bad018Tests
    {
        [Test]
        public void Bad018Test()
        {
            var program = new TestProgramProviderBad018().GetProgram();
            Assert.Catch<ArgumentsCountMismatchException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}