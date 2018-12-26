using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using NUnit.Framework;

namespace LatteTypeChecker.Tests.Good
{
    public class AddTests
    {
        [Test]
        public void AddTest()
        {
            var program = new ProgramNode(new List<ITopFunctionNode>()
            {
                new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                    new BlockNode(new DummyFilePlace(), new List<IStatement>()
                    {
                        new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printInt",
                            new List<IExpressionNode>()
                            {
                                new BinaryNode(BinaryOperator.Add,
                                    new IntNode(1, new DummyFilePlace()),
                                    new IntNode(1, new DummyFilePlace()),
                                    new DummyFilePlace())
                            }, new DummyFilePlace())),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                    }))
            });

            Assert.AreEqual(true, new StaticAnalysisChecker().Visit(program));
        }
    }

}