using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class AddTest : CompilerTestBase
    {
        [Test]
        public void TestAdd()
        {
            TestProgram(new TestProgramProviderAddBasic());
        }
    }
}