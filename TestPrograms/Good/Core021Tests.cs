using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
//     if (true) {
//       printInt(1);
//       return 0;
//     }
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderCore021
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()), new BlockNode(
                                new DummyFilePlace(), new List<IStatement>()
                                {
                                    new ExpressionStatementNode(new DummyFilePlace(),
                                        new FunctionCallNode("printInt",
                                            new List<IExpressionNode>() {new IntNode(1, new DummyFilePlace())},
                                            new DummyFilePlace())),
                                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                                }))
                        }))
                });
        }
    }
}