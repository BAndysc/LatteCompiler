using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class PrintComplicatedStringTest : CompilerTestBase
    {
        [Test]
        public void TestPrintComplicatedString()
        {
            TestProgram(new TestProgramProviderPrintComplicatedString());
        }
    }
}