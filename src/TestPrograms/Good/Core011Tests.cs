using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* Test pushing -1. */
// 
// int main() {
//   printInt(-1);
//   return 0 ;
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderCore011 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinition>()
                {
                    new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>()
                                        {new NegateNode(new IntNode(1, new DummyFilePlace()), new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
        }

        public string GetOutput()
        {
            return "-1\n";
        }

        public string GetInput()
        {
            return null;
        }
    }
}