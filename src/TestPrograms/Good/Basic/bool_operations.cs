using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     b(t(1) && f(2));
//     b(t(3) && t(4));
//     b(t(5) || t(6));
//     b(f(7) && t(8));
//     b(t(9) && t(10) && t(11));
//     b(f(12) || f(13) && t(14));
//     return 0;
// }
// 
// boolean f(int a) {
//     printInt(a);
//     return false;
// }
// boolean t(int a) {
//     return !f(a);
// }
// void b(boolean a) {
//     if(a)
//         printString("true");
//     else
//         printString("false");
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderBoolOperations : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(), new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(
                        new DummyFilePlace(), "b", new AndNode(
                            new FunctionCallNode(new DummyFilePlace(), "t", new IntNode(1, new DummyFilePlace())),
                            new FunctionCallNode(new DummyFilePlace(), "f", new IntNode(2, new DummyFilePlace())),
                            new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "b",
                        new AndNode(
                            new FunctionCallNode(new DummyFilePlace(), "t", new IntNode(3, new DummyFilePlace())),
                            new FunctionCallNode(new DummyFilePlace(), "t", new IntNode(4, new DummyFilePlace())),
                            new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "b",
                        new OrNode(
                            new FunctionCallNode(new DummyFilePlace(), "t", new IntNode(5, new DummyFilePlace())),
                            new FunctionCallNode(new DummyFilePlace(), "t", new IntNode(6, new DummyFilePlace())),
                            new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "b",
                        new AndNode(
                            new FunctionCallNode(new DummyFilePlace(), "f", new IntNode(7, new DummyFilePlace())),
                            new FunctionCallNode(new DummyFilePlace(), "t", new IntNode(8, new DummyFilePlace())),
                            new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "b",
                        new AndNode(
                            new FunctionCallNode(new DummyFilePlace(), "t", new IntNode(9, new DummyFilePlace())),
                            new AndNode(
                                new FunctionCallNode(new DummyFilePlace(), "t", new IntNode(10, new DummyFilePlace())),
                                new FunctionCallNode(new DummyFilePlace(), "t", new IntNode(11, new DummyFilePlace())),
                                new DummyFilePlace()),
                            new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "b",
                        new OrNode(
                            new FunctionCallNode(new DummyFilePlace(), "f", new IntNode(12, new DummyFilePlace())),
                            new AndNode(
                                new FunctionCallNode(new DummyFilePlace(), "f", new IntNode(13, new DummyFilePlace())),
                                new FunctionCallNode(new DummyFilePlace(), "t", new IntNode(14, new DummyFilePlace())),
                                new DummyFilePlace()),
                            new DummyFilePlace()))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                new FunctionDefinition(new DummyFilePlace(), LatteType.Bool, "f", new BlockNode(new DummyFilePlace(),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new VariableNode("a", new DummyFilePlace()))),
                        new ReturnNode(new DummyFilePlace(), new FalseNode(new DummyFilePlace()))),
                    new FunctionArgument(LatteType.Int, "a")),
                new FunctionDefinition(new DummyFilePlace(), LatteType.Bool, "t",
                    new BlockNode(new DummyFilePlace(),
                        new ReturnNode(new DummyFilePlace(),
                            new LogicalNegateNode(
                                new FunctionCallNode(new DummyFilePlace(), "f",
                                    new VariableNode("a", new DummyFilePlace())), new DummyFilePlace()))),
                    new FunctionArgument(LatteType.Int, "a")),
                new FunctionDefinition(new DummyFilePlace(), LatteType.Void, "b",
                    new BlockNode(new DummyFilePlace(),
                        new IfElseNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                            new BlockNode(new DummyFilePlace(), new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("true", new DummyFilePlace())))), 
                            new BlockNode(new DummyFilePlace(), new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("false", new DummyFilePlace())))))),
                    new FunctionArgument(LatteType.Bool, "a")));
        }

        public string GetOutput()
        {
            return @"1
2
false
3
4
true
5
true
7
false
9
10
11
true
12
13
false
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}