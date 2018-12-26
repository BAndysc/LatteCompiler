using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* Test arithmetic and comparisons. */
// 
// int main() {
//     int x = 56;
//     int y = -23;
//     printInt(x+y);
//     printInt(x-y);
//     printInt(x*y);
//     printInt(45/2);
//     printInt(78%3);
//     printBool(x-y > x+y);
//     printBool(x/y <= x*y);
//     printString("string"+" "+"concatenation");
//     return 0 ;
// }
// 
// void printBool(boolean b) {
//   if (b) {
//     printString("true");
//     return;
//   } else {
//     printString("false");
//     return;
//  }
// }

namespace LatteTypeChecker.Tests.Good
{
    public class Core012Tests
    {
        [Test]
        public void Core012Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                    {new SingleDeclaration("x", new IntNode(56, new DummyFilePlace()))}),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                {
                                    new SingleDeclaration("y",
                                        new NegateNode(new IntNode(23, new DummyFilePlace()), new DummyFilePlace()))
                                }),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printInt",
                                new List<IExpressionNode>()
                                {
                                    new BinaryNode(BinaryOperator.Add,
                                        new VariableNode("x", new DummyFilePlace()),
                                        new VariableNode("y", new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printInt",
                                new List<IExpressionNode>()
                                {
                                    new BinaryNode(BinaryOperator.Sub,
                                        new VariableNode("x", new DummyFilePlace()),
                                        new VariableNode("y", new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printInt",
                                new List<IExpressionNode>()
                                {
                                    new BinaryNode(BinaryOperator.Mul,
                                        new VariableNode("x", new DummyFilePlace()),
                                        new VariableNode("y", new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printInt",
                                new List<IExpressionNode>()
                                {
                                    new BinaryNode(BinaryOperator.Div,
                                        new IntNode(45, new DummyFilePlace()),
                                        new IntNode(2, new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printInt",
                                new List<IExpressionNode>()
                                {
                                    new BinaryNode(BinaryOperator.Mod,
                                        new IntNode(78, new DummyFilePlace()),
                                        new IntNode(3, new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new CompareNode(RelOperator.GreaterThan,
                                        new BinaryNode(BinaryOperator.Sub,
                                            new VariableNode("x", new DummyFilePlace()),
                                            new VariableNode("y", new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new BinaryNode(BinaryOperator.Add,
                                            new VariableNode("x", new DummyFilePlace()),
                                            new VariableNode("y", new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printBool",
                                new List<IExpressionNode>()
                                {
                                    new CompareNode(RelOperator.LessEquals,
                                        new BinaryNode(BinaryOperator.Div,
                                            new VariableNode("x", new DummyFilePlace()),
                                            new VariableNode("y", new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new BinaryNode(BinaryOperator.Mul,
                                            new VariableNode("x", new DummyFilePlace()),
                                            new VariableNode("y", new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printString",
                                new List<IExpressionNode>()
                                {
                                    new BinaryNode(BinaryOperator.Add,
                                        new BinaryNode(BinaryOperator.Add,
                                            new StringNode("string", new DummyFilePlace()),
                                            new StringNode(" ", new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new StringNode("concatenation", new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
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
                                                new DummyFilePlace())),
                                        new VoidReturnNode(new DummyFilePlace())
                                    }), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                                    {
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode("printString",
                                                new List<IExpressionNode>()
                                                    {new StringNode("false", new DummyFilePlace())},
                                                new DummyFilePlace())),
                                        new VoidReturnNode(new DummyFilePlace())
                                    }))
                            }))
                });
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}