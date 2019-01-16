using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     int i = 0;
//     printInt(i);
//     {
//         int i = 1;
//         printInt(i);
//     }
//     printInt(i);
//     {
//         int i = 2;
//         printInt(i);
//     }
//     printInt(i);
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderScopes : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(),
                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                    new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))),
                new ExpressionStatementNode(new DummyFilePlace(),
                    new FunctionCallNode(new DummyFilePlace(), "printInt",
                        new VariableNode("i", new DummyFilePlace()))),
                new BlockNode(new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("i", new IntNode(1, new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new VariableNode("i", new DummyFilePlace())))),
                new ExpressionStatementNode(new DummyFilePlace(),
                    new FunctionCallNode(new DummyFilePlace(), "printInt",
                        new VariableNode("i", new DummyFilePlace()))),
                new BlockNode(new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("i", new IntNode(2, new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new VariableNode("i", new DummyFilePlace())))),
                new ExpressionStatementNode(new DummyFilePlace(),
                    new FunctionCallNode(new DummyFilePlace(), "printInt",
                        new VariableNode("i", new DummyFilePlace()))),
                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"0
1
0
2
0
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}