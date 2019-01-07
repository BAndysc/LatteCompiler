using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     if(1 <= 1)
//         printString("4");
//     if(1 >= 1)
//         printString("4");
//     if(1 > 1)
//         printString("5");
//     if(1 < 1)
//         printString("5");
//     if(1 < 2)
//         printString("6");
//     if(2 > 1)
//         printString("6");
//     if(1 > 2)
//         printString("7");
//     if(2 < 1)
//         printString("7");
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderCompare : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(), new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.LessEquals,
                        new IntNode(1, new DummyFilePlace()),
                        new IntNode(1, new DummyFilePlace()),
                        new DummyFilePlace()),
                    new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("4", new DummyFilePlace())))))),
                new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterEquals,
                        new IntNode(1, new DummyFilePlace()),
                        new IntNode(1, new DummyFilePlace()),
                        new DummyFilePlace()),
                    new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("4", new DummyFilePlace())))))),
                new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                        new IntNode(1, new DummyFilePlace()),
                        new IntNode(1, new DummyFilePlace()),
                        new DummyFilePlace()),
                    new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("5", new DummyFilePlace())))))),
                new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                        new IntNode(1, new DummyFilePlace()),
                        new IntNode(1, new DummyFilePlace()),
                        new DummyFilePlace()),
                    new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("5", new DummyFilePlace())))))),
                new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                        new IntNode(1, new DummyFilePlace()),
                        new IntNode(2, new DummyFilePlace()),
                        new DummyFilePlace()),
                    new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("6", new DummyFilePlace())))))),
                new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                        new IntNode(2, new DummyFilePlace()),
                        new IntNode(1, new DummyFilePlace()),
                        new DummyFilePlace()),
                    new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("6", new DummyFilePlace())))))),
                new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                        new IntNode(1, new DummyFilePlace()),
                        new IntNode(2, new DummyFilePlace()),
                        new DummyFilePlace()),
                    new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("7", new DummyFilePlace())))))),
                new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                        new IntNode(2, new DummyFilePlace()),
                        new IntNode(1, new DummyFilePlace()),
                        new DummyFilePlace()),
                    new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("7", new DummyFilePlace())))))),
                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"4
4
6
6
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}