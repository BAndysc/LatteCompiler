using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// class Struct
// {
// 	int x;
// 
// 	void Write()
// 	{
// 		printInt(x);
// 	}
// 
// 	void Inc()
// 	{
// 		x++;
// 	}
// }
// 
// class Struct2
// {
// 	int x;
// }
// 
// int main()
// {
// 	Struct x = new Struct;
// 	Struct2 y = new Struct2;
// 
// 	printInt(y.x);
// 	y.x++;
// 	printInt(y.x);
// 	y.x--;
// 	printInt(y.x);
// 
// 	x.Write();
// 	x.Inc();
// 	x.Write();
// 	return 0;
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderStructDecrementIncrement : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), new LatteType("Struct"),
                            new SingleDeclaration("x",
                                new NewObjectNode(new DummyFilePlace(), new LatteType("Struct")))),
                        new DeclarationNode(new DummyFilePlace(), new LatteType("Struct2"),
                            new SingleDeclaration("y",
                                new NewObjectNode(new DummyFilePlace(), new LatteType("Struct2")))),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new ObjectFieldNode(new DummyFilePlace(), new VariableNode("y", new DummyFilePlace()),
                                    "x"))),
                        new StructIncrementNode(new DummyFilePlace(), new VariableNode("y", new DummyFilePlace()), "x"),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new ObjectFieldNode(new DummyFilePlace(), new VariableNode("y", new DummyFilePlace()),
                                    "x"))),
                        new StructDecrementNode(new DummyFilePlace(), new VariableNode("y", new DummyFilePlace()), "x"),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new ObjectFieldNode(new DummyFilePlace(), new VariableNode("y", new DummyFilePlace()),
                                    "x"))),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("x", new DummyFilePlace()),
                                "Write",
                                new List<IExpressionNode>())),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("x", new DummyFilePlace()), "Inc",
                                new List<IExpressionNode>())),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("x", new DummyFilePlace()),
                                "Write",
                                new List<IExpressionNode>())),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
                },
                new List<IClassDefinitionNode>
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "Struct", null,
                        new List<IFunctionDefinitionNode>
                        {
                            new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "Write",
                                new BlockNode(new DummyFilePlace(),
                                    new ExpressionStatementNode(new DummyFilePlace(),
                                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                                            new VariableNode("x", new DummyFilePlace()))))),
                            new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "Inc",
                                new BlockNode(new DummyFilePlace(), new IncrementNode(new DummyFilePlace(), "x")))
                        }, new ClassFieldNode(new DummyFilePlace(), "x", LatteType.Int)),
                    new ClassDefinitionNode(new DummyFilePlace(), "Struct2", null, new List<IFunctionDefinitionNode>(),
                        new ClassFieldNode(new DummyFilePlace(), "x", LatteType.Int))
                });
        }

        public string GetOutput()
        {
            return @"0
1
0
0
1
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}