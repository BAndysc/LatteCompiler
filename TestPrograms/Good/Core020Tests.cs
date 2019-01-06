using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
//     p();
//     printInt(1);
//     return 0;
// }
// 
// void p() {}
// 

namespace TestPrograms.Good
{
    public class TestProgramProviderCore020
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("p", new List<IExpressionNode>() { }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new IntNode(1, new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Void, "p", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                        }))
                });
        }
    }
}