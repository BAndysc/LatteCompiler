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
    public class Bad008Tests
    {
        [Test]
        public void Bad008Test()
        {
            var program = new TestProgramProviderBad008().GetProgram();
            Assert.Catch<ExpectedReturnInFunctionException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}