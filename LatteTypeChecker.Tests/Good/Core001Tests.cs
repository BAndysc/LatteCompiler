using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteTreeOptimizer;
using NUnit.Framework;

// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main() {
// 	printInt(fac(10));
// 	printInt(rfac(10));
// 	printInt(mfac(10));
//         printInt(ifac(10));
//         string r ; // just to test blocks 
// 	{
// 	  int n = 10;
// 	  int r = 1;
// 	  while (n>0) {
// 	    r = r * n;
// 	    n--;
// 	  }
// 	  printInt(r);
// 	}
// 	printString (repStr("=",60));
// 	printString ("hello */");
//         printString ("/* world") ;
//         return 0 ;
// }
// 
// int fac(int a) {
// 	int r;
// 	int n;
// 
// 	r = 1;
// 	n = a;
// 	while (n > 0) {
// 	  r = r * n;
// 	  n = n - 1;
// 	}
// 	return r;
// }
// 
// int rfac(int n) {
// 	if (n == 0)
// 	  return 1;
// 	else
// 	  return n * rfac(n-1);
// }
// 
// int mfac(int n) {
// 	if (n == 0)
// 	  return 1;
// 	else
// 	  return n * nfac(n-1);
// }
// 
// int nfac(int n) {
// 	if (n != 0)
// 	  return mfac(n-1) * n;
// 	else
// 	  return 1;
// }
// 
// int ifac(int n) { return ifac2f(1,n); }
// 
// int ifac2f(int l, int h) {
//         if (l == h)
//           return l;
//         if (l > h)
//           return 1;
//         int m;
//         m = (l + h) / 2;
//         return ifac2f(l,m) * ifac2f(m+1,h);
// }
// 
// string repStr(string s, int n) {
//   string r = "";
//   int i = 0;
//   while(i<n) {
//     r = r + s;
//     i++;
//   }
//  return r;
// }

