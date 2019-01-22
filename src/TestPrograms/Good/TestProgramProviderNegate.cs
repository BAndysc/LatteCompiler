using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace TestPrograms.Good
{
    public class TestProgramProviderNegate : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                    new BlockNode(new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int, new SingleDeclaration("a", null), new SingleDeclaration("b", null)),
                        new AssignmentNode(new DummyFilePlace(), "b", new NegateNode(new VariableNode("a", new DummyFilePlace()), new DummyFilePlace())),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                    ))
            );
        }

        public string GetOutput()
        {
            return "";
        }

        public string GetInput()
        {
            return null;
        }
    }
}