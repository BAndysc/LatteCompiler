using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // Testing the return checker
// 
// int f () {
//    if (true)
//      return 0;
//    else
//      {}
// }
// 
// int g () {
//   if (false) 
//       {}
//   else
//       return 0;
// }
// 
// void p () {}
//   
// 
// int main() {
//   p();
//   return 0;
// }
// 

namespace TestPrograms.Good
{
    public class TestProgramProviderCore003
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "f", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfElseNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()),
                                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())),
                                new BlockNode(new DummyFilePlace(), new List<IStatement>()
                                {
                                }))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "g", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfElseNode(new DummyFilePlace(), new FalseNode(new DummyFilePlace()), new BlockNode(
                                new DummyFilePlace(), new List<IStatement>()
                                {
                                }), new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Void, "p", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("p", new List<IExpressionNode>() { }, new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
        }
    }
}