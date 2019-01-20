using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* test input */
// 
// int main() {
//   int x = readInt();
//   string y = readString();
//   string z = readString();
// 
//   printInt(x-5);
//   printString(y+z);  
//   return 0 ;
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderCore018 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>()
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                {
                                    new SingleDeclaration("x",
                                        new FunctionCallNode("readInt", new List<IExpressionNode>() { },
                                            new DummyFilePlace()))
                                }),
                            new DeclarationNode(new DummyFilePlace(), LatteType.String,
                                new List<ISingleDeclaration>()
                                {
                                    new SingleDeclaration("y",
                                        new FunctionCallNode("readString", new List<IExpressionNode>() { },
                                            new DummyFilePlace()))
                                }),
                            new DeclarationNode(new DummyFilePlace(), LatteType.String,
                                new List<ISingleDeclaration>()
                                {
                                    new SingleDeclaration("z",
                                        new FunctionCallNode("readString", new List<IExpressionNode>() { },
                                            new DummyFilePlace()))
                                }),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printInt",
                                new List<IExpressionNode>()
                                {
                                    new BinaryNode(BinaryOperator.Sub,
                                        new VariableNode("x", new DummyFilePlace()),
                                        new IntNode(5, new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode("printString",
                                new List<IExpressionNode>()
                                {
                                    new BinaryNode(BinaryOperator.Add,
                                        new VariableNode("y", new DummyFilePlace()),
                                        new VariableNode("z", new DummyFilePlace()),
                                        new DummyFilePlace())
                                }, new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
        }

        public string GetOutput()
        {
            return @"-42
foobar
";
        }

        public string GetInput()
        {
            return @"-37
foo
bar
";
        }
    }
}