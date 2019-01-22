using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class ComplexTest : CompilerTestBase
    {
        [Test]
        public void ComplexTestCase()
        {
            TestProgram(new ComplexTestProvider());
        }
    }
}