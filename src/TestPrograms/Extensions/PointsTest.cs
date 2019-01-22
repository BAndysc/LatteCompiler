using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: p. Marcin Benke
// Source: https://www.mimuw.edu.pl/~ben/Zajecia/Mrj2018/Latte/lattests121017.tgz

// class Point2 {
//   int x;
//   int y;
// 
//   void move (int dx, int dy) {
//      x = x + dx;
//      y = y + dy;
//   }
// 
//   int getX () { return x; }
// 
//   int getY () { return y; }
// }
// 
// class Point3 extends Point2 {
//   int z;
// 
//   void moveZ (int dz) {
//     z = z + dz;
//   }
// 
//   int getZ () { return z; }
// 
// }
// 
// class Point4 extends Point3 {
//   int w;
// 
//   void moveW (int dw) {
//     w = w + dw;
//   }
// 
//   int getW () { return w; }
// 
// }
// 
// 
// 
// int main () {
//   Point2 p = new Point3;
// 
//   Point3 q = new Point3;
// 
//   Point4 r = new Point4;
// 
//   q.move(2,4);
//   q.moveZ(7);
//   p = q;
// 
//   p.move(3,5);
//  
//   r.move(1,3);
//   r.moveZ(6);
//   r.moveW(2);
// 
//   printInt(p.getX());  
//   printInt(p.getY());  
//   printInt(q.getZ());  
//   printInt(r.getW());
//   return 0;
// 
// }

namespace TestPrograms.Extensions
{
    public class TestProgramProviderPoints : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Point2"),
                        new SingleDeclaration("p", new NewObjectNode(new DummyFilePlace(), new LatteType("Point3")))),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Point3"),
                        new SingleDeclaration("q", new NewObjectNode(new DummyFilePlace(), new LatteType("Point3")))),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Point4"),
                        new SingleDeclaration("r", new NewObjectNode(new DummyFilePlace(), new LatteType("Point4")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()), "move",
                            new List<IExpressionNode>
                                {new IntNode(2, new DummyFilePlace()), new IntNode(4, new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()), "moveZ",
                            new List<IExpressionNode> {new IntNode(7, new DummyFilePlace())})),
                    new AssignmentNode(new DummyFilePlace(), "p", new VariableNode("q", new DummyFilePlace())),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("p", new DummyFilePlace()), "move",
                            new List<IExpressionNode>
                                {new IntNode(3, new DummyFilePlace()), new IntNode(5, new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("r", new DummyFilePlace()), "move",
                            new List<IExpressionNode>
                                {new IntNode(1, new DummyFilePlace()), new IntNode(3, new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("r", new DummyFilePlace()), "moveZ",
                            new List<IExpressionNode> {new IntNode(6, new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("r", new DummyFilePlace()), "moveW",
                            new List<IExpressionNode> {new IntNode(2, new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("p", new DummyFilePlace()),
                                "getX", new List<IExpressionNode>()))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("p", new DummyFilePlace()),
                                "getY", new List<IExpressionNode>()))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()),
                                "getZ", new List<IExpressionNode>()))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                            new MethodCallNode(new DummyFilePlace(), new VariableNode("r", new DummyFilePlace()),
                                "getW", new List<IExpressionNode>()))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace()))))
            }, new List<IClassDefinitionNode>
            {
                new ClassDefinitionNode(new DummyFilePlace(), "Point2", null, new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "move", new BlockNode(
                                new DummyFilePlace(), new AssignmentNode(new DummyFilePlace(), "x", new BinaryNode(
                                    BinaryOperator.Add,
                                    new VariableNode("x", new DummyFilePlace()),
                                    new VariableNode("dx", new DummyFilePlace()),
                                    new DummyFilePlace())),
                                new AssignmentNode(new DummyFilePlace(), "y", new BinaryNode(BinaryOperator.Add,
                                    new VariableNode("y", new DummyFilePlace()),
                                    new VariableNode("dy", new DummyFilePlace()),
                                    new DummyFilePlace()))), new FunctionArgument(LatteType.Int, "dx"),
                            new FunctionArgument(LatteType.Int, "dy")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "getX",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("x", new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "getY",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("y", new DummyFilePlace()))))
                    }, new ClassFieldNode(new DummyFilePlace(), "x", LatteType.Int),
                    new ClassFieldNode(new DummyFilePlace(), "y", LatteType.Int)),
                new ClassDefinitionNode(new DummyFilePlace(), "Point3", "Point2", new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "moveZ", new BlockNode(
                        new DummyFilePlace(), new AssignmentNode(new DummyFilePlace(), "z", new BinaryNode(
                            BinaryOperator.Add,
                            new VariableNode("z", new DummyFilePlace()),
                            new VariableNode("dz", new DummyFilePlace()),
                            new DummyFilePlace()))), new FunctionArgument(LatteType.Int, "dz")),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "getZ",
                        new BlockNode(new DummyFilePlace(),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("z", new DummyFilePlace()))))
                }, new ClassFieldNode(new DummyFilePlace(), "z", LatteType.Int)),
                new ClassDefinitionNode(new DummyFilePlace(), "Point4", "Point3", new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "moveW", new BlockNode(
                        new DummyFilePlace(), new AssignmentNode(new DummyFilePlace(), "w", new BinaryNode(
                            BinaryOperator.Add,
                            new VariableNode("w", new DummyFilePlace()),
                            new VariableNode("dw", new DummyFilePlace()),
                            new DummyFilePlace()))), new FunctionArgument(LatteType.Int, "dw")),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "getW",
                        new BlockNode(new DummyFilePlace(),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("w", new DummyFilePlace()))))
                }, new ClassFieldNode(new DummyFilePlace(), "w", LatteType.Int))
            });
        }

        public string GetOutput()
        {
            return @"5
9
7
2
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}