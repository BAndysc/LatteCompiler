using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class VoidReturnTest : CompilerTestBase
    {
        [Test]
        public void TestVoidReturn()
        {
            TestProgram(new TestProgramProviderVoidReturn());
        }
    }
}