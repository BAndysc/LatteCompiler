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
        
        [Test]
        public void ForeachTestCase()
        {
            TestProgram(new TestProgramProviderForeach());
        }
        [Test]
        public void StructDecrementIncrementTestCase()
        {
            TestProgram(new TestProgramProviderStructDecrementIncrement());
        }
        
        [Test]
        public void StringComparisonTestCase()
        {
            TestProgram(new TestProgramProviderStringCompare());
        }

        
    }
}