using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core001Test : CompilerTestBase
    {

        [Test]
        public void TestCore001()
        {
            TestProgram(new TestProgramProviderCore001());
        }
        
    }
}