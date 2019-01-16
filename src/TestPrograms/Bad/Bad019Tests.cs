using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // 2 instead of 1 arguments
// 
// int main() {
// 	int x = foo(1,2);
// 	return 0 ;
// }
// 
// int foo(int y) {
//  return y;
// }
// 
// 

namespace TestPrograms.Bad
{
    public class TestProgramProviderBad019
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
                                {
                                    new SingleDeclaration("x",
                                        new FunctionCallNode("foo",
                                            new List<IExpressionNode>()
                                            {
                                                new IntNode(1, new DummyFilePlace()),
                                                new IntNode(2, new DummyFilePlace())
                                            }, new DummyFilePlace()))
                                }),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        })),
                    new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "foo",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "y")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new ReturnNode(new DummyFilePlace(), new VariableNode("y", new DummyFilePlace()))
                            }))
                });
        }
    }
}