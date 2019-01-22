using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// // Author: Robert Rosolek 277585
// //
// // input is in format :
// // n    <-- number of elements to sort
// // a_1
// // ...       <-- elements to sort
// // a_n
// //
// // code based on wazniak.mimuw.edu.pl
// 
// // assuming that a[p + 1] ... a[r] is a heap,
// // this function makes a[p] ... a[r] a heap 
// void maxHeapify(int[] a, int p, int r) {
// 	int s = p, v = a[s];
// 	while (2 * s <= r) {
// 		int t = 2 * s;
// 		if (t < r)
// 			if (a[t + 1] > a[t])
// 				t++;
// 		if (v >= a[t]) {
// 			a[s] = v;
// 			s = r + 1; // force to leave the loop
// 		}
// 		else {
// 			a[s] = a[t];
// 			s = t;
// 		}
// 	}
// 	if (s <= r)
// 		a[s] = v;
// } 
// 
// int main() {
// 
// 	// number of elements to sort
// 	int n;
// 	
// 	// array of elements to sort
// 	int[] a; 
//     
//     // read data from input
//     n = readInt();
//     a = new int[n];
//     int i = 0;
// 	while (i < a.length) {
// 		a[i] = readInt();
// 		i++;
// 	}
//     	
//     // build heap
//     i = (n - 1) / 2;
//     while (i >= 0) {
//     	maxHeapify(a, i, n - 1);
//     	i--;
//     }
//  
//  	// sort   	
//     i = n - 1;
//     while (i >= 1) {
//     	// swap a[i] and a[0]
//     	int tmp = a[i];
//     	a[i] = a[0];
//     	a[0] = tmp;
//     	
//     	maxHeapify(a, 0, i - 1);
//     	
//     	i--;
//     }
// 
// 	// assert that array is sorted    
// 	i = 0;
// 	while (i < n - 1) {
// 		if (a[i] > a[i + 1])
// 			error();
// 		i++;
// 	}
// 	
// 	// output sorted array
// 	for (int it : a)
// 		printInt(it);
// 		
// 	return 0;
// }
// 

