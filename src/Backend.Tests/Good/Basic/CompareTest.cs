using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class CompareTest : CompilerTestBase
    {
        [Test]
        public void TestCompare()
        {
            TestProgram(new TestProgramProviderCompare());
        }
    }
}