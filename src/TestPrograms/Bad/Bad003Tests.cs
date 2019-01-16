using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // Repeated argument name
// int f(int x, int x) {
//    return x;
// }

namespace TestPrograms.Bad
{
    public class TestProgramProviderBad003
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinition>()
                {
                    new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "f",
                        new List<IFunctionArgument>()
                            {new FunctionArgument(LatteType.Int, "x"), new FunctionArgument(LatteType.Int, "x")},
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ReturnNode(new DummyFilePlace(), new VariableNode("x", new DummyFilePlace()))
                        }))
                });
        }
    }
}