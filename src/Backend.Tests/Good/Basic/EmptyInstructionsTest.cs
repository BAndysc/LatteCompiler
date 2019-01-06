using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class EmptyInstructionsTest : CompilerTestBase
    {
        [Test]
        public void TestEmptyInstructions()
        {
            TestProgram(new TestProgramProviderEmptyInstructions());
        }
    }
}