namespace LatteTypeChecker.Tests.Good
{
    public class Core001Tests
    {
        [Test]
        public void Core001Test()
        {
            var program =
                new ProgramNode(new List<ITopFunctionNode>()
                {
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new List<IFunctionArgument>() { },
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("fac",
                                            new List<IExpressionNode>() {new IntNode(10, new DummyFilePlace())},
                                            new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("rfac",
                                            new List<IExpressionNode>() {new IntNode(10, new DummyFilePlace())},
                                            new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("mfac",
                                            new List<IExpressionNode>() {new IntNode(10, new DummyFilePlace())},
                                            new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printInt",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("ifac",
                                            new List<IExpressionNode>() {new IntNode(10, new DummyFilePlace())},
                                            new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new DeclarationNode(new DummyFilePlace(), LatteType.String,
                                new List<ISingleDeclaration>() {new SingleDeclaration("r", null)}),
                            new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new List<ISingleDeclaration>()
                                        {new SingleDeclaration("n", new IntNode(10, new DummyFilePlace()))}),
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new List<ISingleDeclaration>()
                                        {new SingleDeclaration("r", new IntNode(1, new DummyFilePlace()))}),
                                new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                    new VariableNode("n", new DummyFilePlace()),
                                    new IntNode(0, new DummyFilePlace()),
                                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                                {
                                    new AssignmentNode(new DummyFilePlace(), "r", new BinaryNode(BinaryOperator.Mul,
                                        new VariableNode("r", new DummyFilePlace()),
                                        new VariableNode("n", new DummyFilePlace()),
                                        new DummyFilePlace())),
                                    new IncrementNode(new DummyFilePlace(), "n")
                                })),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode("printInt",
                                        new List<IExpressionNode>() {new VariableNode("r", new DummyFilePlace())},
                                        new DummyFilePlace()))
                            }),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printString",
                                    new List<IExpressionNode>()
                                    {
                                        new FunctionCallNode("repStr",
                                            new List<IExpressionNode>()
                                            {
                                                new StringNode("=", new DummyFilePlace()),
                                                new IntNode(60, new DummyFilePlace())
                                            }, new DummyFilePlace())
                                    }, new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printString",
                                    new List<IExpressionNode>() {new StringNode("hello */", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode("printString",
                                    new List<IExpressionNode>() {new StringNode("/* world", new DummyFilePlace())},
                                    new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "fac",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "a")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new List<ISingleDeclaration>() {new SingleDeclaration("r", null)}),
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                    new List<ISingleDeclaration>() {new SingleDeclaration("n", null)}),
                                new AssignmentNode(new DummyFilePlace(), "r", new IntNode(1, new DummyFilePlace())),
                                new AssignmentNode(new DummyFilePlace(), "n",
                                    new VariableNode("a", new DummyFilePlace())),
                                new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                    new VariableNode("n", new DummyFilePlace()),
                                    new IntNode(0, new DummyFilePlace()),
                                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                                {
                                    new AssignmentNode(new DummyFilePlace(), "r", new BinaryNode(BinaryOperator.Mul,
                                        new VariableNode("r", new DummyFilePlace()),
                                        new VariableNode("n", new DummyFilePlace()),
                                        new DummyFilePlace())),
                                    new AssignmentNode(new DummyFilePlace(), "n", new BinaryNode(BinaryOperator.Sub,
                                        new VariableNode("n", new DummyFilePlace()),
                                        new IntNode(1, new DummyFilePlace()),
                                        new DummyFilePlace()))
                                })),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("r", new DummyFilePlace()))
                            })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "rfac",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "n")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                        new VariableNode("n", new DummyFilePlace()),
                                        new IntNode(0, new DummyFilePlace()),
                                        new DummyFilePlace()),
                                    new ReturnNode(new DummyFilePlace(), new IntNode(1, new DummyFilePlace())),
                                    new ReturnNode(new DummyFilePlace(), new BinaryNode(BinaryOperator.Mul,
                                        new VariableNode("n", new DummyFilePlace()),
                                        new FunctionCallNode("rfac", new List<IExpressionNode>()
                                        {
                                            new BinaryNode(BinaryOperator.Sub,
                                                new VariableNode("n", new DummyFilePlace()),
                                                new IntNode(1, new DummyFilePlace()),
                                                new DummyFilePlace())
                                        }, new DummyFilePlace()),
                                        new DummyFilePlace())))
                            })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "mfac",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "n")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                        new VariableNode("n", new DummyFilePlace()),
                                        new IntNode(0, new DummyFilePlace()),
                                        new DummyFilePlace()),
                                    new ReturnNode(new DummyFilePlace(), new IntNode(1, new DummyFilePlace())),
                                    new ReturnNode(new DummyFilePlace(), new BinaryNode(BinaryOperator.Mul,
                                        new VariableNode("n", new DummyFilePlace()),
                                        new FunctionCallNode("nfac", new List<IExpressionNode>()
                                        {
                                            new BinaryNode(BinaryOperator.Sub,
                                                new VariableNode("n", new DummyFilePlace()),
                                                new IntNode(1, new DummyFilePlace()),
                                                new DummyFilePlace())
                                        }, new DummyFilePlace()),
                                        new DummyFilePlace())))
                            })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "nfac",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "n")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.NotEquals,
                                        new VariableNode("n", new DummyFilePlace()),
                                        new IntNode(0, new DummyFilePlace()),
                                        new DummyFilePlace()), new ReturnNode(new DummyFilePlace(), new BinaryNode(
                                        BinaryOperator.Mul,
                                        new FunctionCallNode("mfac", new List<IExpressionNode>()
                                        {
                                            new BinaryNode(BinaryOperator.Sub,
                                                new VariableNode("n", new DummyFilePlace()),
                                                new IntNode(1, new DummyFilePlace()),
                                                new DummyFilePlace())
                                        }, new DummyFilePlace()),
                                        new VariableNode("n", new DummyFilePlace()),
                                        new DummyFilePlace())),
                                    new ReturnNode(new DummyFilePlace(), new IntNode(1, new DummyFilePlace())))
                            })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "ifac",
                        new List<IFunctionArgument>() {new FunctionArgument(LatteType.Int, "n")}, new BlockNode(
                            new DummyFilePlace(), new List<IStatement>()
                            {
                                new ReturnNode(new DummyFilePlace(),
                                    new FunctionCallNode("ifac2f",
                                        new List<IExpressionNode>()
                                        {
                                            new IntNode(1, new DummyFilePlace()),
                                            new VariableNode("n", new DummyFilePlace())
                                        }, new DummyFilePlace()))
                            })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "ifac2f",
                        new List<IFunctionArgument>()
                            {new FunctionArgument(LatteType.Int, "l"), new FunctionArgument(LatteType.Int, "h")},
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                    new VariableNode("l", new DummyFilePlace()),
                                    new VariableNode("h", new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("l", new DummyFilePlace()))),
                            new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                    new VariableNode("l", new DummyFilePlace()),
                                    new VariableNode("h", new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new ReturnNode(new DummyFilePlace(), new IntNode(1, new DummyFilePlace()))),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>() {new SingleDeclaration("m", null)}),
                            new AssignmentNode(new DummyFilePlace(), "m", new BinaryNode(BinaryOperator.Div,
                                new BinaryNode(BinaryOperator.Add,
                                    new VariableNode("l", new DummyFilePlace()),
                                    new VariableNode("h", new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new IntNode(2, new DummyFilePlace()),
                                new DummyFilePlace())),
                            new ReturnNode(new DummyFilePlace(), new BinaryNode(BinaryOperator.Mul,
                                new FunctionCallNode("ifac2f",
                                    new List<IExpressionNode>()
                                    {
                                        new VariableNode("l", new DummyFilePlace()),
                                        new VariableNode("m", new DummyFilePlace())
                                    }, new DummyFilePlace()),
                                new FunctionCallNode("ifac2f", new List<IExpressionNode>()
                                {
                                    new BinaryNode(BinaryOperator.Add,
                                        new VariableNode("m", new DummyFilePlace()),
                                        new IntNode(1, new DummyFilePlace()),
                                        new DummyFilePlace()),
                                    new VariableNode("h", new DummyFilePlace())
                                }, new DummyFilePlace()),
                                new DummyFilePlace()))
                        })),
                    new TopFunctionNode(new DummyFilePlace(), LatteType.String, "repStr",
                        new List<IFunctionArgument>()
                            {new FunctionArgument(LatteType.String, "s"), new FunctionArgument(LatteType.Int, "n")},
                        new BlockNode(new DummyFilePlace(), new List<IStatement>()
                        {
                            new DeclarationNode(new DummyFilePlace(), LatteType.String,
                                new List<ISingleDeclaration>()
                                    {new SingleDeclaration("r", new StringNode("", new DummyFilePlace()))}),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new List<ISingleDeclaration>()
                                    {new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))}),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                new VariableNode("i", new DummyFilePlace()),
                                new VariableNode("n", new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new List<IStatement>()
                            {
                                new AssignmentNode(new DummyFilePlace(), "r", new BinaryNode(BinaryOperator.Add,
                                    new VariableNode("r", new DummyFilePlace()),
                                    new VariableNode("s", new DummyFilePlace()),
                                    new DummyFilePlace())),
                                new IncrementNode(new DummyFilePlace(), "i")
                            })),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("r", new DummyFilePlace()))
                        }))
                });

            var treeOptimizer = new TreeOptimizer();
            Assert.AreEqual(true, new TypeChecker().Visit(treeOptimizer.Visit(program)));
        }
    }
}