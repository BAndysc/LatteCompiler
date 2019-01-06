using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core013Test : CompilerTestBase
    {
        [Test]
        public void TestCore013()
        {
            TestProgram(new TestProgramProviderCore013());
        }
        
    }
}