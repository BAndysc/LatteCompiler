using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // Assigning string to int variable.
// 
// int main () {
//  int x = "";
//  return 0 ;
// }

namespace TestPrograms.Bad
{
    public class TestProgramProviderBad022
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
                                    {new SingleDeclaration("x", new StringNode("", new DummyFilePlace()))}),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
        }
    }
}