using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class BoolOperationsTest : CompilerTestBase
    {
        [Test]
        public void TestBoolOperations()
        {
            TestProgram(new TestProgramProviderBoolOperations());
        }
    }
}