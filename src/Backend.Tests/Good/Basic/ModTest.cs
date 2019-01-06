using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class ModTest : CompilerTestBase
    {
        [Test]
        public void TestMod()
        {
            TestProgram(new TestProgramProviderMod());
        }
    }
}