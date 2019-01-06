using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     printInt(- -1);
//     int i = 1;
//     printInt(-i);
//     printInt(2 - -i);
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderNegation : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(),
                new ExpressionStatementNode(new DummyFilePlace(),
                    new FunctionCallNode(new DummyFilePlace(), "printInt",
                        new NegateNode(new NegateNode(new IntNode(1, new DummyFilePlace()), new DummyFilePlace()),
                            new DummyFilePlace()))),
                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                    new SingleDeclaration("i", new IntNode(1, new DummyFilePlace()))),
                new ExpressionStatementNode(new DummyFilePlace(),
                    new FunctionCallNode(new DummyFilePlace(), "printInt",
                        new NegateNode(new VariableNode("i", new DummyFilePlace()), new DummyFilePlace()))),
                new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "printInt",
                    new BinaryNode(BinaryOperator.Sub,
                        new IntNode(2, new DummyFilePlace()),
                        new NegateNode(new VariableNode("i", new DummyFilePlace()), new DummyFilePlace()),
                        new DummyFilePlace()))),
                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"1
-1
3
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}