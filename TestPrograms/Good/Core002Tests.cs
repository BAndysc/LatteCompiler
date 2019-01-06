using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* void expression as statement */
// 
// int main() {
//   foo();
//   return 0 ;
// 
// }
// 
// void foo() {
//    printString("foo");
//    return;
// }
// 

namespace TestPrograms.Good
{
    public class TestProgramProviderCore002 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("foo", new List<IExpressionNode>() { }, new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Void, "foo", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printString",
                                    new List<IExpressionNode>() {new StringNode("foo", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new VoidReturnNode(new DummyFilePlace())
                        }))
                });
            
        }

        public string GetOutput()
        {
            return "foo\n";
        }

        public string GetInput()
        {
            return null;
        }
    }
}