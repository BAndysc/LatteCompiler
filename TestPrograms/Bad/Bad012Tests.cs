using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
//      int i = foo(true);
//      return 0 ;
// }
// 
// int foo(boolean b) { b = true; }
// 

namespace TestPrograms.Bad
{
    public class TestProgramProviderBad012
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                {
                                    new SingleDeclaration("i",
                                        new FunctionCallNode("foo",
                                            new List<IExpressionNode>() {new TrueNode(new DummyFilePlace())},
                                            new DummyFilePlace()))
                                }),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "foo",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Bool, "b")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new AssignmentNode(new DummyFilePlace(), "b", new TrueNode(new DummyFilePlace()))
                            }))
                });
        }
    }
}