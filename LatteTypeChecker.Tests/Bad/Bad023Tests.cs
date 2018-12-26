using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using LatteTypeChecker.Exceptions;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // Assigning int to string variable.
// 
// int main () {
//  string x = 1;
//  return 0 ;
// }

namespace LatteTypeChecker.Tests.Bad
{
    public class Bad023Tests
    {
        [Test]
        public void Bad023Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.String,
                                new List<ISingleDeclaration>()
                                    {new SingleDeclaration("x", new IntNode(1, new DummyFilePlace()))}),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.Catch<VariableDeclarationTypeMismatch>(() =>
                new TypeChecker().Visit(treeOptimizer.Visit(program))
            );
        }
    }
}