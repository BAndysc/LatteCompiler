using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: Bartosz Korczyński

// int main() {
// 	int[] a = null;
// 	a = new int[4];
// 
// 	a[0] = 1;
// 	a[1] = 2;
// 	a[2] = 3;
// 	a[3] = 4;
// 
// 	for (int x : a)
// 	{
// 		x = 5;
// 	}
// 
// 	for (int x : a)
// 	{
// 		printInt(x);
// 	}
// 
// 	return 3;
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderForeach : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType(LatteType.Int),
                        new SingleDeclaration("a", new NullNode(new DummyFilePlace()))),
                    new AssignmentNode(new DummyFilePlace(), "a",
                        new NewArrayNode(new DummyFilePlace(), LatteType.Int, new IntNode(4, new DummyFilePlace()))),
                    new ArrayAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                        new IntNode(0, new DummyFilePlace()), new IntNode(1, new DummyFilePlace())),
                    new ArrayAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                        new IntNode(1, new DummyFilePlace()), new IntNode(2, new DummyFilePlace())),
                    new ArrayAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                        new IntNode(2, new DummyFilePlace()), new IntNode(3, new DummyFilePlace())),
                    new ArrayAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                        new IntNode(3, new DummyFilePlace()), new IntNode(4, new DummyFilePlace())),
                    new ForEachNode(new DummyFilePlace(), LatteType.Int, "x",
                        new VariableNode("a", new DummyFilePlace()),
                        new BlockNode(new DummyFilePlace(),
                            new BlockNode(new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "x", new IntNode(5, new DummyFilePlace()))))),
                    new ForEachNode(new DummyFilePlace(), LatteType.Int, "x",
                        new VariableNode("a", new DummyFilePlace()),
                        new BlockNode(new DummyFilePlace(),
                            new BlockNode(new DummyFilePlace(),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new FunctionCallNode(new DummyFilePlace(), "printInt",
                                        new VariableNode("x", new DummyFilePlace())))))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(3, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>());
        }

        public string GetOutput()
        {
            return @"1
2
3
4
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}