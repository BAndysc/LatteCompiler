using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* allow comparing booleans. */
// 
// int main() {
//   if (true == true) { printInt(42); }
//   return 0 ;
// 
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderCore004 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinition>()
                {
                    new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                new TrueNode(new DummyFilePlace()),
                                new TrueNode(new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new IntNode(42, new DummyFilePlace())},
                                        new DummyFilePlace()))
                            })),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
        }

        public string GetOutput()
        {
            return "42\n";
        }

        public string GetInput()
        {
            return "";
        }
    }
}