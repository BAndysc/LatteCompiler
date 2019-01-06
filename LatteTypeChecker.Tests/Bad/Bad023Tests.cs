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
    public class Bad023Tests
    {
        [Test]
        public void Bad023Test()
        {
            var program = new TestProgramProviderBad023().GetProgram();
            Assert.Catch<VariableDeclarationTypeMismatch>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}