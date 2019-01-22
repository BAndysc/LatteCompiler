using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// class list {
//   int elem;
//   list next;
// }
// 
// int main() {
//   printInt(length(fromTo(1,50)));
//   printInt(length2(fromTo(1,100)));
//   return 0;
// }
// 
// int head (list xs) {
//   return xs . elem;
// }
//  
// list cons (int x, list xs) {
//   list n;
//   n = new list;
//   n.elem = x;
//   n.next = xs;
//   return n;
// }
// 
// int length (list xs) {
//   if (xs==(list)null)
//     return 0;
//   else
//     return 1 + length (xs.next);
// }
// 
// list fromTo (int m, int n) {
//   if (m>n)
//     return (list)null;
//   else 
//     return cons (m,fromTo (m+1,n));
// }
// 
// int length2 (list xs) {
//   int res = 0;
//   while (xs != (list)null) {
//     res++;
//     xs = xs.next;
//   }
//   return res;
// }
// 

namespace TestPrograms.Extensions
{
    public class TestProgramProviderList : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                        new DummyFilePlace(),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new FunctionCallNode(new DummyFilePlace(), "length",
                                    new FunctionCallNode(new DummyFilePlace(), "fromTo",
                                        new IntNode(1, new DummyFilePlace()), new IntNode(50, new DummyFilePlace()))))),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new FunctionCallNode(new DummyFilePlace(), "length2",
                                    new FunctionCallNode(new DummyFilePlace(), "fromTo",
                                        new IntNode(1, new DummyFilePlace()),
                                        new IntNode(100, new DummyFilePlace()))))),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "head",
                        new BlockNode(new DummyFilePlace(),
                            new ReturnNode(new DummyFilePlace(),
                                new ObjectFieldNode(new DummyFilePlace(), new VariableNode("xs", new DummyFilePlace()),
                                    "elem"))), new FunctionArgument(new LatteType("list"), "xs")),
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("list"), "cons", new BlockNode(
                            new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("list"),
                                new SingleDeclaration("n", null)),
                            new AssignmentNode(new DummyFilePlace(), "n",
                                new NewObjectNode(new DummyFilePlace(), new LatteType("list"))),
                            new StructAssignmentNode(new DummyFilePlace(), new VariableNode("n", new DummyFilePlace()),
                                "elem",
                                new VariableNode("x", new DummyFilePlace())),
                            new StructAssignmentNode(new DummyFilePlace(), new VariableNode("n", new DummyFilePlace()),
                                "next",
                                new VariableNode("xs", new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("n", new DummyFilePlace()))),
                        new FunctionArgument(LatteType.Int, "x"), new FunctionArgument(new LatteType("list"), "xs")),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "length", new BlockNode(
                        new DummyFilePlace(), new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                new VariableNode("xs", new DummyFilePlace()),
                                new CastExpressionNode(new DummyFilePlace(), new LatteType("list"),
                                    new NullNode(new DummyFilePlace()), false),
                                new DummyFilePlace()),
                            new BlockNode(new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(),
                                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                            new BlockNode(
                                new DummyFilePlace(), new BlockNode(new DummyFilePlace(), new ReturnNode(
                                    new DummyFilePlace(),
                                    new BinaryNode(BinaryOperator.Add,
                                        new IntNode(1, new DummyFilePlace()),
                                        new FunctionCallNode(new DummyFilePlace(), "length",
                                            new ObjectFieldNode(new DummyFilePlace(),
                                                new VariableNode("xs", new DummyFilePlace()), "next")),
                                        new DummyFilePlace())))))), new FunctionArgument(new LatteType("list"), "xs")),
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("list"), "fromTo", new BlockNode(
                            new DummyFilePlace(), new IfElseNode(new DummyFilePlace(), new CompareNode(
                                    RelOperator.GreaterThan,
                                    new VariableNode("m", new DummyFilePlace()),
                                    new VariableNode("n", new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new ReturnNode(new DummyFilePlace(),
                                            new CastExpressionNode(new DummyFilePlace(), new LatteType("list"),
                                                new NullNode(new DummyFilePlace()), false)))), new BlockNode(
                                    new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(), new ReturnNode(new DummyFilePlace(),
                                        new FunctionCallNode(
                                            new DummyFilePlace(), "cons", new VariableNode("m", new DummyFilePlace()),
                                            new FunctionCallNode(new DummyFilePlace(), "fromTo", new BinaryNode(
                                                BinaryOperator.Add,
                                                new VariableNode("m", new DummyFilePlace()),
                                                new IntNode(1, new DummyFilePlace()),
                                                new DummyFilePlace()),
                                            new VariableNode("n", new DummyFilePlace())))))))),
                        new FunctionArgument(LatteType.Int, "m"), new FunctionArgument(LatteType.Int, "n")),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "length2", new BlockNode(
                            new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("res", new IntNode(0, new DummyFilePlace()))),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.NotEquals,
                                new VariableNode("xs", new DummyFilePlace()),
                                new CastExpressionNode(new DummyFilePlace(), new LatteType("list"),
                                    new NullNode(new DummyFilePlace()), false),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(), new IncrementNode(new DummyFilePlace(), "res"),
                                    new AssignmentNode(new DummyFilePlace(), "xs",
                                        new ObjectFieldNode(new DummyFilePlace(),
                                            new VariableNode("xs", new DummyFilePlace()),
                                            "next")))))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("res", new DummyFilePlace()))),
                        new FunctionArgument(new LatteType("list"), "xs"))
                },
                new List<IClassDefinitionNode>
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "list", null, new List<IFunctionDefinitionNode>(),
                        new ClassFieldNode(new DummyFilePlace(), "elem", LatteType.Int),
                        new ClassFieldNode(new DummyFilePlace(), "next", new LatteType("list")))
                });
        }

        public string GetOutput()
        {
            return @"50
100
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}