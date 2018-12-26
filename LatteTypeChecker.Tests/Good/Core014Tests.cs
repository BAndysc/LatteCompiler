using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* Fibonacci. */
// 
// int main () {
//   int lo,hi,mx ;
//   lo = 1 ;
//   hi = lo ;
//   mx = 5000000 ;
//   printInt(lo) ;
//   while (hi < mx) {
//     printInt(hi) ;
//     hi = lo + hi ;
//     lo = hi - lo ;
//   }
//   return 0 ;
// 
// }
// 
// 

namespace LatteTypeChecker.Tests.Good
{
    public class Core014Tests
    {
        [Test]
        public void Core014Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                {
                                    new SingleDeclaration("lo", null), new SingleDeclaration("hi", null),
                                    new SingleDeclaration("mx", null)
                                }),
                            new AssignmentNode(new DummyFilePlace(), "lo", new IntNode(1, new DummyFilePlace())),
                            new AssignmentNode(new DummyFilePlace(), "hi",
                                new VariableNode("lo", new DummyFilePlace())),
                            new AssignmentNode(new DummyFilePlace(), "mx", new IntNode(5000000, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("lo", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                new VariableNode("hi", new DummyFilePlace()),
                                new VariableNode("mx", new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("hi", new DummyFilePlace())},
                                        new DummyFilePlace())),
                                new AssignmentNode(new DummyFilePlace(), "hi", new BinaryNode(BinaryOperator.Add,
                                    new VariableNode("lo", new DummyFilePlace()),
                                    new VariableNode("hi", new DummyFilePlace()),
                                    new DummyFilePlace())),
                                new AssignmentNode(new DummyFilePlace(), "lo", new BinaryNode(BinaryOperator.Sub,
                                    new VariableNode("hi", new DummyFilePlace()),
                                    new VariableNode("lo", new DummyFilePlace()),
                                    new DummyFilePlace()))
                            })),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}