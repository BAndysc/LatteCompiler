using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: cbart@students.mimuw.edu.pl (Cezary Bartoszuk)
// Source: https://github.com/tomwys/mrjp-tests

// /**
//  * Iterative fibonacci.
//  *
//  * @param n a non-negative index in Fibonacci sequence.
//  * @return value of `n`'th Fibonacci number
//  *
//  * @author cbart@students.mimuw.edu.pl (Cezary Bartoszuk)
//  */
// int fibonacci(int n) {
//     if (n <= 1) {
//         return n;
//     }
//     int fib_a = 0;
//     int fib_b = 1;
//     int tmp;
//     int i = 2;
//     while (i <= n) {
//         tmp = fib_b + fib_a;
//         fib_a = fib_b;
//         fib_b = tmp;
//         i++;
//     }
//     return fib_b;
// }
// 
// 
// int main() {
//     int i = readInt();
//     if (i >= 0) {
//         printInt(fibonacci(i));
//         return 0;
//     } else {
//         printString("Expected a non-negative integer, but got:");
//         printInt(i);
//         return 1;
//     }
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderFibonacci : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "fibonacci", new BlockNode(
                        new DummyFilePlace(), new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.LessEquals,
                                new VariableNode("n", new DummyFilePlace()),
                                new IntNode(1, new DummyFilePlace()),
                                new DummyFilePlace()),
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("n", new DummyFilePlace())))),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("fib_a", new IntNode(0, new DummyFilePlace()))),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("fib_b", new IntNode(1, new DummyFilePlace()))),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int, new SingleDeclaration("tmp", null)),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("i", new IntNode(2, new DummyFilePlace()))),
                        new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessEquals,
                            new VariableNode("i", new DummyFilePlace()),
                            new VariableNode("n", new DummyFilePlace()),
                            new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new AssignmentNode(
                                new DummyFilePlace(), "tmp", new BinaryNode(BinaryOperator.Add,
                                    new VariableNode("fib_b", new DummyFilePlace()),
                                    new VariableNode("fib_a", new DummyFilePlace()),
                                    new DummyFilePlace())),
                            new AssignmentNode(new DummyFilePlace(), "fib_a",
                                new VariableNode("fib_b", new DummyFilePlace())),
                            new AssignmentNode(new DummyFilePlace(), "fib_b",
                                new VariableNode("tmp", new DummyFilePlace())),
                            new IncrementNode(new DummyFilePlace(), "i"))),
                        new ReturnNode(new DummyFilePlace(), new VariableNode("fib_b", new DummyFilePlace()))),
                    new FunctionArgument(LatteType.Int, "n")),
                new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("i", new FunctionCallNode(new DummyFilePlace(), "readInt"))),
                    new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterEquals,
                        new VariableNode("i", new DummyFilePlace()),
                        new IntNode(0, new DummyFilePlace()),
                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new FunctionCallNode(new DummyFilePlace(), "fibonacci",
                                    new VariableNode("i", new DummyFilePlace())))),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))), new BlockNode(
                        new DummyFilePlace(),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printString",
                                new StringNode("Expected a non-negative integer, but got:", new DummyFilePlace()))),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new VariableNode("i", new DummyFilePlace()))),
                        new ReturnNode(new DummyFilePlace(), new IntNode(1, new DummyFilePlace())))))));
        }

        public string GetOutput()
        {
            return @"28657
";
        }

        public string GetInput()
        {
            return @"23
";
        }
    }
}