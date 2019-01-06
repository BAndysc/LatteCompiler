using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core022Test : CompilerTestBase
    {
        [Test]
        public void TestCore022()
        {
            TestProgram(new TestProgramProviderCore022());
        }
    }
}