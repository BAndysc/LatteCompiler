using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core009Test : CompilerTestBase
    {
        [Test]
        public void TestCore009()
        {
            TestProgram(new TestProgramProviderCore009());
        }
        
    }
}