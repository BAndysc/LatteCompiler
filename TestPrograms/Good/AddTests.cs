using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace TestPrograms.Good
{
    public class TestProgramProviderAdd
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<ITopFunctionNode>()
            {
                new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                    new BlockNode(new DummyFilePlace(), new List<IStatement>()
                    {
                        new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printInt",
                            new List<IExpressionNode>()
                            {
                                new BinaryNode(BinaryOperator.Add,
                                    new IntNode(1, new DummyFilePlace()),
                                    new IntNode(1, new DummyFilePlace()),
                                    new DummyFilePlace())
                            }, new DummyFilePlace())),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                    }))
            });
        }
    }

}