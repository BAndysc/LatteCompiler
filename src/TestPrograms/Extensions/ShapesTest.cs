using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// class Node {
//   Shape elem;
//   Node next;
// 
//   void setElem(Shape c) { elem = c; }
// 
//   void setNext(Node n) { next = n; }
// 
//   Shape getElem() { return elem; }
// 
//   Node getNext() { return next; }
// }
// 
// class Stack {
//   Node head;
// 
//   void push(Shape c) {
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
//   Shape top() {
//     return head.getElem();
//   }
// 
//   void pop() {
//     head = head.getNext();
//   }
// }
// 
// class Shape {
//   void tell () {
//     printString("I'm a shape");
//   }
// 
//   void tellAgain() {
//      printString("I'm just a shape");
//   }
// }
// 
// class Rectangle extends Shape {
//   void tellAgain() {
//     printString("I'm really a rectangle");
//   }
// }
// 
// class Circle extends Shape {
//   void tellAgain() {
//     printString("I'm really a circle");
//   }
// }
// 
// class Square extends Rectangle {
//   void tellAgain() {
//     printString("I'm really a square");
//   }
// }
// 
// int main() {
//   Stack stk = new Stack;
//   Shape s = new Shape;
//   stk.push(s);
//   s = new Rectangle;
//   stk.push(s);
//   s = new Square;
//   stk.push(s);
//   s = new Circle;
//   stk.push(s);
//   while (!stk.isEmpty()) {
//     s = stk.top();
//     s.tell();
//     s.tellAgain();
//     stk.pop();
//   }
//   return 0;
// }
// 

