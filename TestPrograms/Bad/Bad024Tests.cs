using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
//     if (false) 
//        return 0;
// }
// 

namespace TestPrograms.Bad
{
    public class TestProgramProviderBad024
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfNode(new DummyFilePlace(), new FalseNode(new DummyFilePlace()),
                                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))
                        }))
                });
        }
    }
}