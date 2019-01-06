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
    public class Bad017Tests
    {
        [Test]
        public void Bad017Test()
        {
            var program = new TestProgramProviderBad017().GetProgram();
            Assert.Catch<ArgumentsCountMismatchException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}