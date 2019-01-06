using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class EmptyWhileTest : CompilerTestBase
    {
        [Test]
        public void TestEmptyWhile()
        {
            TestProgram(new TestProgramProviderEmptyWhile());
        }
    }
}