using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace TestPrograms.Good
{
    public class TestProgramProviderAdd : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                    new BlockNode(new DummyFilePlace(),
                        new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new BinaryNode(BinaryOperator.Add,
                                    new IntNode(1, new DummyFilePlace()),
                                    new IntNode(1, new DummyFilePlace()),
                                    new DummyFilePlace()))),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                    ))
            );
        }

        public string GetOutput()
        {
            return "2\n";
        }

        public string GetInput()
        {
            return null;
        }
    }
    
    
    
}