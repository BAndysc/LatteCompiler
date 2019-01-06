using NUnit.Framework;
using TestPrograms.Good.Basic;

namespace Backend.Tests.Good.Basic
{
    public class FibonacciTest : CompilerTestBase
    {
        [Test]
        public void TestFibonacci()
        {
            TestProgram(new TestProgramProviderFibonacci());
        }
    }
}