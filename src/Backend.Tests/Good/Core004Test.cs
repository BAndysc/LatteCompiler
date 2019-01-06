using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core004Test : CompilerTestBase
    {
        [Test]
        public void TestCore004()
        {
            TestProgram(new TestProgramProviderCore004());
        }
        
    }
}