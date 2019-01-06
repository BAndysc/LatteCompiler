using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class EmptyIfTest : CompilerTestBase
    {
        [Test]
        public void TestEmptyIf()
        {
            TestProgram(new TestProgramProviderEmptyIf());
        }
    }
}