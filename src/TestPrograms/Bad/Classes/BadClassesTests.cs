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
            return new ProgramNode(new List<IFunctionDefinitionNode>(),
                new List<IClassDefinitionNode>()
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "MyClass", null),
                    new ClassDefinitionNode(new DummyFilePlace(), "MyClass", null),
                });
        
        }

        public IProgram GetDuplicateFieldTestCase()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>(),
                new List<IClassDefinitionNode>()
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "MyClass", null,null,
                        new ClassFieldNode(new DummyFilePlace(), "a", LatteType.Int), 
                        new ClassFieldNode(new DummyFilePlace(), "a", LatteType.Int)),
                });
        
        }

        public IProgram GetInvalidFieldTypeTestCase()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>(),
                new List<IClassDefinitionNode>()
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "MyClass", null, null,
                        new ClassFieldNode(new DummyFilePlace(), "a", LatteType.Void))
                });
        }

        public IProgram GetOverrideChangeTypeTestCase()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>()
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main",
                        new ReturnNode(new DummyFilePlace(), new IntNode(5, new DummyFilePlace())))
                },
                new List<IClassDefinitionNode>()
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "MyClass", null, new List<IFunctionDefinitionNode>()
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), 
                            LatteType.Int, "func", new EmptyNode(new DummyFilePlace()))   
                    }),
                    new ClassDefinitionNode(new DummyFilePlace(), "MySubClass", "MyClass", new []
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), 
                            LatteType.String, "func", new EmptyNode(new DummyFilePlace())), 
                    })
                });
        }

    }
}