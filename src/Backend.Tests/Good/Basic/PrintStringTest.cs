using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class PrintStringTest : CompilerTestBase
    {
        [Test]
        public void TestPrintString()
        {
            TestProgram(new TestProgramProviderPrintString());
        }
    }
}