using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// // Authors: Tomasz Biczel 277568, Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests

// int main() {
//     while (true) {
//         int x;
//         x = readInt();
//         if (x == 1)
//             return 0;
//         else
//             printString("jeszcze raz");
//     }
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderWhileTrue2 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(), new WhileNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()),
                    new BlockNode(new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int, new SingleDeclaration("x", null)),
                        new AssignmentNode(new DummyFilePlace(), "x",
                            new FunctionCallNode(new DummyFilePlace(), "readInt")),
                        new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                new VariableNode("x", new DummyFilePlace()),
                                new IntNode(1, new DummyFilePlace()),
                                new DummyFilePlace()),
                            new BlockNode(new DummyFilePlace(), new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))), 
                            new BlockNode(new DummyFilePlace(), new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("jeszcze raz", new DummyFilePlace()))))))),
                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"jeszcze raz
";
        }

        public string GetInput()
        {
            return @"0
1
";
        }
    }
}