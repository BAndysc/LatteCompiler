using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core007Test : CompilerTestBase
    {
        [Test]
        public void TestCore007()
        {
            TestProgram(new TestProgramProviderCore007());
        }
        
    }
}