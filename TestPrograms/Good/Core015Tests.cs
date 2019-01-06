using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* parity of positive integers by recursion */
// 
// int main () {
//   printInt(ev(17)) ;
//   return 0 ;
// }
// 
// int ev (int y) {
//   if (y > 0)
//     return ev (y-2) ;
//   else
//     if (y < 0)
//       return 0 ;
//     else
//       return 1 ;
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderCore015
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("ev",
                                            new List<IExpressionNode>() {new IntNode(17, new DummyFilePlace())},
                                            new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "ev",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "y")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                    new VariableNode("y", new DummyFilePlace()),
                                    new IntNode(0, new DummyFilePlace()),
                                    new DummyFilePlace()), new ReturnNode(new DummyFilePlace(), new FunctionCallNode(
                                    "ev", new List<IExpressionNode>()
                                    {
                                        new BinaryNode(BinaryOperator.Sub,
                                            new VariableNode("y", new DummyFilePlace()),
                                            new IntNode(2, new DummyFilePlace()),
                                            new DummyFilePlace())
                                    }, new DummyFilePlace())), new IfElseNode(new DummyFilePlace(), new CompareNode(
                                        RelOperator.LessThan,
                                        new VariableNode("y", new DummyFilePlace()),
                                        new IntNode(0, new DummyFilePlace()),
                                        new DummyFilePlace()),
                                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())),
                                    new ReturnNode(new DummyFilePlace(), new IntNode(1, new DummyFilePlace()))))
                            }))
                });
        }
    }
}