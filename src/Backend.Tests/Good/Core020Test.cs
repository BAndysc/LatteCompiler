using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class Core020Test : CompilerTestBase
    {
        [Test]
        public void TestCore020()
        {
            TestProgram(new TestProgramProviderCore020());
        }
        
    }
}