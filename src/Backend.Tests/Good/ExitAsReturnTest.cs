using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class ExitAsReturnTest : CompilerTestBase
    {
        [Test]
        public void TestExitAsReturn()
        {
            TestProgram(new TestProgramProviderExitAsReturn());
        }
    }
}