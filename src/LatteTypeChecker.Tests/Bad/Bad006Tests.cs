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
    public class Bad006Tests
    {
        [Test]
        public void Bad006Test()
        {
            var program = new TestProgramProviderBad006().GetProgram();
            Assert.Catch<UndeclaredVariableException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}