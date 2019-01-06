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
    public class Bad007Tests
    {
        [Test]
        public void Bad007Test()
        {
            var program = new TestProgramProviderBad007().GetProgram();
            Assert.Catch<VariableRedefinitionException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}