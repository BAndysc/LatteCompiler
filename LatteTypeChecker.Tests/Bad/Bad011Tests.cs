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
//      return true;
// }
// 

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad011Tests
    {
        [Test]
        public void Bad011Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ReturnNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()))
                        }))
                });
            Assert.Catch<InvalidReturnTypeException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}