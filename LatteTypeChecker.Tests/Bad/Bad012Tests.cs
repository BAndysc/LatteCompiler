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
    public class Bad012Tests
    {
        [Test]
        public void Bad012Test()
        {
            var program = new TestProgramProviderBad012().GetProgram();
            Assert.Catch<ExpectedReturnInFunctionException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}