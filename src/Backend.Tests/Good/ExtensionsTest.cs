using NUnit.Framework;
using TestPrograms.Extensions;

namespace Backend.Tests.Good
{
    public class ExtensionsTest : CompilerTestBase
    {
        [Test]
        public void TestArray001()
        {
            TestProgram(new TestProgramProviderArray001());
        }
        [Test]
        public void TestArray002()
        {
            TestProgram(new TestProgramProviderArray002());
        }
        [Test]
        public void TestPoints()
        {
            TestProgram(new TestProgramProviderPoints());
        }
        [Test]
        public void TestQueue()
        {
            TestProgram(new TestProgramProviderQueue());
        }
        [Test]
        public void TestCounter()
        {
            TestProgram(new TestProgramProviderCounter());
        }
        [Test]
        public void TestLinked()
        {
            TestProgram(new TestProgramProviderLinked());
        }
        [Test]
        public void TestList()
        {
            TestProgram(new TestProgramProviderList());
        }
        [Test]
        public void TestShapes()
        {
            TestProgram(new TestProgramProviderShapes());
        }
    }
}