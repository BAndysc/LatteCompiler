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
//         if (true)
//                 return;
// 	;
//         return 1;
// }
// 

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad010Tests
    {
        [Test]
        public void Bad010Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()),
                                new VoidReturnNode(new DummyFilePlace())),
                            new EmptyNode(new DummyFilePlace()),
                            new ReturnNode(new DummyFilePlace(), new IntNode(1, new DummyFilePlace()))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.Catch<InvalidReturnTypeException>(() =>
                new TypeChecker().Visit(treeOptimizer.Visit(program))
            );
        }
    }
}