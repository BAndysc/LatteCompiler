using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // Declaration of multiple variables of the same type in one statement:
// 
// int main () {
//   int x, y;
//   x = 45;
//   y = -36;
//   printInt(x);
//   printInt(y);
//   return 0 ;
// 
// }

namespace LatteTypeChecker.Tests.Good
{
    public class Core006Tests
    {
        [Test]
        public void Core006Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                    {new SingleDeclaration("x", null), new SingleDeclaration("y", null)}),
                            new AssignmentNode(new DummyFilePlace(), "x", new IntNode(45, new DummyFilePlace())),
                            new AssignmentNode(new DummyFilePlace(), "y",
                                new NegateNode(new IntNode(36, new DummyFilePlace()), new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("x", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("y", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }
}