using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* Test boolean operators */
// 
// int main () {
//   int x = 4;
//   if (3 <= x && 4 != 2 && true) {
//     printBool(true);
//   } else {
//     printString("apa");
//   }
// 
//   printBool(true == true || dontCallMe(1));
//   printBool(4 < -5 && dontCallMe(2));
// 
//   printBool(4 == x && true == !false && true);
// 
//   printBool(implies(false,false));
//   printBool(implies(false,true));
//   printBool(implies(true,false));
//   printBool(implies(true,true));
//   return 0 ;
// 
// }
// 
// boolean dontCallMe(int x) {
//   printInt(x);
//   return true;
// }
// 
// void printBool(boolean b) {
//   if (b) {
//     printString("true");
//   } else {
//     printString("false");
//  }
//  return;
// }
// 
// boolean implies(boolean x, boolean y) {
//   return !x || x == y;
// }
// 

namespace LatteTypeChecker.Tests.Good
{
    public class Core017Tests
    {
        [Test]
        public void Core017Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                    {new SingleDeclaration("x", new IntNode(4, new DummyFilePlace()))}),
                            new IfElseNode(new DummyFilePlace(), new AndNode(
                                new CompareNode(RelOperator.LessEquals,
                                    new IntNode(3, new DummyFilePlace()),
                                    new VariableNode("x", new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new AndNode(
                                    new CompareNode(RelOperator.NotEquals,
                                        new IntNode(4, new DummyFilePlace()),
                                        new IntNode(2, new DummyFilePlace()),
                                        new DummyFilePlace()),
                                    new TrueNode(new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printBool",
                                        new List<IExpressionNode>() {new TrueNode(new DummyFilePlace())},
                                        new DummyFilePlace()))
                            }), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printString",
                                        new List<IExpressionNode>() {new StringNode("apa", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            })),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new OrNode(
                                        new CompareNode(RelOperator.Equals,
                                            new TrueNode(new DummyFilePlace()),
                                            new TrueNode(new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new FunctionCallNode("dontCallMe",
                                            new List<IExpressionNode>() {new IntNode(1, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new AndNode(
                                        new CompareNode(RelOperator.LessThan,
                                            new IntNode(4, new DummyFilePlace()),
                                            new NegateNode(new IntNode(5, new DummyFilePlace()), new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new FunctionCallNode("dontCallMe",
                                            new List<IExpressionNode>() {new IntNode(2, new DummyFilePlace())},
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new AndNode(
                                        new CompareNode(RelOperator.Equals,
                                            new IntNode(4, new DummyFilePlace()),
                                            new VariableNode("x", new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new AndNode(
                                            new CompareNode(RelOperator.Equals,
                                                new TrueNode(new DummyFilePlace()),
                                                new NegateNode(new FalseNode(new DummyFilePlace()),
                                                    new DummyFilePlace()),
                                                new DummyFilePlace()),
                                            new TrueNode(new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printBool",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("implies",
                                            new List<IExpressionNode>()
                                            {
                                                new FalseNode(new DummyFilePlace()), new FalseNode(new DummyFilePlace())
                                            }, new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printBool",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("implies",
                                            new List<IExpressionNode>()
                                            {
                                                new FalseNode(new DummyFilePlace()), new TrueNode(new DummyFilePlace())
                                            }, new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printBool",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("implies",
                                            new List<IExpressionNode>()
                                            {
                                                new TrueNode(new DummyFilePlace()), new FalseNode(new DummyFilePlace())
                                            }, new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printBool",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("implies",
                                            new List<IExpressionNode>()
                                            {
                                                new TrueNode(new DummyFilePlace()), new TrueNode(new DummyFilePlace())
                                            }, new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Bool, "dontCallMe",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "x")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("x", new DummyFilePlace())},
                                        new DummyFilePlace())),
                                new ReturnNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()))
                            })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Void, "printBool",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Bool, "b")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new IfElseNode(new DummyFilePlace(), new VariableNode("b", new DummyFilePlace()),
                                    new BlockNode(new DummyFilePlace(), new List<IStatement>()
                                    {
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode("printString",
                                                new List<IExpressionNode>()
                                                    {new StringNode("true", new DummyFilePlace())},
                                                new DummyFilePlace()))
                                    }), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                                    {
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode("printString",
                                                new List<IExpressionNode>()
                                                    {new StringNode("false", new DummyFilePlace())},
                                                new DummyFilePlace()))
                                    })),
                                new VoidReturnNode(new DummyFilePlace())
                            })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Bool, "implies",
                        new List<IFunctionArgument>()
                            {new FunctionArgument(LatteType.Bool, "x"), new FunctionArgument(LatteType.Bool, "y")},
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ReturnNode(new DummyFilePlace(), new OrNode(
                                new NegateNode(new VariableNode("x", new DummyFilePlace()), new DummyFilePlace()),
                                new CompareNode(RelOperator.Equals,
                                    new VariableNode("x", new DummyFilePlace()),
                                    new VariableNode("y", new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new DummyFilePlace()))
                        }))
                });
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}