using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     printString("a" + "b");
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderConcatenation : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(), new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(
                    new DummyFilePlace(), "printString", new BinaryNode(BinaryOperator.Add,
                        new StringNode("a", new DummyFilePlace()),
                        new StringNode("b", new DummyFilePlace()),
                        new DummyFilePlace()))),
                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"ab
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}