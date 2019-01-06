using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class BoolOveroptymizationTest : CompilerTestBase
    {
        [Test]
        public void TestBoolOveroptymization()
        {
            TestProgram(new TestProgramProviderBoolOveroptymization());
        }
    }
}