namespace TestPrograms.Extensions
{
    public class TestProgramProviderShapes : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Stack"),
                        new SingleDeclaration("stk", new NewObjectNode(new DummyFilePlace(), new LatteType("Stack")))),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Shape"),
                        new SingleDeclaration("s", new NewObjectNode(new DummyFilePlace(), new LatteType("Shape")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("stk", new DummyFilePlace()), "push",
                            new List<IExpressionNode> {new VariableNode("s", new DummyFilePlace())})),
                    new AssignmentNode(new DummyFilePlace(), "s",
                        new NewObjectNode(new DummyFilePlace(), new LatteType("Rectangle"))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("stk", new DummyFilePlace()), "push",
                            new List<IExpressionNode> {new VariableNode("s", new DummyFilePlace())})),
                    new AssignmentNode(new DummyFilePlace(), "s",
                        new NewObjectNode(new DummyFilePlace(), new LatteType("Square"))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("stk", new DummyFilePlace()), "push",
                            new List<IExpressionNode> {new VariableNode("s", new DummyFilePlace())})),
                    new AssignmentNode(new DummyFilePlace(), "s",
                        new NewObjectNode(new DummyFilePlace(), new LatteType("Circle"))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("stk", new DummyFilePlace()), "push",
                            new List<IExpressionNode> {new VariableNode("s", new DummyFilePlace())})),
                    new WhileNode(new DummyFilePlace(),
                        new LogicalNegateNode(
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("stk", new DummyFilePlace()),
                                "isEmpty", new List<IExpressionNode>()), new DummyFilePlace()), new BlockNode(
                            new DummyFilePlace(), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "s",
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("stk", new DummyFilePlace()), "top",
                                        new List<IExpressionNode>())),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("s", new DummyFilePlace()), "tell",
                                        new List<IExpressionNode>())),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("s", new DummyFilePlace()), "tellAgain",
                                        new List<IExpressionNode>())),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("stk", new DummyFilePlace()), "pop",
                                        new List<IExpressionNode>())))))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>
            {
                new ClassDefinitionNode(new DummyFilePlace(), "Shape", null,
                    new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "tell",
                            new BlockNode(new DummyFilePlace(),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode(new DummyFilePlace(), "printString",
                                        new StringNode("I'm a shape", new DummyFilePlace()))))),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "tellAgain",
                            new BlockNode(new DummyFilePlace(),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode(new DummyFilePlace(), "printString",
                                        new StringNode("I'm just a shape", new DummyFilePlace())))))
                    }),
                new ClassDefinitionNode(new DummyFilePlace(), "Stack", null, new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "push", new BlockNode(
                            new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                                new SingleDeclaration("newHead",
                                    new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new MethodCallNode(new DummyFilePlace(),
                                    new VariableNode("newHead", new DummyFilePlace()),
                                    "setElem",
                                    new List<IExpressionNode> {new VariableNode("c", new DummyFilePlace())})),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new MethodCallNode(new DummyFilePlace(),
                                    new VariableNode("newHead", new DummyFilePlace()),
                                    "setNext",
                                    new List<IExpressionNode> {new VariableNode("head", new DummyFilePlace())})),
                            new AssignmentNode(new DummyFilePlace(), "head",
                                new VariableNode("newHead", new DummyFilePlace()))),
                        new FunctionArgument(new LatteType("Shape"), "c")),
                    new FunctionDefinitionNode(new DummyFilePlace(),
                        LatteType.Bool, "isEmpty", new BlockNode(new DummyFilePlace(), new ReturnNode(
                            new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                new VariableNode("head", new DummyFilePlace()),
                                new CastExpressionNode(new DummyFilePlace(), new LatteType("Node"),
                                    new NullNode(new DummyFilePlace()), false),
                                new DummyFilePlace())))),
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Shape"), "top",
                        new BlockNode(new DummyFilePlace(),
                            new ReturnNode(new DummyFilePlace(),
                                new MethodCallNode(new DummyFilePlace(), new VariableNode("head", new DummyFilePlace()),
                                    "getElem", new List<IExpressionNode>())))),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "pop",
                        new BlockNode(new DummyFilePlace(),
                            new AssignmentNode(new DummyFilePlace(), "head",
                                new MethodCallNode(new DummyFilePlace(), new VariableNode("head", new DummyFilePlace()),
                                    "getNext", new List<IExpressionNode>()))))
                }, new ClassFieldNode(new DummyFilePlace(), "head", new LatteType("Node"))),
                new ClassDefinitionNode(new DummyFilePlace(), "Node", null,
                    new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "setElem",
                            new BlockNode(new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "elem",
                                    new VariableNode("c", new DummyFilePlace()))),
                            new FunctionArgument(new LatteType("Shape"), "c")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "setNext",
                            new BlockNode(new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "next",
                                    new VariableNode("n", new DummyFilePlace()))),
                            new FunctionArgument(new LatteType("Node"), "n")),
                        new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Shape"), "getElem",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("elem", new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Node"), "getNext",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("next", new DummyFilePlace()))))
                    }, new ClassFieldNode(new DummyFilePlace(), "elem", new LatteType("Shape")),
                    new ClassFieldNode(new DummyFilePlace(), "next", new LatteType("Node"))),
                new ClassDefinitionNode(new DummyFilePlace(), "Rectangle", "Shape",
                    new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "tellAgain",
                            new BlockNode(new DummyFilePlace(),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode(new DummyFilePlace(), "printString",
                                        new StringNode("I'm really a rectangle", new DummyFilePlace())))))
                    }),
                new ClassDefinitionNode(new DummyFilePlace(), "Circle", "Shape",
                    new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "tellAgain",
                            new BlockNode(new DummyFilePlace(),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode(new DummyFilePlace(), "printString",
                                        new StringNode("I'm really a circle", new DummyFilePlace())))))
                    }),
                new ClassDefinitionNode(new DummyFilePlace(), "Square", "Rectangle",
                    new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "tellAgain",
                            new BlockNode(new DummyFilePlace(),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode(new DummyFilePlace(), "printString",
                                        new StringNode("I'm really a square", new DummyFilePlace())))))
                    })
            });
        }

        public string GetOutput()
        {
            return @"I'm a shape
I'm really a circle
I'm a shape
I'm really a square
I'm a shape
I'm really a rectangle
I'm a shape
I'm just a shape
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}