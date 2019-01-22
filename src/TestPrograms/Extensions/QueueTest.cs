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
//   void setElem (int e)  { elem = e; }
//   void setNext (Node n) { next = n; }
// 
//   int  getElem () { return elem; }
//   Node getNext () { return next; }
// 
// }
// 
// class IntQueue {
//   Node front;
//   Node rear;
// 
//   boolean isEmpty () { return front == (Node)null; }
// 
//   void insert (int x) {
//     Node last = new Node;
//     last.setElem(x);
//     if (self.isEmpty())
//       front = last;
//     else 
//       rear.setNext(last);
//     rear = last;
//   }
// 
//   int first () { return front.getElem(); }
// 
//   void rmFirst () {
//     front = front.getNext();
//   }
// 
//   int size () {
//       Node n = front;
//       int res = 0;
//       while (n != (Node)null) {
//         n = n.getNext();
//         res++;
//       }
//      return res;
//   }
// }
// 
// int f (int x) {
//   return x*x + 3;
// }
// 
// int main () {
//   IntQueue q = new IntQueue;
//   q.insert(f(3));
//   q.insert(5);
//   q.insert(7);
//   printInt(q.first());
//   q.rmFirst();
//   printInt(q.size());
//   return 0;
// }
// 
//      

namespace TestPrograms.Extensions
{
    public class TestProgramProviderQueue : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "f", new BlockNode(new DummyFilePlace(),
                    new ReturnNode(new DummyFilePlace(), new BinaryNode(BinaryOperator.Add,
                        new BinaryNode(BinaryOperator.Mul,
                            new VariableNode("x", new DummyFilePlace()),
                            new VariableNode("x", new DummyFilePlace()),
                            new DummyFilePlace()),
                        new IntNode(3, new DummyFilePlace()),
                        new DummyFilePlace()))), new FunctionArgument(LatteType.Int, "x")),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("IntQueue"),
                        new SingleDeclaration("q", new NewObjectNode(new DummyFilePlace(), new LatteType("IntQueue")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()), "insert",
                            new List<IExpressionNode>
                            {
                                new FunctionCallNode(new DummyFilePlace(), "f", new IntNode(3, new DummyFilePlace()))
                            })),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()), "insert",
                            new List<IExpressionNode> {new IntNode(5, new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()), "insert",
                            new List<IExpressionNode> {new IntNode(7, new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()),
                                "first", new List<IExpressionNode>()))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()), "rmFirst",
                            new List<IExpressionNode>())),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()),
                                "size", new List<IExpressionNode>()))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>
            {
                new ClassDefinitionNode(new DummyFilePlace(), "Node", null,
                    new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "setElem",
                            new BlockNode(new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "elem",
                                    new VariableNode("e", new DummyFilePlace()))),
                            new FunctionArgument(LatteType.Int, "e")),
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
                    new DummyFilePlace(), "IntQueue", null, new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Bool, "isEmpty", new BlockNode(
                            new DummyFilePlace(), new ReturnNode(new DummyFilePlace(), new CompareNode(
                                RelOperator.Equals,
                                new VariableNode("front", new DummyFilePlace()),
                                new CastExpressionNode(new DummyFilePlace(), new LatteType("Node"),
                                    new NullNode(new DummyFilePlace()), false),
                                new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(),
                            LatteType.Void, "insert", new BlockNode(new DummyFilePlace(),
                                new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                                    new SingleDeclaration("last",
                                        new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("last", new DummyFilePlace()), "setElem",
                                        new List<IExpressionNode> {new VariableNode("x", new DummyFilePlace())})),
                                new IfElseNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("this", new DummyFilePlace()), "isEmpty",
                                        new List<IExpressionNode>()),
                                    new BlockNode(new DummyFilePlace(),
                                        new BlockNode(new DummyFilePlace(),
                                            new AssignmentNode(new DummyFilePlace(), "front",
                                                new VariableNode("last", new DummyFilePlace())))),
                                    new BlockNode(new DummyFilePlace(),
                                        new BlockNode(new DummyFilePlace(),
                                            new ExpressionStatementNode(new DummyFilePlace(),
                                                new MethodCallNode(new DummyFilePlace(),
                                                    new VariableNode("rear", new DummyFilePlace()), "setNext",
                                                    new List<IExpressionNode>
                                                        {new VariableNode("last", new DummyFilePlace())}))))),
                                new AssignmentNode(new DummyFilePlace(), "rear",
                                    new VariableNode("last", new DummyFilePlace()))),
                            new FunctionArgument(LatteType.Int, "x")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "first",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("front", new DummyFilePlace()), "getElem",
                                        new List<IExpressionNode>())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "rmFirst",
                            new BlockNode(new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "front",
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("front", new DummyFilePlace()), "getNext",
                                        new List<IExpressionNode>())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "size", new BlockNode(
                            new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                                new SingleDeclaration("n", new VariableNode("front", new DummyFilePlace()))),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("res", new IntNode(0, new DummyFilePlace()))),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.NotEquals,
                                new VariableNode("n", new DummyFilePlace()),
                                new CastExpressionNode(new DummyFilePlace(), new LatteType("Node"),
                                    new NullNode(new DummyFilePlace()), false),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                    new AssignmentNode(new DummyFilePlace(), "n",
                                        new MethodCallNode(new DummyFilePlace(),
                                            new VariableNode("n", new DummyFilePlace()), "getNext",
                                            new List<IExpressionNode>())),
                                    new IncrementNode(new DummyFilePlace(), "res"))))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()))))
                    }, new ClassFieldNode(new DummyFilePlace(), "front", new LatteType("Node")),
                    new ClassFieldNode(new DummyFilePlace(), "rear", new LatteType("Node")))
            });
        }

        public string GetOutput()
        {
            return @"12
2
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}