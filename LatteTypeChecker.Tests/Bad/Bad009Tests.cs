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
//         int x;
//         x = true;
//         return 1;
// }
// 

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad009Tests
    {
        [Test]
        public void Bad009Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>() {new SingleDeclaration("x", null)}),
                            new AssignmentNode(new DummyFilePlace(), "x", new TrueNode(new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(1, new DummyFilePlace()))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.Catch<TypeMismatchException>(() =>
                new TypeChecker().Visit(treeOptimizer.Visit(program))
            );
        }
    }
}