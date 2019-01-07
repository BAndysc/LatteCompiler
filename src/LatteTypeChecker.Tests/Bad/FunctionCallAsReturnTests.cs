using LatteTypeChecker.Exceptions;
using NUnit.Framework;
using TestPrograms.Bad;

namespace LatteTypeChecker.Tests.Bad
{
    public class FunctionCallAsReturnTests
    {
        [Test]
        public void FunctionCallAsReturnTest()
        {
            var program = new TestProgramProviderFunctionCallAsReturn().GetProgram();
            Assert.Catch<ExpectedReturnInFunctionException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}