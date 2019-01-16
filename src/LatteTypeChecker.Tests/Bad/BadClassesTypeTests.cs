using LatteTypeChecker.Exceptions;
using NUnit.Framework;
using TestPrograms.Bad.Classes;

namespace LatteTypeChecker.Tests.Bad
{
    public class BadClassesTypeTests
    {
        [Test]
        public void DuplicateClassesTestCase()
        {
            var test = new BadClassesTests().GetDuplicateClassesTestCase();

            Assert.Catch<DuplicateClassDefinitionException>(() =>
                new StaticAnalysisChecker().Visit(test));
        }
        
        
        [Test]
        public void DuplicateClassFieldsTestCase()
        {
            var test = new BadClassesTests().GetDuplicateFieldTestCase();

            Assert.Catch<DuplicateClassFieldException>(() =>
                new StaticAnalysisChecker().Visit(test));
        }
        
        
        [Test]
        public void InvalidFieldTypeTestCase()
        {
            var test = new BadClassesTests().GetInvalidFieldTypeTestCase();

            Assert.Catch<InvalidVariableTypeException>(() =>
                new StaticAnalysisChecker().Visit(test));
        }
    }
}