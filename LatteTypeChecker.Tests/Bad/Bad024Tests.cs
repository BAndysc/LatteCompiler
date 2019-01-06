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
    public class Bad024Tests
    {
        [Test]
        public void Bad024Test()
        {
            var program = new TestProgramProviderBad024().GetProgram();
            Assert.Catch<ExpectedReturnInFunctionException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}