using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core018Test : CompilerTestBase
    {
        [Test]
        public void TestCore018()
        {
            TestProgram(new TestProgramProviderCore018());
        }
        
    }
}