using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core010Test : CompilerTestBase
    {
        [Test]
        public void TestCore010()
        {
            TestProgram(new TestProgramProviderCore010());
        }
        
    }
}