using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int [] doubleArray (int [] a){
//   int [] res = new int [a . length];
//   int i = 0 ;
//   for (int n : a){
//     res [i] = 2 * n ;
//     i ++ ;
//   }
//   return res ;
// }
// 
// void shiftLeft (int [] a){
//   int x = a [0];
//   int i = 0 ;
//   while (i < a.length - 1){
//     a [i] = a [i + 1];
//     i ++ ;
//   }
//   a[a.length - 1]= x ;
//   return;
//  }
// 
// int scalProd(int[] a, int[] b) {
//   int res = 0;
//   int i = 0;
//   while (i < a.length) {
//     res = res + a[i] * b[i];
//     i++;
//   }
//   return res;
// }
// 
// int main () {
//   int [] a = new int [5];
//   int i = 0 ;
//   while (i < a.length){
//     a [i]= i ;
//     i ++ ;
//     }
//   shiftLeft (a);
//   int [] b = doubleArray (a);
//   for (int x : a)printInt (x);
//   for (int x : b)printInt (x);
//   printInt(scalProd(a,b));
//   return 0 ;
// }
//  

namespace TestPrograms.Extensions
{
    public class TestProgramProviderArray002 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), new LatteType(LatteType.Int), "doubleArray",
                    new BlockNode(new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), new LatteType(LatteType.Int),
                            new SingleDeclaration("res",
                                new NewArrayNode(new DummyFilePlace(), LatteType.Int,
                                    new ObjectFieldNode(new DummyFilePlace(),
                                        new VariableNode("a", new DummyFilePlace()), "length")))),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))),
                        new ForEachNode(new DummyFilePlace(), LatteType.Int, "n",
                            new VariableNode("a", new DummyFilePlace()), new BlockNode(new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(), new ArrayAssignmentNode(new DummyFilePlace(),
                                        new VariableNode("res", new DummyFilePlace()),
                                        new VariableNode("i", new DummyFilePlace()), new BinaryNode(BinaryOperator.Mul,
                                            new IntNode(2, new DummyFilePlace()),
                                            new VariableNode("n", new DummyFilePlace()),
                                            new DummyFilePlace())),
                                    new IncrementNode(new DummyFilePlace(), "i")))),
                        new ReturnNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()))),
                    new FunctionArgument(new LatteType(LatteType.Int), "a")),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "shiftLeft", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("x",
                            new ArrayAccessNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                new IntNode(0, new DummyFilePlace())))),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))),
                    new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                        new VariableNode("i", new DummyFilePlace()),
                        new BinaryNode(BinaryOperator.Sub,
                            new ObjectFieldNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                "length"),
                            new IntNode(1, new DummyFilePlace()),
                            new DummyFilePlace()),
                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(), new ArrayAssignmentNode(new DummyFilePlace(),
                                new VariableNode("a", new DummyFilePlace()),
                                new VariableNode("i", new DummyFilePlace()), new ArrayAccessNode(new DummyFilePlace(),
                                    new VariableNode("a", new DummyFilePlace()), new BinaryNode(BinaryOperator.Add,
                                        new VariableNode("i", new DummyFilePlace()),
                                        new IntNode(1, new DummyFilePlace()),
                                        new DummyFilePlace()))),
                            new IncrementNode(new DummyFilePlace(), "i"))))),
                    new ArrayAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                        new BinaryNode(BinaryOperator.Sub,
                            new ObjectFieldNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                "length"),
                            new IntNode(1, new DummyFilePlace()),
                            new DummyFilePlace()), new VariableNode("x", new DummyFilePlace())),
                    new VoidReturnNode(new DummyFilePlace())), new FunctionArgument(new LatteType(LatteType.Int), "a")),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "scalProd", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("res", new IntNode(0, new DummyFilePlace()))),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))),
                        new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                            new VariableNode("i", new DummyFilePlace()),
                            new ObjectFieldNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                "length"),
                            new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                            new DummyFilePlace(),
                            new BlockNode(new DummyFilePlace(), new AssignmentNode(new DummyFilePlace(), "res",
                                    new BinaryNode(BinaryOperator.Add,
                                        new VariableNode("res", new DummyFilePlace()),
                                        new BinaryNode(BinaryOperator.Mul,
                                            new ArrayAccessNode(new DummyFilePlace(),
                                                new VariableNode("a", new DummyFilePlace()),
                                                new VariableNode("i", new DummyFilePlace())),
                                            new ArrayAccessNode(new DummyFilePlace(),
                                                new VariableNode("b", new DummyFilePlace()),
                                                new VariableNode("i", new DummyFilePlace())),
                                            new DummyFilePlace()),
                                        new DummyFilePlace())),
                                new IncrementNode(new DummyFilePlace(), "i"))))),
                        new ReturnNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()))),
                    new FunctionArgument(new LatteType(LatteType.Int), "a"),
                    new FunctionArgument(new LatteType(LatteType.Int), "b")),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType(LatteType.Int),
                        new SingleDeclaration("a",
                            new NewArrayNode(new DummyFilePlace(), LatteType.Int,
                                new IntNode(5, new DummyFilePlace())))),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))),
                    new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                        new VariableNode("i", new DummyFilePlace()),
                        new ObjectFieldNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                            "length"),
                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ArrayAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                new VariableNode("i", new DummyFilePlace()),
                                new VariableNode("i", new DummyFilePlace())),
                            new IncrementNode(new DummyFilePlace(), "i"))))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "shiftLeft",
                            new VariableNode("a", new DummyFilePlace()))),
                    new DeclarationNode(new DummyFilePlace(), new LatteType(LatteType.Int),
                        new SingleDeclaration("b",
                            new FunctionCallNode(new DummyFilePlace(), "doubleArray",
                                new VariableNode("a", new DummyFilePlace())))),
                    new ForEachNode(new DummyFilePlace(), LatteType.Int, "x",
                        new VariableNode("a", new DummyFilePlace()),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printInt",
                                    new VariableNode("x", new DummyFilePlace()))))),
                    new ForEachNode(new DummyFilePlace(), LatteType.Int, "x",
                        new VariableNode("b", new DummyFilePlace()),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printInt",
                                    new VariableNode("x", new DummyFilePlace()))))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new FunctionCallNode(new DummyFilePlace(), "scalProd",
                                new VariableNode("a", new DummyFilePlace()),
                                new VariableNode("b", new DummyFilePlace())))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>());
        }

        public string GetOutput()
        {
            return @"1
2
3
4
0
2
4
6
8
0
60
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}