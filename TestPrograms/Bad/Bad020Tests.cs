using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // Compare string with boolean.
// 
// int main() {
//   if ("true" == true) {
//    printString("foo");
//   }
//   return 0 ;
// }

namespace TestPrograms.Bad
{
    public class TestProgramProviderBad020
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                new StringNode("true", new DummyFilePlace()),
                                new TrueNode(new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printString",
                                        new List<IExpressionNode>() {new StringNode("foo", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            })),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
        }
    }
}