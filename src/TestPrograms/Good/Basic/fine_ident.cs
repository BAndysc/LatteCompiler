using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// // Author: Tomasz Wysocki 277696
// Source: https://github.com/tomwys/mrjp-tests
// int main() {
//     int abcABC000___ = 0;
//     return abcABC000___;
// }
// 

namespace TestPrograms.Good.Basic
{
    public class TestProgramProviderFineIdent : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(),
                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                    new SingleDeclaration("abcABC000___", new IntNode(0, new DummyFilePlace()))),
                new ReturnNode(new DummyFilePlace(), new VariableNode("abcABC000___", new DummyFilePlace())))));
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