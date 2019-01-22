using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// int main () {
//   Counter c;
//   c = new Counter;
//   c.incr();
//   c.incr();
//   c.incr();
//   int x = c.value();
//   printInt(x);
//   return 0;
// }
// 
// class Counter {
//   int val;
// 
//   void incr () {val++; return;}
// 
//   int value () {return val;}
// 
// }
// 

namespace TestPrograms.Extensions
{
    public class TestProgramProviderCounter : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Counter"),
                        new SingleDeclaration("c", null)),
                    new AssignmentNode(new DummyFilePlace(), "c",
                        new NewObjectNode(new DummyFilePlace(), new LatteType("Counter"))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("c", new DummyFilePlace()), "incr",
                            new List<IExpressionNode>())),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("c", new DummyFilePlace()), "incr",
                            new List<IExpressionNode>())),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("c", new DummyFilePlace()), "incr",
                            new List<IExpressionNode>())),
                    new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                        new SingleDeclaration("x",
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("c", new DummyFilePlace()),
                                "value", new List<IExpressionNode>()))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new VariableNode("x", new DummyFilePlace()))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>
            {
                new ClassDefinitionNode(new DummyFilePlace(), "Counter", null, new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "incr", new BlockNode(
                        new DummyFilePlace(), new IncrementNode(new DummyFilePlace(), "val"),
                        new VoidReturnNode(new DummyFilePlace()))),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "value",
                        new BlockNode(new DummyFilePlace(),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("val", new DummyFilePlace()))))
                }, new ClassFieldNode(new DummyFilePlace(), "val", LatteType.Int))
            });
        }

        public string GetOutput()
        {
            return @"3
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}