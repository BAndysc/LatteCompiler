using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
//   int i = 78;
//   {
//     int i = 1;
//     printInt(i);
//   }
//   printInt(i);
//   while (i > 76) {
//     i--;
//     printInt(i);
//    // this is a little tricky
//    // on the right hand side, i refers to the outer i
//    int i = i + 7;
//    printInt(i);
//   }
//   printInt(i);
//   if (i > 4) {
//     int i = 4;
//     printInt(i);
//   } else {
//     printString("foo");
//   } 
//   printInt(i);
//   return 0 ;
// 
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderCore019 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinition>()
                {
                    new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                    {new SingleDeclaration("i", new IntNode(78, new DummyFilePlace()))}),
                            new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new List<ISingleDeclaration>()
                                        {new SingleDeclaration("i", new IntNode(1, new DummyFilePlace()))}),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            }),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                new VariableNode("i", new DummyFilePlace()),
                                new IntNode(76, new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new DecrementNode(new DummyFilePlace(), "i"),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                        new DummyFilePlace())),
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int, new List<ISingleDeclaration>()
                                {
                                    new SingleDeclaration("i", new BinaryNode(BinaryOperator.Add,
                                        new VariableNode("i", new DummyFilePlace()),
                                        new IntNode(7, new DummyFilePlace()),
                                        new DummyFilePlace()))
                                }),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            })),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                new VariableNode("i", new DummyFilePlace()),
                                new IntNode(4, new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new List<ISingleDeclaration>()
                                        {new SingleDeclaration("i", new IntNode(4, new DummyFilePlace()))}),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            }), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printString",
                                        new List<IExpressionNode>() {new StringNode("foo", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            })),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("i", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
        }

        public string GetOutput()
        {
            return @"1
78
77
84
76
83
76
4
76
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}