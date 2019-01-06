using NUnit.Framework;
using TestPrograms.Good;
using TestPrograms.Good.Basic;
using TestProgramProviderAdd = TestPrograms.Good.TestProgramProviderAdd;

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