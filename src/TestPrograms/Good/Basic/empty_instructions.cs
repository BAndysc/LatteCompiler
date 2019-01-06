using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     ;;;;;
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderEmptyInstructions : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(), new EmptyNode(new DummyFilePlace()),
                new EmptyNode(new DummyFilePlace()),
                new EmptyNode(new DummyFilePlace()),
                new EmptyNode(new DummyFilePlace()),
                new EmptyNode(new DummyFilePlace()),
                new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))));
        }

        public string GetOutput()
        {
            return @"";
        }

        public string GetInput()
        {
            return null;
        }
    }
}