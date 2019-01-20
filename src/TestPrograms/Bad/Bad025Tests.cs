using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
//    return f(3); 
// }
// 
// int f(int x) {
//     if (x<0) 
//        return x;
// }
// 

namespace TestPrograms.Bad
{
    public class TestProgramProviderBad025
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>()
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ReturnNode(new DummyFilePlace(),
                                new FunctionCallNode("f",
                                    new List<IExpressionNode>() {new IntNode(3, new DummyFilePlace())},
                                    new DummyFilePlace()))
                        })),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "f",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "x")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                        new VariableNode("x", new DummyFilePlace()),
                                        new IntNode(0, new DummyFilePlace()),
                                        new DummyFilePlace()),
                                    new BlockNode(new DummyFilePlace(), new ReturnNode(new DummyFilePlace(), new VariableNode("x", new DummyFilePlace()))))
                            }))
                });
        }
    }
}