using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using LatteTypeChecker.Exceptions;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
//       string x ;
//       x = "pi" + 1 ;
//       return 0 ;
// }
// 

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad013Tests
    {
        [Test]
        public void Bad013Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.String,
                                new List<ISingleDeclaration>() {new SingleDeclaration("x", null)}),
                            new AssignmentNode(new DummyFilePlace(), "x", new BinaryNode(BinaryOperator.Add,
                                new StringNode("pi", new DummyFilePlace()),
                                new IntNode(1, new DummyFilePlace()),
                                new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.Catch<InvalidOperatorUsageException>(() =>
                new TypeChecker().Visit(treeOptimizer.Visit(program))
            );
        }
    }
}