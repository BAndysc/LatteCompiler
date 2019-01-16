using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: ...
// Source: ...

// // Testing the return checker
// 
// int f () {
//    if (true)
//      return 0;
//    else
//      {}
// }
// 
// int g () {
//   if (false) 
//       {}
//   else
//       return 0;
// }
// 
// void p () {}
//   
// 
// int main() {
//   p();
//   return 0;
// }
// 

namespace TestPrograms.Good
{
    public class TestProgramProviderCore003 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(
                new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "f",
                    new BlockNode(new DummyFilePlace(),
                        new IfElseNode(new DummyFilePlace(), new TrueNode(new DummyFilePlace()),
                            new BlockNode(new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(),
                                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                            new BlockNode(new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(), new EmptyNode(new DummyFilePlace()))))))),
                new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "g",
                    new BlockNode(new DummyFilePlace(),
                        new IfElseNode(new DummyFilePlace(), new FalseNode(new DummyFilePlace()),
                            new BlockNode(new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(), new EmptyNode(new DummyFilePlace())))),
                            new BlockNode(new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(),
                                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))))),
                new FunctionDefinition(new DummyFilePlace(), LatteType.Void, "p",
                    new BlockNode(new DummyFilePlace(), new EmptyNode(new DummyFilePlace()))),
                new FunctionDefinition(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(new DummyFilePlace(),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "p")),
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