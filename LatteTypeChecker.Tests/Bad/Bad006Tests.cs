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
//         x = 14;
// 	return 0 ;
// }
// 

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad006Tests
    {
        [Test]
        public void Bad006Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new AssignmentNode(new DummyFilePlace(), "x", new IntNode(14, new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.Catch<UndeclaredVariableException>(() =>
                new TypeChecker().Visit(treeOptimizer.Visit(program))
            );
        }
    }
}