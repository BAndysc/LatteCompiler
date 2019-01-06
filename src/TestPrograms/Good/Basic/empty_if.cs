using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// 
// int main() {
//     if(false);
//     printInt(1);
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderEmptyIf : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(),
                new IfNode(new DummyFilePlace(), new FalseNode(new DummyFilePlace()),
                    new EmptyNode(new DummyFilePlace())),
                new ExpressionStatementNode(new DummyFilePlace(),
                    new FunctionCallNode(new DummyFilePlace(), "printInt", new IntNode(1, new DummyFilePlace()))),
                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"1
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}