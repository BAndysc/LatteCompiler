using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core017Test : CompilerTestBase
    {
        [Test]
        public void TestCore017()
        {
            TestProgram(new TestProgramProviderCore017());
        }
        
    }
}