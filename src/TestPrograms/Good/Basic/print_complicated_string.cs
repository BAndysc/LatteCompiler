using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// // Autor: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests

// int main() {
//     printString("\\a\\n\n\tb\"");
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderPrintComplicatedString : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(),
                new ExpressionStatementNode(new DummyFilePlace(),
                    new FunctionCallNode(new DummyFilePlace(), "printString",
                        new StringNode("\\\\a\\\\n\\n\\tb\\\"", new DummyFilePlace()))),
                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"\a\n
	b""
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}