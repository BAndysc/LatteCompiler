using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class FineIdentTest : CompilerTestBase
    {
        [Test]
        public void TestFineIdent()
        {
            TestProgram(new TestProgramProviderFineIdent());
        }
    }
}