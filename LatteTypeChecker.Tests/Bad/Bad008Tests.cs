using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using LatteTypeChecker.Exceptions;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

//   int main() { 
//     if (false)
//        return 0; 
// }
// 

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad008Tests
    {
        [Test]
        public void Bad008Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfNode(new DummyFilePlace(), new FalseNode(new DummyFilePlace()),
                                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.Catch<ExpectedReturnInFunctionException>(() =>
                new TypeChecker().Visit(treeOptimizer.Visit(program))
            );
        }
    }
}