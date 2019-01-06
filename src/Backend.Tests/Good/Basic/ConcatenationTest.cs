using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class ConcatenationTest : CompilerTestBase
    {
        [Test]
        public void TestConcatenation()
        {
            TestProgram(new TestProgramProviderConcatenation());
        }
    }
}