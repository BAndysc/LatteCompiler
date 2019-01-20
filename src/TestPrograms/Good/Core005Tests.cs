using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// /* usage of variable initialized in both branches. */
// 
// int main () {
//   int x;
//   int y = 56;
//   if (y + 45 <= 2) {
//     x = 1;
//   } else {
//     x = 2;
//   }
//   printInt(x);
//   return 0 ;
// 
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderCore005 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>()
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>() {new SingleDeclaration("x", null)}),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                    {new SingleDeclaration("y", new IntNode(56, new DummyFilePlace()))}),
                            new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.LessEquals,
                                new BinaryNode(BinaryOperator.Add,
                                    new VariableNode("y", new DummyFilePlace()),
                                    new IntNode(45, new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new IntNode(2, new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new AssignmentNode(new DummyFilePlace(), "x", new IntNode(1, new DummyFilePlace()))
                            }), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new AssignmentNode(new DummyFilePlace(), "x", new IntNode(2, new DummyFilePlace()))
                            })),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>() {new VariableNode("x", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        }))
                });
        }

        public string GetOutput()
        {
            return "2\n";
        }

        public string GetInput()
        {
            return "";
        }
    }
}