namespace TestPrograms.Community
{
    public class TestProgramProviderHeapsort2 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "maxHeapify", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("s", new VariableNode("p", new DummyFilePlace())),
                            new SingleDeclaration("v",
                                new ArrayAccessNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                    new VariableNode("s", new DummyFilePlace())))),
                        new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessEquals,
                            new BinaryNode(BinaryOperator.Mul,
                                new IntNode(2, new DummyFilePlace()),
                                new VariableNode("s", new DummyFilePlace()),
                                new DummyFilePlace()),
                            new VariableNode("r", new DummyFilePlace()),
                            new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                            new DummyFilePlace(),
                            new BlockNode(new DummyFilePlace(), new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new SingleDeclaration("t", new BinaryNode(BinaryOperator.Mul,
                                        new IntNode(2, new DummyFilePlace()),
                                        new VariableNode("s", new DummyFilePlace()),
                                        new DummyFilePlace()))),
                                new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                    new VariableNode("t", new DummyFilePlace()),
                                    new VariableNode("r", new DummyFilePlace()),
                                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                    new DummyFilePlace(), new IfNode(new DummyFilePlace(), new CompareNode(
                                            RelOperator.GreaterThan,
                                            new ArrayAccessNode(new DummyFilePlace(),
                                                new VariableNode("a", new DummyFilePlace()), new BinaryNode(
                                                    BinaryOperator.Add,
                                                    new VariableNode("t", new DummyFilePlace()),
                                                    new IntNode(1, new DummyFilePlace()),
                                                    new DummyFilePlace())),
                                            new ArrayAccessNode(new DummyFilePlace(),
                                                new VariableNode("a", new DummyFilePlace()),
                                                new VariableNode("t", new DummyFilePlace())),
                                            new DummyFilePlace()),
                                        new BlockNode(new DummyFilePlace(),
                                            new BlockNode(new DummyFilePlace(),
                                                new IncrementNode(new DummyFilePlace(), "t"))))))),
                                new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterEquals,
                                    new VariableNode("v", new DummyFilePlace()),
                                    new ArrayAccessNode(new DummyFilePlace(),
                                        new VariableNode("a", new DummyFilePlace()),
                                        new VariableNode("t", new DummyFilePlace())),
                                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                    new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                        new ArrayAssignmentNode(new DummyFilePlace(),
                                            new VariableNode("a", new DummyFilePlace()),
                                            new VariableNode("s", new DummyFilePlace()),
                                            new VariableNode("v", new DummyFilePlace())),
                                        new AssignmentNode(new DummyFilePlace(), "s", new BinaryNode(BinaryOperator.Add,
                                            new VariableNode("r", new DummyFilePlace()),
                                            new IntNode(1, new DummyFilePlace()),
                                            new DummyFilePlace()))))), new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                        new ArrayAssignmentNode(new DummyFilePlace(),
                                            new VariableNode("a", new DummyFilePlace()),
                                            new VariableNode("s", new DummyFilePlace()),
                                            new ArrayAccessNode(new DummyFilePlace(),
                                                new VariableNode("a", new DummyFilePlace()),
                                                new VariableNode("t", new DummyFilePlace()))),
                                        new AssignmentNode(new DummyFilePlace(), "s",
                                            new VariableNode("t", new DummyFilePlace())))))))))),
                        new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.LessEquals,
                                new VariableNode("s", new DummyFilePlace()),
                                new VariableNode("r", new DummyFilePlace()),
                                new DummyFilePlace()),
                            new BlockNode(new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(),
                                    new ArrayAssignmentNode(new DummyFilePlace(),
                                        new VariableNode("a", new DummyFilePlace()),
                                        new VariableNode("s", new DummyFilePlace()),
                                        new VariableNode("v", new DummyFilePlace())))))),
                    new FunctionArgument(new LatteType(LatteType.Int), "a"), new FunctionArgument(LatteType.Int, "p"),
                    new FunctionArgument(LatteType.Int, "r")),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int, new SingleDeclaration("n", null)),
                    new DeclarationNode(new DummyFilePlace(), new LatteType(LatteType.Int),
                        new SingleDeclaration("a", null)),
                    new AssignmentNode(new DummyFilePlace(), "n",
                        new FunctionCallNode(new DummyFilePlace(), "readInt")),
                    new AssignmentNode(new DummyFilePlace(), "a",
                        new NewArrayNode(new DummyFilePlace(), LatteType.Int,
                            new VariableNode("n", new DummyFilePlace()))),
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
                                new FunctionCallNode(new DummyFilePlace(), "readInt")),
                            new IncrementNode(new DummyFilePlace(), "i"))))),
                    new AssignmentNode(new DummyFilePlace(), "i", new BinaryNode(BinaryOperator.Div,
                        new BinaryNode(BinaryOperator.Sub,
                            new VariableNode("n", new DummyFilePlace()),
                            new IntNode(1, new DummyFilePlace()),
                            new DummyFilePlace()),
                        new IntNode(2, new DummyFilePlace()),
                        new DummyFilePlace())),
                    new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterEquals,
                        new VariableNode("i", new DummyFilePlace()),
                        new IntNode(0, new DummyFilePlace()),
                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(), new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "maxHeapify",
                                    new VariableNode("a", new DummyFilePlace()),
                                    new VariableNode("i", new DummyFilePlace()), new BinaryNode(BinaryOperator.Sub,
                                        new VariableNode("n", new DummyFilePlace()),
                                        new IntNode(1, new DummyFilePlace()),
                                        new DummyFilePlace()))),
                            new DecrementNode(new DummyFilePlace(), "i"))))),
                    new AssignmentNode(new DummyFilePlace(), "i", new BinaryNode(BinaryOperator.Sub,
                        new VariableNode("n", new DummyFilePlace()),
                        new IntNode(1, new DummyFilePlace()),
                        new DummyFilePlace())),
                    new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterEquals,
                        new VariableNode("i", new DummyFilePlace()),
                        new IntNode(1, new DummyFilePlace()),
                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("tmp",
                                    new ArrayAccessNode(new DummyFilePlace(),
                                        new VariableNode("a", new DummyFilePlace()),
                                        new VariableNode("i", new DummyFilePlace())))),
                            new ArrayAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                new VariableNode("i", new DummyFilePlace()),
                                new ArrayAccessNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                    new IntNode(0, new DummyFilePlace()))),
                            new ArrayAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                new IntNode(0, new DummyFilePlace()), new VariableNode("tmp", new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                                "maxHeapify", new VariableNode("a", new DummyFilePlace()),
                                new IntNode(0, new DummyFilePlace()), new BinaryNode(BinaryOperator.Sub,
                                    new VariableNode("i", new DummyFilePlace()),
                                    new IntNode(1, new DummyFilePlace()),
                                    new DummyFilePlace()))),
                            new DecrementNode(new DummyFilePlace(), "i"))))),
                    new AssignmentNode(new DummyFilePlace(), "i", new IntNode(0, new DummyFilePlace())),
                    new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                        new VariableNode("i", new DummyFilePlace()),
                        new BinaryNode(BinaryOperator.Sub,
                            new VariableNode("n", new DummyFilePlace()),
                            new IntNode(1, new DummyFilePlace()),
                            new DummyFilePlace()),
                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(), new IfNode(new DummyFilePlace(), new CompareNode(
                                    RelOperator.GreaterThan,
                                    new ArrayAccessNode(new DummyFilePlace(),
                                        new VariableNode("a", new DummyFilePlace()),
                                        new VariableNode("i", new DummyFilePlace())),
                                    new ArrayAccessNode(new DummyFilePlace(),
                                        new VariableNode("a", new DummyFilePlace()),
                                        new BinaryNode(BinaryOperator.Add,
                                            new VariableNode("i", new DummyFilePlace()),
                                            new IntNode(1, new DummyFilePlace()),
                                            new DummyFilePlace())),
                                    new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode(new DummyFilePlace(), "error"))))),
                            new IncrementNode(new DummyFilePlace(), "i"))))),
                    new ForEachNode(new DummyFilePlace(), LatteType.Int, "it",
                        new VariableNode("a", new DummyFilePlace()),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printInt",
                                    new VariableNode("it", new DummyFilePlace()))))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>());
        }

        public string GetOutput()
        {
            return @"1
2
3
4
5
6
7
8
9
10
11
45
67
85
255
577
2456
7674
35456
67548
345345
568666
958623
3453453
53456455
477743205
533122678
534508534
";
        }

        public string GetInput()
        {
            return @"28
3 
5 
4 
6 
10 
8 
1 
2 
9 
7
11
45
67
85
2456
255
577
35456
53456455
3453453
345345
7674
67548
958623
477743205
534508534
568666
533122678
";
        }
    }
}