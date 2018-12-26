using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* allow comparing booleans. */
// 
// int main() {
//   if (true == true) { printInt(42); }
//   return 0 ;
// 
// }

namespace LatteTypeChecker.Tests.Good
{
    public class Core004Tests
    {
        [Test]
        public void Core004Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                new TrueNode(new DummyFilePlace()),
                                new TrueNode(new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new IntNode(42, new DummyFilePlace())},
                                        new DummyFilePlace()))
                            })),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.AreEqual(true, new TypeChecker().Visit(treeOptimizer.Visit(program)));
        }
    }
}