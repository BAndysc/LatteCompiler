using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     run();
//     return 0;
// }
// 
// void run() {
//     printInt(0);
//     if(true)
//         return;
//     printInt(1);
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderVoidReturn : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "run")),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                new FunctionDefinition(new DummyFilePlace(), LatteType.Void, "run", new BlockNode(new DummyFilePlace(),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt", new IntNode(0, new DummyFilePlace()))),
                    new IfNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()),
                        new BlockNode(new DummyFilePlace(), new VoidReturnNode(new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new IntNode(1, new DummyFilePlace()))))));
        }

        public string GetOutput()
        {
            return @"0
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}