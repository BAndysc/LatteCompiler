using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class WhileTrue2Test : CompilerTestBase
    {
        [Test]
        public void TestWhileTrue2()
        {
            TestProgram(new TestProgramProviderWhileTrue2());
        }
    }
}