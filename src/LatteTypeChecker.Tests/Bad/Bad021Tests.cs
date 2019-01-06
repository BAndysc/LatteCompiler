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
    public class Bad021Tests
    {
        [Test]
        public void Bad021Test()
        {
            var program = new TestProgramProviderBad021().GetProgram();
            Assert.Catch<ExpectedReturnInFunctionException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}