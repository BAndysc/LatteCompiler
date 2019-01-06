using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* parity of positive integers by loop */
// 
// int main () {
//   int y = 17;
//   while (y > 0)
//     y = y - 2;
//   if (y < 0) {
//     printInt(0);
//     return 0 ;
//     }
//   else {
//     printInt(1);
//     return 0 ;
//     }
// }
// 

namespace TestPrograms.Good
{
    public class TestProgramProviderCore016 : ITestProgramProvider
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
                                    {new SingleDeclaration("y", new IntNode(17, new DummyFilePlace()))}),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                new VariableNode("y", new DummyFilePlace()),
                                new IntNode(0, new DummyFilePlace()),
                                new DummyFilePlace()), new AssignmentNode(new DummyFilePlace(), "y", new BinaryNode(
                                BinaryOperator.Sub,
                                new VariableNode("y", new DummyFilePlace()),
                                new IntNode(2, new DummyFilePlace()),
                                new DummyFilePlace()))),
                            new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                new VariableNode("y", new DummyFilePlace()),
                                new IntNode(0, new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new IntNode(0, new DummyFilePlace())},
                                        new DummyFilePlace())),
                                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                            }), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new IntNode(1, new DummyFilePlace())},
                                        new DummyFilePlace())),
                                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                            }))
                        }))
                });
        }

        public string GetOutput()
        {
            return "0\n";
        }

        public string GetInput()
        {
            return null;
        }
    }
}