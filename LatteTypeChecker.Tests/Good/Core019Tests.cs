using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
//   int i = 78;
//   {
//     int i = 1;
//     printInt(i);
//   }
//   printInt(i);
//   while (i > 76) {
//     i--;
//     printInt(i);
//    // this is a little tricky
//    // on the right hand side, i refers to the outer i
//    int i = i + 7;
//    printInt(i);
//   }
//   printInt(i);
//   if (i > 4) {
//     int i = 4;
//     printInt(i);
//   } else {
//     printString("foo");
//   } 
//   printInt(i);
//   return 0 ;
// 
// }

namespace LatteTypeChecker.Tests.Good
{
    public class Core019Tests
    {
        [Test]
        public void Core019Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                    {new SingleDeclaration("i", new IntNode(78, new DummyFilePlace()))}),
                            new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new List<ISingleDeclaration>()
                                        {new SingleDeclaration("i", new IntNode(1, new DummyFilePlace()))}),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            }),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                new VariableNode("i", new DummyFilePlace()),
                                new IntNode(76, new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new IncrementNode(new DummyFilePlace(), "i"),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                        new DummyFilePlace())),
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int, new List<ISingleDeclaration>()
                                {
                                    new SingleDeclaration("i", new BinaryNode(BinaryOperator.Add,
                                        new VariableNode("i", new DummyFilePlace()),
                                        new IntNode(7, new DummyFilePlace()),
                                        new DummyFilePlace()))
                                }),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            })),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                new VariableNode("i", new DummyFilePlace()),
                                new IntNode(4, new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new List<ISingleDeclaration>()
                                        {new SingleDeclaration("i", new IntNode(4, new DummyFilePlace()))}),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            }), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printString",
                                        new List<IExpressionNode>() {new StringNode("foo", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            })),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.AreEqual(true, new TypeChecker().Visit(treeOptimizer.Visit(program)));
        }
    }
}