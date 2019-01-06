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
    public class Bad026Tests
    {
        [Test]
        public void Bad026Test()
        {
            var program = new TestProgramProviderBad026().GetProgram();
            Assert.Catch<TypeMismatchException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}