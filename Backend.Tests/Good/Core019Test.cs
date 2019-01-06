using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core019Test : CompilerTestBase
    {
        [Test]
        public void TestCore019()
        {
            TestProgram(new TestProgramProviderCore019());
        }
        
    }
}