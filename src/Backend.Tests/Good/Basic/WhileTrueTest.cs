using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class WhileTrueTest : CompilerTestBase
    {
        [Test]
        public void TestWhileTrue()
        {
            TestProgram(new TestProgramProviderWhileTrue());
        }
    }
}