using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using LatteTypeChecker.Exceptions;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // Repeated argument name
// int f(int x, int x) {
//    return x;
// }

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad003Tests
    {
        [Test]
        public void Bad003Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "f",
                        new List<IFunctionArgument>()
                            {new FunctionArgument(LatteType.Int, "x"), new FunctionArgument(LatteType.Int, "x")},
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ReturnNode(new DummyFilePlace(), new VariableNode("x", new DummyFilePlace()))
                        }))
                });

            Assert.Catch<RepeatedArgumentNameInFunctionDefinitionException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}