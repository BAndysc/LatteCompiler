using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // count function parameters as initialized
// 
// int main() {
//   printInt(fac(5));
//   return 0 ;
// }
// 
// int fac (int a) {
//   int r;
//   int n;
//   r = 1;
//   n = a;
//   while (n > 0)
//   {
//     r = r * n;
//     n = n - 1;
//   }
//   return r;
// }
// 

namespace LatteTypeChecker.Tests.Good
{
    public class Core010Tests
    {
        [Test]
        public void Core010Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("fac",
                                            new List<IExpressionNode>() {new IntNode(5, new DummyFilePlace())},
                                            new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "fac",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "a")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new List<ISingleDeclaration>() {new SingleDeclaration("r", null)}),
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new List<ISingleDeclaration>() {new SingleDeclaration("n", null)}),
                                new AssignmentNode(new DummyFilePlace(), "r", new IntNode(1, new DummyFilePlace())),
                                new AssignmentNode(new DummyFilePlace(), "n",
                                    new VariableNode("a", new DummyFilePlace())),
                                new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                    new VariableNode("n", new DummyFilePlace()),
                                    new IntNode(0, new DummyFilePlace()),
                                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                                {
                                    new AssignmentNode(new DummyFilePlace(), "r", new BinaryNode(BinaryOperator.Mul,
                                        new VariableNode("r", new DummyFilePlace()),
                                        new VariableNode("n", new DummyFilePlace()),
                                        new DummyFilePlace())),
                                    new AssignmentNode(new DummyFilePlace(), "n", new BinaryNode(BinaryOperator.Sub,
                                        new VariableNode("n", new DummyFilePlace()),
                                        new IntNode(1, new DummyFilePlace()),
                                        new DummyFilePlace()))
                                })),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("r", new DummyFilePlace()))
                            }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.AreEqual(true, new TypeChecker().Visit(treeOptimizer.Visit(program)));
        }
    }
}