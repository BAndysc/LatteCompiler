using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: ...
// Source: ...

// /* parity of positive integers by loop */
// 
// int main () {
//   int y = 17;
//   while (y > 0)
//     y = y - 2;
//   if (y < 0) {
//     printInt(0);
//     return 0 ;
//     }
//   else {
//     printInt(1);
//     return 0 ;
//     }
// }
// 

namespace TestPrograms.Good
{
    public class TestProgramProviderCore016 : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                new DummyFilePlace(),
                new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                    new SingleDeclaration("y", new IntNode(17, new DummyFilePlace()))),
                new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                    new VariableNode("y", new DummyFilePlace()),
                    new IntNode(0, new DummyFilePlace()),
                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                    new AssignmentNode(new DummyFilePlace(), "y", new BinaryNode(BinaryOperator.Sub,
                        new VariableNode("y", new DummyFilePlace()),
                        new IntNode(2, new DummyFilePlace()),
                        new DummyFilePlace()))))),
                new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                    new VariableNode("y", new DummyFilePlace()),
                    new IntNode(0, new DummyFilePlace()),
                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                    new BlockNode(new DummyFilePlace(),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new IntNode(0, new DummyFilePlace()))),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))), new BlockNode(
                    new DummyFilePlace(), new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                new IntNode(1, new DummyFilePlace()))),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))))))));
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