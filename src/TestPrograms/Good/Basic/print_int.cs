using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;



// // Autor: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     printInt(1);
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderPrintInt : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(),
                new ExpressionStatementNode(new DummyFilePlace(),
                    new FunctionCallNode(new DummyFilePlace(), "printInt", new IntNode(1, new DummyFilePlace()))),
                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"1
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}