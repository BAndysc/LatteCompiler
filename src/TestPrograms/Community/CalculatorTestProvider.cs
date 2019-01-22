using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// int main() {
//     Node w = plus(minus(liczba(4), liczba(3)), razy(liczba(2), podziel(liczba(4), liczba(2))));
//     printInt(w.value());
//     return 0;
// }
// 
// Node plus(Node n1, Node n2) {
//     Operator res = new Plus;
//     res.left = n1;
//     res.right = n2;
//     return res;
// }
// Node razy(Node n1, Node n2) {
//     Operator res = new Razy;
//     res.left = n1;
//     res.right = n2;
//     return res;
// }
// Node podziel(Node n1, Node n2) {
//     Operator res = new Podziel;
//     res.left = n1;
//     res.right = n2;
//     return res;
// }
// Node minus(Node n1, Node n2) {
//     Operator res = new Minus;
//     res.left = n1;
//     res.right = n2;
//     return res;
// }
// Node liczba(int l) {
//     Liczba res = new Liczba;
//     res.v = l;
//     return res;
// }
// 
// class Node {
//     int value() {
//         error();
//         return 0;
//     }
// }
// 
// class Liczba extends Node {
//     int v;
//     int value() {
//         return v;
//     }
// }
// 
// class Operator extends Node {
//     Node left;
//     Node right;
// 
//     int operator(int n1, int n2) {
//         error();
//         return 0;
//     }
//     int value() {
//         return this.operator(left.value(), right.value());
//     }
// }
// 
// class Plus extends Operator {
//     int operator(int a, int b) {
//         return a + b;
//     }
// }
// 
// class Minus extends Operator {
//     int operator(int a, int b) {
//         return a - b;
//     }
// }
// 
// class Razy extends Operator {
//     int operator(int a, int b) {
//         return a * b;
//     }
// }
// 
// class Podziel extends Operator {
//     int operator(int a, int b) {
//         return a / b;
//     }
// }
// 

