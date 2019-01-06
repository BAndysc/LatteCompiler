using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core015Test : CompilerTestBase
    {
        [Test]
        public void TestCore015()
        {
            TestProgram(new TestProgramProviderCore015());
        }
        
    }
}