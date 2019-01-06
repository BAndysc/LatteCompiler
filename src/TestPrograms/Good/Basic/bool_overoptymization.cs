using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     print() && false;
//     return 0;
// }
// 
// boolean print() {
//     printString("ahoj");
//     return true;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderBoolOveroptymization : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(), new ExpressionStatementNode(new DummyFilePlace(), new AndNode(
                        new FunctionCallNode(new DummyFilePlace(), "print"),
                        new FalseNode(new DummyFilePlace()),
                        new DummyFilePlace())),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                new TopFunctionNode(new DummyFilePlace(), LatteType.Bool, "print", new BlockNode(new DummyFilePlace(),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printString",
                            new StringNode("ahoj", new DummyFilePlace()))),
                    new ReturnNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"ahoj
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}