namespace TestPrograms.Community
{
    public class TestProgramProviderCalculator : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("w",
                            new FunctionCallNode(new DummyFilePlace(), "plus",
                                new FunctionCallNode(new DummyFilePlace(), "minus",
                                    new FunctionCallNode(new DummyFilePlace(), "liczba",
                                        new IntNode(4, new DummyFilePlace())),
                                    new FunctionCallNode(new DummyFilePlace(), "liczba",
                                        new IntNode(3, new DummyFilePlace()))),
                                new FunctionCallNode(new DummyFilePlace(), "razy",
                                    new FunctionCallNode(new DummyFilePlace(), "liczba",
                                        new IntNode(2, new DummyFilePlace())),
                                    new FunctionCallNode(new DummyFilePlace(), "podziel",
                                        new FunctionCallNode(new DummyFilePlace(), "liczba",
                                            new IntNode(4, new DummyFilePlace())),
                                        new FunctionCallNode(new DummyFilePlace(), "liczba",
                                            new IntNode(2, new DummyFilePlace()))))))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("w", new DummyFilePlace()),
                                "value", new List<IExpressionNode>()))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Node"), "plus", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), new LatteType("Operator"),
                            new SingleDeclaration("res",
                                new NewObjectNode(new DummyFilePlace(), new LatteType("Plus")))),
                        new StructAssignmentNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()),
                            "left", new VariableNode("n1", new DummyFilePlace())),
                        new StructAssignmentNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()),
                            "right", new VariableNode("n2", new DummyFilePlace())),
                        new ReturnNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()))),
                    new FunctionArgument(new LatteType("Node"), "n1"),
                    new FunctionArgument(new LatteType("Node"), "n2")),
                new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Node"), "razy", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), new LatteType("Operator"),
                            new SingleDeclaration("res",
                                new NewObjectNode(new DummyFilePlace(), new LatteType("Razy")))),
                        new StructAssignmentNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()),
                            "left", new VariableNode("n1", new DummyFilePlace())),
                        new StructAssignmentNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()),
                            "right", new VariableNode("n2", new DummyFilePlace())),
                        new ReturnNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()))),
                    new FunctionArgument(new LatteType("Node"), "n1"),
                    new FunctionArgument(new LatteType("Node"), "n2")),
                new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Node"), "podziel", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), new LatteType("Operator"),
                            new SingleDeclaration("res",
                                new NewObjectNode(new DummyFilePlace(), new LatteType("Podziel")))),
                        new StructAssignmentNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()),
                            "left", new VariableNode("n1", new DummyFilePlace())),
                        new StructAssignmentNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()),
                            "right", new VariableNode("n2", new DummyFilePlace())),
                        new ReturnNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()))),
                    new FunctionArgument(new LatteType("Node"), "n1"),
                    new FunctionArgument(new LatteType("Node"), "n2")),
                new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Node"), "minus", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), new LatteType("Operator"),
                            new SingleDeclaration("res",
                                new NewObjectNode(new DummyFilePlace(), new LatteType("Minus")))),
                        new StructAssignmentNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()),
                            "left", new VariableNode("n1", new DummyFilePlace())),
                        new StructAssignmentNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()),
                            "right", new VariableNode("n2", new DummyFilePlace())),
                        new ReturnNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()))),
                    new FunctionArgument(new LatteType("Node"), "n1"),
                    new FunctionArgument(new LatteType("Node"), "n2")),
                new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Node"), "liczba", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), new LatteType("Liczba"),
                            new SingleDeclaration("res",
                                new NewObjectNode(new DummyFilePlace(), new LatteType("Liczba")))),
                        new StructAssignmentNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()),
                            "v",
                            new VariableNode("l", new DummyFilePlace())),
                        new ReturnNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()))),
                    new FunctionArgument(LatteType.Int, "l"))
            }, new List<IClassDefinitionNode>
            {
                new ClassDefinitionNode(new DummyFilePlace(), "Node", null, new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "value", new BlockNode(
                        new DummyFilePlace(),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "error")),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
                }),
                new ClassDefinitionNode(new DummyFilePlace(), "Liczba", "Node",
                    new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "value",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("v", new DummyFilePlace()))))
                    }, new ClassFieldNode(new DummyFilePlace(), "v", LatteType.Int)),
                new ClassDefinitionNode(
                    new DummyFilePlace(), "Operator", "Node", new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "operator", new BlockNode(
                                new DummyFilePlace(),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode(new DummyFilePlace(), "error")),
                                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))),
                            new FunctionArgument(LatteType.Int, "n1"), new FunctionArgument(LatteType.Int, "n2")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "value",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("this", new DummyFilePlace()), "operator",
                                        new List<IExpressionNode>
                                        {
                                            new MethodCallNode(new DummyFilePlace(),
                                                new VariableNode("left", new DummyFilePlace()), "value",
                                                new List<IExpressionNode>()),
                                            new MethodCallNode(new DummyFilePlace(),
                                                new VariableNode("right", new DummyFilePlace()), "value",
                                                new List<IExpressionNode>())
                                        }))))
                    }, new ClassFieldNode(new DummyFilePlace(), "left", new LatteType("Node")),
                    new ClassFieldNode(new DummyFilePlace(), "right", new LatteType("Node"))),
                new ClassDefinitionNode(new DummyFilePlace(), "Plus", "Operator", new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "operator", new BlockNode(
                            new DummyFilePlace(), new ReturnNode(new DummyFilePlace(), new BinaryNode(
                                BinaryOperator.Add,
                                new VariableNode("a", new DummyFilePlace()),
                                new VariableNode("b", new DummyFilePlace()),
                                new DummyFilePlace()))), new FunctionArgument(LatteType.Int, "a"),
                        new FunctionArgument(LatteType.Int, "b"))
                }),
                new ClassDefinitionNode(new DummyFilePlace(), "Minus", "Operator", new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "operator", new BlockNode(
                            new DummyFilePlace(), new ReturnNode(new DummyFilePlace(), new BinaryNode(
                                BinaryOperator.Sub,
                                new VariableNode("a", new DummyFilePlace()),
                                new VariableNode("b", new DummyFilePlace()),
                                new DummyFilePlace()))), new FunctionArgument(LatteType.Int, "a"),
                        new FunctionArgument(LatteType.Int, "b"))
                }),
                new ClassDefinitionNode(new DummyFilePlace(), "Razy", "Operator", new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "operator", new BlockNode(
                            new DummyFilePlace(), new ReturnNode(new DummyFilePlace(), new BinaryNode(
                                BinaryOperator.Mul,
                                new VariableNode("a", new DummyFilePlace()),
                                new VariableNode("b", new DummyFilePlace()),
                                new DummyFilePlace()))), new FunctionArgument(LatteType.Int, "a"),
                        new FunctionArgument(LatteType.Int, "b"))
                }),
                new ClassDefinitionNode(new DummyFilePlace(), "Podziel", "Operator", new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "operator", new BlockNode(
                            new DummyFilePlace(), new ReturnNode(new DummyFilePlace(), new BinaryNode(
                                BinaryOperator.Div,
                                new VariableNode("a", new DummyFilePlace()),
                                new VariableNode("b", new DummyFilePlace()),
                                new DummyFilePlace()))), new FunctionArgument(LatteType.Int, "a"),
                        new FunctionArgument(LatteType.Int, "b"))
                })
            });
        }

        public string GetOutput()
        {
            return @"5
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}