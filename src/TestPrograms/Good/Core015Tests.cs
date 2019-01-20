using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: ...
// Source: ...

// /* parity of positive integers by recursion */
// 
// int main () {
//   printInt(ev(17)) ;
//   return 0 ;
// }
// 
// int ev (int y) {
//   if (y > 0)
//     return ev (y-2) ;
//   else
//     if (y < 0)
//       return 0 ;
//     else
//       return 1 ;
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderCore015 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new FunctionCallNode(new DummyFilePlace(), "ev", new IntNode(17, new DummyFilePlace())))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "ev", new BlockNode(new DummyFilePlace(),
                        new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                            new VariableNode("y", new DummyFilePlace()),
                            new IntNode(0, new DummyFilePlace()),
                            new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                            new DummyFilePlace(),
                            new ReturnNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "ev",
                                new BinaryNode(BinaryOperator.Sub,
                                    new VariableNode("y", new DummyFilePlace()),
                                    new IntNode(2, new DummyFilePlace()),
                                    new DummyFilePlace()))))), new BlockNode(new DummyFilePlace(), new BlockNode(
                            new DummyFilePlace(), new IfElseNode(new DummyFilePlace(), new CompareNode(
                                    RelOperator.LessThan,
                                    new VariableNode("y", new DummyFilePlace()),
                                    new IntNode(0, new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new ReturnNode(new DummyFilePlace(),
                                            new IntNode(1, new DummyFilePlace()))))))))),
                    new FunctionArgument(LatteType.Int, "y")));
        }

        public string GetOutput()
        {
            return @"0
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}