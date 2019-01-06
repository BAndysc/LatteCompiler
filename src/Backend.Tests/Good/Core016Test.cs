using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core016Test : CompilerTestBase
    {
        [Test]
        public void TestCore016()
        {
            TestProgram(new TestProgramProviderCore016());
        }
        
    }
}