using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using LatteTypeChecker.Exceptions;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* Testing that main must return. */
// 
// /* All functions should return a value of their value type. This is not a valid Javalette program: */
// 
// int main() {
// }
// 

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad021Tests
    {
        [Test]
        public void Bad021Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.Catch<ExpectedReturnInFunctionException>(() =>
                new TypeChecker().Visit(treeOptimizer.Visit(program))
            );
        }
    }
}