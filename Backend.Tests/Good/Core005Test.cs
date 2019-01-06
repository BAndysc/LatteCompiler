using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core005Test : CompilerTestBase
    {
        [Test]
        public void TestCore005()
        {
            TestProgram(new TestProgramProviderCore005());
        }
        
    }
}