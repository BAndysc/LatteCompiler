using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // multiple variables of the same type declared 
// // and possibly initialized in the same statement
// 
// int main() {
//  int x, y = 7;
//  x = -1234234;
//  printInt(x);
//  printInt(y);
//  return 0 ;
// 
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderCore008 : ITestProgramProvider
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
                                    new SingleDeclaration("x", null),
                                    new SingleDeclaration("y", new IntNode(7, new DummyFilePlace()))
                                }),
                            new AssignmentNode(new DummyFilePlace(), "x",
                                new NegateNode(new IntNode(1234234, new DummyFilePlace()), new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("x", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("y", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
        }

        public string GetOutput()
        {
            return @"-1234234
7
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}