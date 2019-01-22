using NUnit.Framework;
using TestPrograms.Community;

namespace Backend.Tests.Good
{
    public class CommunityTests : CompilerTestBase
    {
        [Test]
        public void BfsTest()
        {
            TestProgram(new TestProgramProviderBfs());
        }
        
        [Test]
        public void CalculatorTest()
        {
            TestProgram(new TestProgramProviderCalculator());
        }
        
        [Test]
        public void Heapsort2Test()
        {
            TestProgram(new TestProgramProviderHeapsort2());
        }
        
        [Test]
        public void ListTest()
        {
            TestProgram(new TestProgramProviderList());
        }
        
        [Test]
        public void MergeSortTest()
        {
            TestProgram(new TestProgramProviderMergeSort());
        }
    }
}