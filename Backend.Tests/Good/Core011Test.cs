using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core011Test : CompilerTestBase
    {
        [Test]
        public void TestCore011()
        {
            TestProgram(new TestProgramProviderCore011());
        }
        
    }
}