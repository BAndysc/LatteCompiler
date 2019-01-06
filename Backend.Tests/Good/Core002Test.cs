using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core002Test : CompilerTestBase
    {
        [Test]
        public void TestCore002()
        {
            TestProgram(new TestProgramProviderCore002());
        }
        
    }
}