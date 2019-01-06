using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core014Test : CompilerTestBase
    {
        [Test]
        public void TestCore014()
        {
            TestProgram(new TestProgramProviderCore014());
        }
    }
}