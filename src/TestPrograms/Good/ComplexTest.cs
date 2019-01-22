using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: Bartosz Korczyński

// class Matrix
// {
// 	int N, M;
// 	int[][] m;
// 
// 	void Init(int n, int m)
// 	{
// 		N = n;
// 		M = m;
// 		this.m = alloc_matrix(n, m);
// 	}
// 
// 	void Set(int i, int j, int v)
// 	{
// 		m[i][j] = v;
// 	}
// 
// 	int Get(int i, int j)
// 	{
// 		return m[i][j];
// 	}
// 
// 	void Print()
// 	{
// 		print_matrix(m, N, M);
// 	}
// }
// 
// int[][] alloc_matrix(int n, int m)
// {
// 	int[][] arr = new int[][n];
// 
// 	int i = 0;
// 
// 	while (i < n)
// 	{
// 		arr[i] = new int[m];
// 		i ++;
// 	}
// 
// 	return arr;
// }
// 
// void tabliczka_mnozenia(Matrix matrix)
// {
// 	int i = 0;
// 	while (i < matrix.N)
// 	{
// 		int j = 0;
// 		while (j < matrix.M)
// 		{
// 			matrix.Set(i, j, (i+1)*(j+1));
// 			j++;
// 		}
// 		i++;
// 	}
// }
// 
// void print_matrix(int[][] arr, int n, int m)
// {
// 	int i = 0;
// 	while (i < n)
// 	{
// 		int j = 0;
// 		while (j < m)
// 		{
// 			printInt(arr[i][j]);
// 			j++;
// 		}
// 		printString("----");
// 		i++;
// 	}	
// }
// 
// int main()
// {
// 	string[] t = new string[10];
// 	printString(t[2]);
// 	printString(t[3] + "a");
// 	printString("a" + t[4]);
// 	printString(t[3] + "");
// 	printString(t[3] + t[4]);
// 	
// 	int N=5, M=6;
// 	Matrix matrix = new Matrix;
// 	matrix.Init(N, M);
// 
// 	tabliczka_mnozenia(matrix);
// 
// 	matrix.Print();
// 
// 	return 0;
// }

