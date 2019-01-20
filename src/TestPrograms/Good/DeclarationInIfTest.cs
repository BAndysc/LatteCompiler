using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

/*
 * int main()
 * {
 *    int a = 1;
 *    if (true)
 *       int a = 2;
 *    if (a == 1)
 *       int a = 3;
 *    printInt(a);
 *    return 0;
 * }
 */

namespace TestPrograms.Good
{
    public class TestProgramProviderDeclarationInIfTest : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main",
                new BlockNode(new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int, new SingleDeclaration("a", new IntNode(1, new DummyFilePlace()))),
                        new IfNode(new DummyFilePlace(), 
                            new TrueNode(new DummyFilePlace()), 
                            new BlockNode(new DummyFilePlace(),
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int, new SingleDeclaration("a", new IntNode(2, new DummyFilePlace()))))
                                ),
                        new IfNode(new DummyFilePlace(), 
                            new CompareNode(RelOperator.Equals, new VariableNode("a", new DummyFilePlace()), new IntNode(1, new DummyFilePlace()), new DummyFilePlace() ),
                            new BlockNode(new DummyFilePlace(),
                                new DeclarationNode(new DummyFilePlace(), LatteType.Int, new SingleDeclaration("a", new IntNode(3, new DummyFilePlace()))))
                             ),
                        new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "printInt", new VariableNode("a", new DummyFilePlace()))),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))
                )));
        }

        public string GetOutput()
        {
            return "1\n";
        }

        public string GetInput()
        {
            return null;
        }
    }
}