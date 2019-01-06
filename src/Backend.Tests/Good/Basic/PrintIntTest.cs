using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class PrintIntTest : CompilerTestBase
    {
        [Test]
        public void TestPrintInt()
        {
            TestProgram(new TestProgramProviderPrintInt());
        }
    }
}