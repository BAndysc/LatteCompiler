using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// if it was exit, it would be ok
// int main()
// {
//     readInt();
// }

namespace TestPrograms.Bad
{
    public class TestProgramProviderFunctionCallAsReturn
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", 
                new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "readInt"))));
        }
    }
}