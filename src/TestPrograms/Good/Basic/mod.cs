using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     printInt(5 % 3);
//     printInt(-5 % 3); // -2 - sic!
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderMod : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(), new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(
                    new DummyFilePlace(), "printInt", new BinaryNode(BinaryOperator.Mod,
                        new IntNode(5, new DummyFilePlace()),
                        new IntNode(3, new DummyFilePlace()),
                        new DummyFilePlace()))),
                new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "printInt",
                    new BinaryNode(BinaryOperator.Mod,
                        new NegateNode(new IntNode(5, new DummyFilePlace()), new DummyFilePlace()),
                        new IntNode(3, new DummyFilePlace()),
                        new DummyFilePlace()))),
                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"2
-2
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}