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
//    return f(3); 
// }
// 
// int f(int x) {
//     if (x<0) 
//        return x;
// }
// 

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad025Tests
    {
        [Test]
        public void Bad025Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ReturnNode(new DummyFilePlace(),
                                new FunctionCallNode("f",
                                    new List<IExpressionNode>() {new IntNode(3, new DummyFilePlace())},
                                    new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "f",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "x")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                        new VariableNode("x", new DummyFilePlace()),
                                        new IntNode(0, new DummyFilePlace()),
                                        new DummyFilePlace()),
                                    new ReturnNode(new DummyFilePlace(), new VariableNode("x", new DummyFilePlace())))
                            }))
                });
            Assert.Catch<ExpectedReturnInFunctionException>(() =>
                new StaticAnalysisChecker().Visit(program)
            );
        }
    }
}