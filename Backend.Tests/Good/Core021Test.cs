using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core021Test : CompilerTestBase
    {
        [Test]
        public void TestCore021()
        {
            TestProgram(new TestProgramProviderCore021());
        }
        
    }
}