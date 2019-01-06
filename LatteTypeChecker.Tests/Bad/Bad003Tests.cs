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
    public class Bad003Tests
    {
        [Test]
        public void Bad003Test()
        {
            var program = new TestProgramProviderBad003().GetProgram();
            Assert.Catch<RepeatedArgumentNameInFunctionDefinitionException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}