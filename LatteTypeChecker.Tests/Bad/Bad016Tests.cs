using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using LatteTypeChecker.Exceptions;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // passing integers to printString().
// 
// int main() {
// 	printString(1);
// 	return 0 ;
// }
// 

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad016Tests
    {
        [Test]
        public void Bad016Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printString",
                                    new List<IExpressionNode>() {new IntNode(1, new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.Catch<FunctionCallTypeMismatch>(() =>
                new TypeChecker().Visit(treeOptimizer.Visit(program))
            );
        }
    }
}