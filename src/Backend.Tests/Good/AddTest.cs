using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class SimpleAddTest : CompilerTestBase
    {
        [Test]
        public void TestAdd()
        {
            TestProgram(new TestProgramProviderAdd());
        }
    }
}