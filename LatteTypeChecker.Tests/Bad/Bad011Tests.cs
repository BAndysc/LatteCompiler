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
    public class Bad011Tests
    {
        [Test]
        public void Bad011Test()
        {
            var program = new TestProgramProviderBad011().GetProgram();
            Assert.Catch<InvalidReturnTypeException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}