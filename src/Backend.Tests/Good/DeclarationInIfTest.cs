using NUnit.Framework;
using TestPrograms.Good;

namespace Backend.Tests.Good
{
    public class DeclarationInIfTest : CompilerTestBase
    {
        [Test]
        public void TestDeclarationInIf()
        {
            TestProgram(new TestProgramProviderDeclarationInIfTest());
        }
    }
}