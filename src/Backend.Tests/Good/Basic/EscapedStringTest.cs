using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class EscapedStringTest : CompilerTestBase
    {
        [Test]
        public void TestEscapedString()
        {
            TestProgram(new TestProgramProviderEscapedString());
        }
    }
}