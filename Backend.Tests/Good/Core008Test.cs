using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core008Test : CompilerTestBase
    {
        [Test]
        public void TestCore008()
        {
            TestProgram(new TestProgramProviderCore008());
        }
        
    }
}