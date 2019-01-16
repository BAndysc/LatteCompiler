using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
//         if (true)
//                 return;
// 	;
//         return 1;
// }
// 

namespace TestPrograms.Bad
{
    public class TestProgramProviderBad010
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinition>()
                {
                    new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(), new VoidReturnNode(new DummyFilePlace()))),
                            new EmptyNode(new DummyFilePlace()),
                            new ReturnNode(new DummyFilePlace(), new IntNode(1, new DummyFilePlace()))
                        }))
                });
        }
    }
}