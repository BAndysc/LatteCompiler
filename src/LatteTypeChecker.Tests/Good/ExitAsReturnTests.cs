using NUnit.Framework;
using TestPrograms.Good;

namespace LatteTypeChecker.Tests.Good
{
    public class ExitAsReturnTests
    {
        [Test]
        public void ExitAsReturnTest()
        {
            var program = new TestProgramProviderExitAsReturn().GetProgram();
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}