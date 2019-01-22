using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// class a {
//     int [] [] [] arr;
//     string length;
//     b nothing;
// }
// 
// class b { }
// 
// b create() { return new b; }
// 
// string check_arr(int[][][] array) {
//     array = new int[][] [1];
//     array[0] = new int[] [1];
//     array[0][0] = new int [1];
// 
//     array[0][0][0] = array[0][0][0] + 1;
// 
//     printInt(array.length);
//     printInt(array[0].length);
//     printInt(array[0][0].length);
// 
//     string a = "";
// 
//     for (int [][] b : array)
//         for (int [] c : b)
//             for (int arr : c)
//                 printInt(arr);
// 
//     return a;
// }
// 
// int main() {
//     a t = new a;
//     t.nothing = create();
//     string hmm = check_arr(t.arr);
//     if (hmm != t.length)
//         printString("error");
//     if (hmm != (new string[1])[0])
//         printString("error");
//     return 0;
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderForForeach : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("b"), "create",
                        new BlockNode(new DummyFilePlace(),
                            new ReturnNode(new DummyFilePlace(),
                                new NewObjectNode(new DummyFilePlace(), new LatteType("b"))))),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.String, "check_arr", new BlockNode(
                            new DummyFilePlace(),
                            new AssignmentNode(new DummyFilePlace(), "array",
                                new NewArrayNode(new DummyFilePlace(), new LatteType(new LatteType(LatteType.Int)),
                                    new IntNode(1, new DummyFilePlace()))),
                            new ArrayAssignmentNode(new DummyFilePlace(),
                                new VariableNode("array", new DummyFilePlace()),
                                new IntNode(0, new DummyFilePlace()),
                                new NewArrayNode(new DummyFilePlace(), new LatteType(LatteType.Int),
                                    new IntNode(1, new DummyFilePlace()))),
                            new ArrayAssignmentNode(new DummyFilePlace(),
                                new ArrayAccessNode(new DummyFilePlace(),
                                    new VariableNode("array", new DummyFilePlace()),
                                    new IntNode(0, new DummyFilePlace())), new IntNode(0, new DummyFilePlace()),
                                new NewArrayNode(new DummyFilePlace(), LatteType.Int,
                                    new IntNode(1, new DummyFilePlace()))),
                            new ArrayAssignmentNode(new DummyFilePlace(),
                                new ArrayAccessNode(new DummyFilePlace(),
                                    new ArrayAccessNode(new DummyFilePlace(),
                                        new VariableNode("array", new DummyFilePlace()),
                                        new IntNode(0, new DummyFilePlace())), new IntNode(0, new DummyFilePlace())),
                                new IntNode(0, new DummyFilePlace()), new BinaryNode(BinaryOperator.Add,
                                    new ArrayAccessNode(new DummyFilePlace(),
                                        new ArrayAccessNode(new DummyFilePlace(),
                                            new ArrayAccessNode(new DummyFilePlace(),
                                                new VariableNode("array", new DummyFilePlace()),
                                                new IntNode(0, new DummyFilePlace())),
                                            new IntNode(0, new DummyFilePlace())),
                                        new IntNode(0, new DummyFilePlace())),
                                    new IntNode(1, new DummyFilePlace()),
                                    new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printInt",
                                    new ObjectFieldNode(new DummyFilePlace(),
                                        new VariableNode("array", new DummyFilePlace()),
                                        "length"))),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printInt",
                                    new ObjectFieldNode(new DummyFilePlace(),
                                        new ArrayAccessNode(new DummyFilePlace(),
                                            new VariableNode("array", new DummyFilePlace()),
                                            new IntNode(0, new DummyFilePlace())), "length"))),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printInt",
                                    new ObjectFieldNode(new DummyFilePlace(),
                                        new ArrayAccessNode(new DummyFilePlace(),
                                            new ArrayAccessNode(new DummyFilePlace(),
                                                new VariableNode("array", new DummyFilePlace()),
                                                new IntNode(0, new DummyFilePlace())),
                                            new IntNode(0, new DummyFilePlace())),
                                        "length"))),
                            new DeclarationNode(new DummyFilePlace(), LatteType.String,
                                new SingleDeclaration("a", new StringNode("", new DummyFilePlace()))),
                            new ForEachNode(new DummyFilePlace(), new LatteType(new LatteType(LatteType.Int)), "b",
                                new VariableNode("array", new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new ForEachNode(new DummyFilePlace(), new LatteType(LatteType.Int), "c",
                                        new VariableNode("b", new DummyFilePlace()),
                                        new BlockNode(new DummyFilePlace(),
                                            new ForEachNode(new DummyFilePlace(), LatteType.Int, "arr",
                                                new VariableNode("c", new DummyFilePlace()),
                                                new BlockNode(new DummyFilePlace(),
                                                    new ExpressionStatementNode(new DummyFilePlace(),
                                                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                                                            new VariableNode("arr", new DummyFilePlace()))))))))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()))),
                        new FunctionArgument(new LatteType(new LatteType(new LatteType(LatteType.Int))), "array")),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), new LatteType("a"),
                            new SingleDeclaration("t", new NewObjectNode(new DummyFilePlace(), new LatteType("a")))),
                        new StructAssignmentNode(new DummyFilePlace(), new VariableNode("t", new DummyFilePlace()),
                            "nothing", new FunctionCallNode(new DummyFilePlace(), "create")),
                        new DeclarationNode(new DummyFilePlace(), LatteType.String,
                            new SingleDeclaration("hmm",
                                new FunctionCallNode(new DummyFilePlace(), "check_arr",
                                    new ObjectFieldNode(new DummyFilePlace(),
                                        new VariableNode("t", new DummyFilePlace()),
                                        "arr")))),
                        new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.NotEquals,
                                new VariableNode("hmm", new DummyFilePlace()),
                                new ObjectFieldNode(new DummyFilePlace(), new VariableNode("t", new DummyFilePlace()),
                                    "length"),
                                new DummyFilePlace()),
                            new BlockNode(new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(),
                                    new ExpressionStatementNode(new DummyFilePlace(),
                                        new FunctionCallNode(new DummyFilePlace(), "printString",
                                            new StringNode("error", new DummyFilePlace())))))),
                        new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.NotEquals,
                                new VariableNode("hmm", new DummyFilePlace()),
                                new ArrayAccessNode(new DummyFilePlace(),
                                    new NewArrayNode(new DummyFilePlace(), LatteType.String,
                                        new IntNode(1, new DummyFilePlace())), new IntNode(0, new DummyFilePlace())),
                                new DummyFilePlace()),
                            new BlockNode(new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(),
                                    new ExpressionStatementNode(new DummyFilePlace(),
                                        new FunctionCallNode(new DummyFilePlace(), "printString",
                                            new StringNode("error", new DummyFilePlace())))))),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
                },
                new List<IClassDefinitionNode>
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "a", null, new List<IFunctionDefinitionNode>(),
                        new ClassFieldNode(new DummyFilePlace(), "arr",
                            new LatteType(new LatteType(new LatteType(LatteType.Int)))),
                        new ClassFieldNode(new DummyFilePlace(), "length", LatteType.String),
                        new ClassFieldNode(new DummyFilePlace(), "nothing", new LatteType("b"))),
                    new ClassDefinitionNode(new DummyFilePlace(), "b", null, new List<IFunctionDefinitionNode>())
                });
        }

        public string GetOutput()
        {
            return @"1
1
1
1
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}