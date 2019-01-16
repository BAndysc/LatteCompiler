using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace TestPrograms.Bad.Classes
{
    public class BadClassesTests
    {
        public IProgram GetDuplicateClassesTestCase()
        {
            return new ProgramNode(new List<IFunctionDefinition>(),
                new List<IClassDefinitionNode>()
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "MyClass"),
                    new ClassDefinitionNode(new DummyFilePlace(), "MyClass"),
                });
        
        }

        public IProgram GetDuplicateFieldTestCase()
        {
            return new ProgramNode(new List<IFunctionDefinition>(),
                new List<IClassDefinitionNode>()
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "MyClass", 
                        new ClassFieldNode(new DummyFilePlace(), "a", LatteType.Int), 
                        new ClassFieldNode(new DummyFilePlace(), "a", LatteType.Int)),
                });
        
        }

        public IProgram GetInvalidFieldTypeTestCase()
        {
            return new ProgramNode(new List<IFunctionDefinition>(),
                new List<IClassDefinitionNode>()
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "MyClass",
                        new ClassFieldNode(new DummyFilePlace(), "a", LatteType.Void))
                });
        
        }

    }
}