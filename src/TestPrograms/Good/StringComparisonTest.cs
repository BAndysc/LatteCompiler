using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: Bartosz Korczyński

// void assert(boolean cond, string msg)
// {
// 	if (!cond)
// 		printString("error: " + msg);
// }
// 
// int main()
// {
// 	string empty = "";
// 	string empty2;
// 	string empty3;
// 	string[] emptyTab = new string[1];
// 	empty3 = emptyTab[0];
// 
// 	string ala = "a" + "la";
// 	string ala2 = "a" + "l" + "a";
// 	assert("ala" == "ala", "1");
// 	assert("ala" == ala, "2");
// 	assert("ala" == ala2, "3");
// 	assert(ala == ala2, "4");
// 
// 	assert(empty == empty2, "5");
// 	assert(empty == empty3, "6");
// 	assert(empty2 == empty3, "7");
// 
// 	assert(empty != ala, "8");
// 	assert(empty2 != ala, "9");
// 	assert(empty3 != ala, "10");
//  printString("OK");
// 	return 0;
// }

namespace TestPrograms.Good
{
    public class TestProgramProviderStringCompare : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "assert", new BlockNode(
                        new DummyFilePlace(), new IfNode(new DummyFilePlace(),
                            new LogicalNegateNode(new VariableNode("cond", new DummyFilePlace()), new DummyFilePlace()),
                            new BlockNode(new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(
                                    new DummyFilePlace(),
                                    "printString", new BinaryNode(BinaryOperator.Add,
                                        new StringNode("error: ", new DummyFilePlace()),
                                        new VariableNode("msg", new DummyFilePlace()),
                                        new DummyFilePlace()))))))), new FunctionArgument(LatteType.Bool, "cond"),
                    new FunctionArgument(LatteType.String, "msg")),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), LatteType.String,
                        new SingleDeclaration("empty", new StringNode("", new DummyFilePlace()))),
                    new DeclarationNode(new DummyFilePlace(), LatteType.String, new SingleDeclaration("empty2", null)),
                    new DeclarationNode(new DummyFilePlace(), LatteType.String, new SingleDeclaration("empty3", null)),
                    new DeclarationNode(new DummyFilePlace(), new LatteType(LatteType.String),
                        new SingleDeclaration("emptyTab",
                            new NewArrayNode(new DummyFilePlace(), LatteType.String,
                                new IntNode(1, new DummyFilePlace())))),
                    new AssignmentNode(new DummyFilePlace(), "empty3",
                        new ArrayAccessNode(new DummyFilePlace(), new VariableNode("emptyTab", new DummyFilePlace()),
                            new IntNode(0, new DummyFilePlace()))),
                    new DeclarationNode(new DummyFilePlace(), LatteType.String, new SingleDeclaration("ala",
                        new BinaryNode(BinaryOperator.Add,
                            new StringNode("a", new DummyFilePlace()),
                            new StringNode("la", new DummyFilePlace()),
                            new DummyFilePlace()))),
                    new DeclarationNode(new DummyFilePlace(), LatteType.String, new SingleDeclaration("ala2",
                        new BinaryNode(BinaryOperator.Add,
                            new BinaryNode(BinaryOperator.Add,
                                new StringNode("a", new DummyFilePlace()),
                                new StringNode("l", new DummyFilePlace()),
                                new DummyFilePlace()),
                            new StringNode("a", new DummyFilePlace()),
                            new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "assert", new CompareNode(RelOperator.Equals,
                            new StringNode("ala", new DummyFilePlace()),
                            new StringNode("ala", new DummyFilePlace()),
                            new DummyFilePlace()), new StringNode("1", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "assert", new CompareNode(RelOperator.Equals,
                            new StringNode("ala", new DummyFilePlace()),
                            new VariableNode("ala", new DummyFilePlace()),
                            new DummyFilePlace()), new StringNode("2", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "assert", new CompareNode(RelOperator.Equals,
                            new StringNode("ala", new DummyFilePlace()),
                            new VariableNode("ala2", new DummyFilePlace()),
                            new DummyFilePlace()), new StringNode("3", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "assert", new CompareNode(RelOperator.Equals,
                            new VariableNode("ala", new DummyFilePlace()),
                            new VariableNode("ala2", new DummyFilePlace()),
                            new DummyFilePlace()), new StringNode("4", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "assert", new CompareNode(RelOperator.Equals,
                            new VariableNode("empty", new DummyFilePlace()),
                            new VariableNode("empty2", new DummyFilePlace()),
                            new DummyFilePlace()), new StringNode("5", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "assert", new CompareNode(RelOperator.Equals,
                            new VariableNode("empty", new DummyFilePlace()),
                            new VariableNode("empty3", new DummyFilePlace()),
                            new DummyFilePlace()), new StringNode("6", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "assert", new CompareNode(RelOperator.Equals,
                            new VariableNode("empty2", new DummyFilePlace()),
                            new VariableNode("empty3", new DummyFilePlace()),
                            new DummyFilePlace()), new StringNode("7", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "assert", new CompareNode(RelOperator.NotEquals,
                            new VariableNode("empty", new DummyFilePlace()),
                            new VariableNode("ala", new DummyFilePlace()),
                            new DummyFilePlace()), new StringNode("8", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "assert", new CompareNode(RelOperator.NotEquals,
                            new VariableNode("empty2", new DummyFilePlace()),
                            new VariableNode("ala", new DummyFilePlace()),
                            new DummyFilePlace()), new StringNode("9", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                        "assert", new CompareNode(RelOperator.NotEquals,
                            new VariableNode("empty3", new DummyFilePlace()),
                            new VariableNode("ala", new DummyFilePlace()),
                            new DummyFilePlace()), new StringNode("10", new DummyFilePlace()))),
                    new ExpressionStatementNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(), "printString", new StringNode("OK", new DummyFilePlace()))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>());
        }

        public string GetOutput()
        {
            return @"OK
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}