using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core003Test : CompilerTestBase
    {
        [Test]
        public void TestCore003()
        {
            TestProgram(new TestProgramProviderCore003());
        }
        
    }
}