namespace TestPrograms.Good
{
    public class ComplexTestProvider : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), new LatteType(new LatteType(LatteType.Int)),
                    "alloc_matrix", new BlockNode(new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), new LatteType(new LatteType(LatteType.Int)),
                            new SingleDeclaration("arr",
                                new NewArrayNode(new DummyFilePlace(), new LatteType(LatteType.Int),
                                    new VariableNode("n", new DummyFilePlace())))),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))),
                        new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                            new VariableNode("i", new DummyFilePlace()),
                            new VariableNode("n", new DummyFilePlace()),
                            new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                            new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                new ArrayAssignmentNode(new DummyFilePlace(),
                                    new VariableNode("arr", new DummyFilePlace()),
                                    new VariableNode("i", new DummyFilePlace()),
                                    new NewArrayNode(new DummyFilePlace(), LatteType.Int,
                                        new VariableNode("m", new DummyFilePlace()))),
                                new IncrementNode(new DummyFilePlace(), "i"))))),
                        new ReturnNode(new DummyFilePlace(), new VariableNode("arr", new DummyFilePlace()))),
                    new FunctionArgument(LatteType.Int, "n"), new FunctionArgument(LatteType.Int, "m")),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "tabliczka_mnozenia", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))),
                        new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                            new VariableNode("i", new DummyFilePlace()),
                            new ObjectFieldNode(new DummyFilePlace(), new VariableNode("matrix", new DummyFilePlace()),
                                "N"),
                            new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                            new DummyFilePlace(),
                            new BlockNode(new DummyFilePlace(),
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new SingleDeclaration("j", new IntNode(0, new DummyFilePlace()))),
                                new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                    new VariableNode("j", new DummyFilePlace()),
                                    new ObjectFieldNode(new DummyFilePlace(),
                                        new VariableNode("matrix", new DummyFilePlace()), "M"),
                                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                    new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                        new ExpressionStatementNode(
                                            new DummyFilePlace(), new MethodCallNode(new DummyFilePlace(),
                                                new VariableNode("matrix", new DummyFilePlace()), "Set",
                                                new List<IExpressionNode>
                                                {
                                                    new VariableNode("i", new DummyFilePlace()),
                                                    new VariableNode("j", new DummyFilePlace()), new BinaryNode(
                                                        BinaryOperator.Mul,
                                                        new BinaryNode(BinaryOperator.Add,
                                                            new VariableNode("i", new DummyFilePlace()),
                                                            new IntNode(1, new DummyFilePlace()),
                                                            new DummyFilePlace()),
                                                        new BinaryNode(BinaryOperator.Add,
                                                            new VariableNode("j", new DummyFilePlace()),
                                                            new IntNode(1, new DummyFilePlace()),
                                                            new DummyFilePlace()),
                                                        new DummyFilePlace())
                                                })),
                                        new IncrementNode(new DummyFilePlace(), "j"))))),
                                new IncrementNode(new DummyFilePlace(), "i")))))),
                    new FunctionArgument(new LatteType("Matrix"), "matrix")),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "print_matrix", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))),
                        new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                            new VariableNode("i", new DummyFilePlace()),
                            new VariableNode("n", new DummyFilePlace()),
                            new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                            new DummyFilePlace(),
                            new BlockNode(new DummyFilePlace(),
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new SingleDeclaration("j", new IntNode(0, new DummyFilePlace()))),
                                new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                    new VariableNode("j", new DummyFilePlace()),
                                    new VariableNode("m", new DummyFilePlace()),
                                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                    new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                                new ArrayAccessNode(new DummyFilePlace(),
                                                    new ArrayAccessNode(new DummyFilePlace(),
                                                        new VariableNode("arr", new DummyFilePlace()),
                                                        new VariableNode("i", new DummyFilePlace())),
                                                    new VariableNode("j", new DummyFilePlace())))),
                                        new IncrementNode(new DummyFilePlace(), "j"))))),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode(new DummyFilePlace(), "printString",
                                        new StringNode("----", new DummyFilePlace()))),
                                new IncrementNode(new DummyFilePlace(), "i")))))),
                    new FunctionArgument(new LatteType(new LatteType(LatteType.Int)), "arr"),
                    new FunctionArgument(LatteType.Int, "n"), new FunctionArgument(LatteType.Int, "m")),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType(LatteType.String),
                        new SingleDeclaration("t",
                            new NewArrayNode(new DummyFilePlace(), LatteType.String,
                                new IntNode(10, new DummyFilePlace())))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printString",
                            new ArrayAccessNode(new DummyFilePlace(), new VariableNode("t", new DummyFilePlace()),
                                new IntNode(2, new DummyFilePlace())))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "printString", new BinaryNode(BinaryOperator.Add,
                            new ArrayAccessNode(new DummyFilePlace(), new VariableNode("t", new DummyFilePlace()),
                                new IntNode(3, new DummyFilePlace())),
                            new StringNode("a", new DummyFilePlace()),
                            new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "printString", new BinaryNode(BinaryOperator.Add,
                            new StringNode("a", new DummyFilePlace()),
                            new ArrayAccessNode(new DummyFilePlace(), new VariableNode("t", new DummyFilePlace()),
                                new IntNode(4, new DummyFilePlace())),
                            new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "printString", new BinaryNode(BinaryOperator.Add,
                            new ArrayAccessNode(new DummyFilePlace(), new VariableNode("t", new DummyFilePlace()),
                                new IntNode(3, new DummyFilePlace())),
                            new StringNode("", new DummyFilePlace()),
                            new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "printString", new BinaryNode(BinaryOperator.Add,
                            new ArrayAccessNode(new DummyFilePlace(), new VariableNode("t", new DummyFilePlace()),
                                new IntNode(3, new DummyFilePlace())),
                            new ArrayAccessNode(new DummyFilePlace(), new VariableNode("t", new DummyFilePlace()),
                                new IntNode(4, new DummyFilePlace())),
                            new DummyFilePlace()))),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("N", new IntNode(5, new DummyFilePlace())),
                        new SingleDeclaration("M", new IntNode(6, new DummyFilePlace()))),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Matrix"),
                        new SingleDeclaration("matrix",
                            new NewObjectNode(new DummyFilePlace(), new LatteType("Matrix")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("matrix", new DummyFilePlace()),
                            "Init",
                            new List<IExpressionNode>
                            {
                                new VariableNode("N", new DummyFilePlace()), new VariableNode("M", new DummyFilePlace())
                            })),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "tabliczka_mnozenia",
                            new VariableNode("matrix", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("matrix", new DummyFilePlace()),
                            "Print", new List<IExpressionNode>())),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>
            {
                new ClassDefinitionNode(new DummyFilePlace(), "Matrix", null, new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "Init", new BlockNode(
                                new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "N",
                                    new VariableNode("n", new DummyFilePlace())),
                                new AssignmentNode(new DummyFilePlace(), "M",
                                    new VariableNode("m", new DummyFilePlace())),
                                new StructAssignmentNode(new DummyFilePlace(),
                                    new VariableNode("this", new DummyFilePlace()),
                                    "m",
                                    new FunctionCallNode(new DummyFilePlace(), "alloc_matrix",
                                        new VariableNode("n", new DummyFilePlace()),
                                        new VariableNode("m", new DummyFilePlace())))),
                            new FunctionArgument(LatteType.Int, "n"), new FunctionArgument(LatteType.Int, "m")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "Set",
                            new BlockNode(new DummyFilePlace(),
                                new ArrayAssignmentNode(new DummyFilePlace(),
                                    new ArrayAccessNode(new DummyFilePlace(),
                                        new VariableNode("m", new DummyFilePlace()),
                                        new VariableNode("i", new DummyFilePlace())),
                                    new VariableNode("j", new DummyFilePlace()),
                                    new VariableNode("v", new DummyFilePlace()))),
                            new FunctionArgument(LatteType.Int, "i"),
                            new FunctionArgument(LatteType.Int, "j"), new FunctionArgument(LatteType.Int, "v")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "Get",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(),
                                    new ArrayAccessNode(new DummyFilePlace(),
                                        new ArrayAccessNode(new DummyFilePlace(),
                                            new VariableNode("m", new DummyFilePlace()),
                                            new VariableNode("i", new DummyFilePlace())),
                                        new VariableNode("j", new DummyFilePlace())))),
                            new FunctionArgument(LatteType.Int, "i"), new FunctionArgument(LatteType.Int, "j")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "Print",
                            new BlockNode(new DummyFilePlace(),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode(new DummyFilePlace(), "print_matrix",
                                        new VariableNode("m", new DummyFilePlace()),
                                        new VariableNode("N", new DummyFilePlace()),
                                        new VariableNode("M", new DummyFilePlace())))))
                    }, new ClassFieldNode(new DummyFilePlace(), "N", LatteType.Int),
                    new ClassFieldNode(new DummyFilePlace(), "M", LatteType.Int),
                    new ClassFieldNode(new DummyFilePlace(), "m", new LatteType(new LatteType(LatteType.Int))))
            });
        }

        public string GetOutput()
        {
            return @"
a
a


1
2
3
4
5
6
----
2
4
6
8
10
12
----
3
6
9
12
15
18
----
4
8
12
16
20
24
----
5
10
15
20
25
30
----
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}