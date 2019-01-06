using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core006Test : CompilerTestBase
    {
        [Test]
        public void TestCore006()
        {
            TestProgram(new TestProgramProviderCore006());
        }
        
    }
}