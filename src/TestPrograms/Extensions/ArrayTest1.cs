using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
// 
//   int[] a = new int[10];
//   int j=0;
//   while (j<a.length) {
//      a[j] = j;
//      j++;
//   }
// 
//   for (int x : a) 
//      printInt(x);
// 
//   int x = 45;
//   printInt(x);
//   return 0;
// }

namespace TestPrograms.Extensions
{
    public class TestProgramProviderArray001 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType(LatteType.Int),
                        new SingleDeclaration("a",
                            new NewArrayNode(new DummyFilePlace(), LatteType.Int,
                                new IntNode(10, new DummyFilePlace())))),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("j", new IntNode(0, new DummyFilePlace()))),
                    new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                        new VariableNode("j", new DummyFilePlace()),
                        new ObjectFieldNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                            "length"),
                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ArrayAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                new VariableNode("j", new DummyFilePlace()),
                                new VariableNode("j", new DummyFilePlace())),
                            new IncrementNode(new DummyFilePlace(), "j"))))),
                    new ForEachNode(new DummyFilePlace(), LatteType.Int, "x",
                        new VariableNode("a", new DummyFilePlace()),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printInt",
                                    new VariableNode("x", new DummyFilePlace()))))),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("x", new IntNode(45, new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new VariableNode("x", new DummyFilePlace()))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>());
        }

        public string GetOutput()
        {
            return @"0
1
2
3
4
5
6
7
8
9
45
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}