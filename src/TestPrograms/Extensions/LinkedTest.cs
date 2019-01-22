using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// class Node {
//   int elem;
//   Node next;
// 
//   void setElem(int c) { elem = c; }
// 
//   void setNext(Node n) { next = n; }
// 
//   int getElem() { return elem; }
// 
//   Node getNext() { return next; }
// }
// 
// class Stack {
//   Node head;
// 
//   void push(int c) {
//     Node newHead = new Node;
//     newHead.setElem(c);
//     newHead.setNext(head);
//     head = newHead;
//   }
// 
//   boolean isEmpty() {
//     return head==(Node)null;
//   }
// 
//   int top() {
//     return head.getElem();
//   }
// 
//   void pop() {
//     head = head.getNext();
//   }
// }
// 
// int main() {
//    Stack s = new Stack;
//    int i= 0;
//    while (i<10) {
//      s.push(i);
//      i++;
//    }
//      
//    while (!s.isEmpty()) {
//      printInt(s.top());
//      s.pop();
//    }
//    return 0;
// }
// 

namespace TestPrograms.Extensions
{
    public class TestProgramProviderLinked : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Stack"),
                        new SingleDeclaration("s", new NewObjectNode(new DummyFilePlace(), new LatteType("Stack")))),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))),
                    new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                        new VariableNode("i", new DummyFilePlace()),
                        new IntNode(10, new DummyFilePlace()),
                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new MethodCallNode(new DummyFilePlace(), new VariableNode("s", new DummyFilePlace()),
                                    "push", new List<IExpressionNode> {new VariableNode("i", new DummyFilePlace())})),
                            new IncrementNode(new DummyFilePlace(), "i"))))),
                    new WhileNode(new DummyFilePlace(),
                        new LogicalNegateNode(
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("s", new DummyFilePlace()),
                                "isEmpty", new List<IExpressionNode>()), new DummyFilePlace()), new BlockNode(
                            new DummyFilePlace(), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode(new DummyFilePlace(), "printInt",
                                        new MethodCallNode(new DummyFilePlace(),
                                            new VariableNode("s", new DummyFilePlace()), "top",
                                            new List<IExpressionNode>()))),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("s", new DummyFilePlace()), "pop",
                                        new List<IExpressionNode>())))))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>
            {
                new ClassDefinitionNode(new DummyFilePlace(), "Node", null,
                    new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "setElem",
                            new BlockNode(new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "elem",
                                    new VariableNode("c", new DummyFilePlace()))),
                            new FunctionArgument(LatteType.Int, "c")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "setNext",
                            new BlockNode(new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "next",
                                    new VariableNode("n", new DummyFilePlace()))),
                            new FunctionArgument(new LatteType("Node"), "n")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "getElem",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("elem", new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Node"), "getNext",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("next", new DummyFilePlace()))))
                    }, new ClassFieldNode(new DummyFilePlace(), "elem", LatteType.Int),
                    new ClassFieldNode(new DummyFilePlace(), "next", new LatteType("Node"))),
                new ClassDefinitionNode(
                    new DummyFilePlace(), "Stack", null, new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "push", new BlockNode(
                                new DummyFilePlace(),
                                new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                                    new SingleDeclaration("newHead",
                                        new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("newHead", new DummyFilePlace()), "setElem",
                                        new List<IExpressionNode> {new VariableNode("c", new DummyFilePlace())})),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("newHead", new DummyFilePlace()), "setNext",
                                        new List<IExpressionNode> {new VariableNode("head", new DummyFilePlace())})),
                                new AssignmentNode(new DummyFilePlace(), "head",
                                    new VariableNode("newHead", new DummyFilePlace()))),
                            new FunctionArgument(LatteType.Int, "c")),
                        new FunctionDefinitionNode(new DummyFilePlace(),
                            LatteType.Bool, "isEmpty", new BlockNode(new DummyFilePlace(), new ReturnNode(
                                new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                    new VariableNode("head", new DummyFilePlace()),
                                    new CastExpressionNode(new DummyFilePlace(), new LatteType("Node"),
                                        new NullNode(new DummyFilePlace()), false),
                                    new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "top",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("head", new DummyFilePlace()), "getElem",
                                        new List<IExpressionNode>())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "pop",
                            new BlockNode(new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "head",
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("head", new DummyFilePlace()), "getNext",
                                        new List<IExpressionNode>()))))
                    }, new ClassFieldNode(new DummyFilePlace(), "head", new LatteType("Node")))
            });
        }

        public string GetOutput()
        {
            return @"9
8
7
6
5
4
3
2
1
0
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}