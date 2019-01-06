using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     while(true) {
//         return 0;
//     }
//     return 0;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderWhileTrue : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new TopFunctionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(),
                new WhileNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()),
                    new BlockNode(new DummyFilePlace(),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
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