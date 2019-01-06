using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* Test boolean operators. */
// 
// int main() {
//   printString("&&");
//   printBool(test(-1) && test(0));
//   printBool(test(-2) && test(1));
//   printBool(test(3) && test(-5));
//   printBool(test(234234) && test(21321));
//   printString("||");
//   printBool(test(-1) || test(0));
//   printBool(test(-2) || test(1));
//   printBool(test(3) || test(-5));
//   printBool(test(234234) || test(21321));
//   printString("!");
//   printBool(true);
//   printBool(false);
//   return 0 ;
// 
// }
// 
// void printBool(boolean b) {
//   if (!b) {
//     printString("false");
//   } else {
//     printString("true");
//  }
//  return;
// }
// 
// boolean test(int i) {
//   printInt(i);
//   return i > 0;
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderCore013
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printString",
                                    new List<IExpressionNode>() {new StringNode("&&", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new AndNode(
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>()
                                            {
                                                new NegateNode(new IntNode(1, new DummyFilePlace()),
                                                    new DummyFilePlace())
                                            }, new DummyFilePlace()),
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>() {new IntNode(0, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new AndNode(
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>()
                                            {
                                                new NegateNode(new IntNode(2, new DummyFilePlace()),
                                                    new DummyFilePlace())
                                            }, new DummyFilePlace()),
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>() {new IntNode(1, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new AndNode(
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>() {new IntNode(3, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>()
                                            {
                                                new NegateNode(new IntNode(5, new DummyFilePlace()),
                                                    new DummyFilePlace())
                                            }, new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new AndNode(
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>() {new IntNode(234234, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>() {new IntNode(21321, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printString",
                                    new List<IExpressionNode>() {new StringNode("||", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new OrNode(
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>()
                                            {
                                                new NegateNode(new IntNode(1, new DummyFilePlace()),
                                                    new DummyFilePlace())
                                            }, new DummyFilePlace()),
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>() {new IntNode(0, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new OrNode(
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>()
                                            {
                                                new NegateNode(new IntNode(2, new DummyFilePlace()),
                                                    new DummyFilePlace())
                                            }, new DummyFilePlace()),
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>() {new IntNode(1, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new OrNode(
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>() {new IntNode(3, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>()
                                            {
                                                new NegateNode(new IntNode(5, new DummyFilePlace()),
                                                    new DummyFilePlace())
                                            }, new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new OrNode(
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>() {new IntNode(234234, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new FunctionCallNode("test",
                                            new List<IExpressionNode>() {new IntNode(21321, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printString",
                                    new List<IExpressionNode>() {new StringNode("!", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printBool",
                                    new List<IExpressionNode>() {new TrueNode(new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printBool",
                                    new List<IExpressionNode>() {new FalseNode(new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Void, "printBool",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Bool, "b")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new IfElseNode(new DummyFilePlace(),
                                    new LogicalNegateNode(new VariableNode("b", new DummyFilePlace()), new DummyFilePlace()),
                                    new BlockNode(new DummyFilePlace(), new List<IStatement>()
                                    {
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode("printString",
                                                new List<IExpressionNode>()
                                                    {new StringNode("false", new DummyFilePlace())},
                                                new DummyFilePlace()))
                                    }), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                                    {
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode("printString",
                                                new List<IExpressionNode>()
                                                    {new StringNode("true", new DummyFilePlace())},
                                                new DummyFilePlace()))
                                    })),
                                new VoidReturnNode(new DummyFilePlace())
                            })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Bool, "test",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "i")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                        new DummyFilePlace())),
                                new ReturnNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                    new VariableNode("i", new DummyFilePlace()),
                                    new IntNode(0, new DummyFilePlace()),
                                    new DummyFilePlace()))
                            }))
                });
        }
    }
}