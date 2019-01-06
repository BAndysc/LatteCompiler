using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core012Test : CompilerTestBase
    {
        [Test]
        public void TestCore012()
        {
            TestProgram(new TestProgramProviderCore012());
        }
        
    }
}