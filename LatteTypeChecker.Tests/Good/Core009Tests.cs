using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // Calling functions which take zero parameters
// 
// int main() {
//  int x = foo();
//  printInt(x);
//  return 0 ;
// 
// }
// 
// int foo() {
//  return 10;
// }
// 
// 

namespace LatteTypeChecker.Tests.Good
{
    public class Core009Tests
    {
        [Test]
        public void Core009Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                {
                                    new SingleDeclaration("x",
                                        new FunctionCallNode("foo", new List<IExpressionNode>() { },
                                            new DummyFilePlace()))
                                }),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("x", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "foo", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ReturnNode(new DummyFilePlace(), new IntNode(10, new DummyFilePlace()))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.AreEqual(true, new TypeChecker().Visit(treeOptimizer.Visit(program)));
        }
    }
}