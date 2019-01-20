using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// // Assigning int to string variable.
// 
// int main () {
//  string x;
//  x = 1;
//  return 0 ;
// }

namespace TestPrograms.Bad
{
    public class TestProgramProviderBad027
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>()
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.String,
                                new List<ISingleDeclaration>() {new SingleDeclaration("x", null)}),
                            new AssignmentNode(new DummyFilePlace(), "x", new IntNode(1, new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
        }
    }
}