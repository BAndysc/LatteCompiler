using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
//      return true;
// }
// 

namespace TestPrograms.Bad
{
    public class TestProgramProviderBad011
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>()
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ReturnNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()))
                        }))
                });
        }
    }
}