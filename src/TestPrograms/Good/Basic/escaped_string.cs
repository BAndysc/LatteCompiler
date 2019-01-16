using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// // Autor: Bolek Kulbabinski
// Source: https://github.com/tomwys/mrjp-tests
// 
// int f(int p){
//     int c = p + 2*p;
//     printString("\"\\npop\\npowrot:\\ngetstatic java/lang/System/out Ljava/io/PrintStream;\\nldc \"zle \"\\ninvokevirtual java/io/PrintStream/print(Ljava/lang/String;)V\\ngoto powrot\\nldc \"");
//     return c;
// }
// 
// int main() {
//     return f(1) - 3;
// }
// 
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderEscapedString : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "f", new BlockNode(
                        new DummyFilePlace(), new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("c", new BinaryNode(BinaryOperator.Add,
                                new VariableNode("p", new DummyFilePlace()),
                                new BinaryNode(BinaryOperator.Mul,
                                    new IntNode(2, new DummyFilePlace()),
                                    new VariableNode("p", new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new DummyFilePlace()))),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printString",
                                new StringNode(
                                    "\"\\npop\\npowrot:\\ngetstatic java/lang/System/out Ljava/io/PrintStream;\\nldc \"zle \"\\ninvokevirtual java/io/PrintStream/print(Ljava/lang/String;)V\\ngoto powrot\\nldc \"",
                                    new DummyFilePlace()))),
                        new ReturnNode(new DummyFilePlace(), new VariableNode("c", new DummyFilePlace()))),
                    new FunctionArgument(LatteType.Int, "p")),
                new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(new DummyFilePlace(),
                    new ReturnNode(new DummyFilePlace(), new BinaryNode(BinaryOperator.Sub,
                        new FunctionCallNode(new DummyFilePlace(), "f", new IntNode(1, new DummyFilePlace())),
                        new IntNode(3, new DummyFilePlace()),
                        new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"""
pop
powrot:
getstatic java/lang/System/out Ljava/io/PrintStream;
ldc ""zle ""
invokevirtual java/io/PrintStream/print(Ljava/lang/String;)V
goto powrot
ldc ""
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}