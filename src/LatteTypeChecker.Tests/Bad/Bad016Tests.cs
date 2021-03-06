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
    public class Bad016Tests
    {
        [Test]
        public void Bad016Test()
        {
            var program = new TestProgramProviderBad016().GetProgram();
            Assert.Catch<FunctionCallTypeMismatch>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}