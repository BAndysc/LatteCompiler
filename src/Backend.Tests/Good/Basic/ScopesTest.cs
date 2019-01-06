using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class ScopesTest : CompilerTestBase
    {
        [Test]
        public void TestScopes()
        {
            TestProgram(new TestProgramProviderScopes());
        }
    }
}