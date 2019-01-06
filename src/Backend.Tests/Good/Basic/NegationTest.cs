using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class NegationTest : CompilerTestBase
    {
        [Test]
        public void TestNegation()
        {
            TestProgram(new TestProgramProviderNegation());
        }
    }
}