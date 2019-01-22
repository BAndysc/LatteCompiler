using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

// /******************************************************************
//  *                                                                *
//  * bfs test by Michał Gregorczyk (mg277528@students.mimuw.edu.pl) *
//  *                               (michalg89@gmail.com)            *
//  *                                                                *
//  ******************************************************************
//  * 22. stycznia 12:00                                             *
//  *                                                                *
//  * Mój kompilator jeszcze nie potrafi                             *
//  * skompilować tego testu, dlatego                                *
//  * nie sprawidziłem jego poprawności.                             *
//  * Test przechodzi natomiast przez                                *
//  * analizę semantyczną.                                           *
//  *                                                                *
//  * Będę wdzięczny za wszelkie uwagi                               *
//  * typu "nie działa, daje zły wynik"                              *
//  * lub "u mnie działa".                                           *
//  *****************************************************************/
// 
// class Node{
//     boolean visited;
//     int value;
//     List neighbours;
// 
//     void init(int val){
//         visited = false;
//         value = val;
//         neighbours = null;    
//     }
// 
//     boolean isVisited(){
//         return visited;
//     }
// 
//     void markAsVisited(){
//         visited = true;
//     }
// 
//     int getValue(){
//         return value;
//     }
// 
//     List getNeighbours(){
//         return neighbours;
//     }
// 
//     void addNeighbour(Node n){
//         if (neighbours == null){
//             neighbours = new List;
//             neighbours.makeSingleton(n);
//         }
//         else{
//             List newNeighbours = new List;
//             newNeighbours.cons(n, neighbours);
//             neighbours = newNeighbours;
//         }
//     }
// }
// 
// class List{
//     Node head;
//     List tail;
// 
//     void makeSingleton(Node node){
//         head = node;
//         tail = null;
//     }
// 
//     Node getHead(){
//         return head;
//     }
// 
//     List getTail(){
//         return tail;
//     }
// 
//     void cons(Node newHead, List newTail){
//         this.head = newHead;
//         this.tail = newTail;
//     }
// }
// 
// class Queue{
//     List first;
//     List last;
// 
//     Node get(){
//         if (first == null)
//             return null;
// 
//         Node retEl = first.head;
// 
//         first = first.tail;
//         if (first == null)
//             last = null;
// 
//         return retEl;
//     }
// 
//     void put(Node n){
//         List newTail = new List;
//         newTail.makeSingleton(n);
//         if (first == null){
//             first = newTail;
//             last = newTail;
//         }
//         else{
//             last.cons(last.getHead(), newTail);
//             last = newTail;
//         }
//     }
// 
//     boolean isEmpty(){
//         return (first == null);
//     }
// }
// 
// int main(){
//     Node graph = prepareData();
//     graph.markAsVisited();
//     Queue q = new Queue;
//     q.put(graph);
//     bfs(q);
//     return 0;
// }
// 
// Node prepareData(){
//     Node n1 = new Node;
//     n1.init(1);
//     Node n2 = new Node;
//     n2.init(2);
//     Node n3 = new Node;
//     n3.init(3);
//     Node n4 = new Node;
//     n4.init(4);
//     Node n5 = new Node;
//     n5.init(5);
//     Node n6 = new Node;
//     n6.init(6);
//     Node n7 = new Node;
//     n7.init(7);
//     Node n8 = new Node;
//     n8.init(8);
//     Node n9 = new Node;
//     n9.init(9);
// 
//     n1.addNeighbour(n3);
//     n1.addNeighbour(n2);
//     
//     n2.addNeighbour(n3);
// 
//     n3.addNeighbour(n6);
//     n3.addNeighbour(n5);
//     n3.addNeighbour(n4);
// 
//     n4.addNeighbour(n2);
// 
//     n5.addNeighbour(n7);
// 
//     n7.addNeighbour(n8);
// 
//     n8.addNeighbour(n9);
// 
//     n9.addNeighbour(n5);
// 
//     return n1;
// }
// 
// void bfs(Queue q){
//     while (! q.isEmpty()){
//         Node el = q.get();
//         printInt(el.getValue());
//         List neigh = el.getNeighbours();
//         while(neigh != null){
//             Node n = neigh.getHead();
//             if (!n.isVisited()){
//                 n.markAsVisited();
//                 q.put(n);
//             }
//             neigh = neigh.getTail();
//         }
//     }
// }

namespace TestPrograms.Community
{
    public class TestProgramProviderBfs : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
            {
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("graph", new FunctionCallNode(new DummyFilePlace(), "prepareData"))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("graph", new DummyFilePlace()),
                            "markAsVisited", new List<IExpressionNode>())),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Queue"),
                        new SingleDeclaration("q", new NewObjectNode(new DummyFilePlace(), new LatteType("Queue")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()), "put",
                            new List<IExpressionNode> {new VariableNode("graph", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new FunctionCallNode(new DummyFilePlace(), "bfs", new VariableNode("q", new DummyFilePlace()))),
                    new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Node"), "prepareData", new BlockNode(
                    new DummyFilePlace(),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("n1", new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n1", new DummyFilePlace()), "init",
                            new List<IExpressionNode> {new IntNode(1, new DummyFilePlace())})),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("n2", new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n2", new DummyFilePlace()), "init",
                            new List<IExpressionNode> {new IntNode(2, new DummyFilePlace())})),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("n3", new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n3", new DummyFilePlace()), "init",
                            new List<IExpressionNode> {new IntNode(3, new DummyFilePlace())})),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("n4", new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n4", new DummyFilePlace()), "init",
                            new List<IExpressionNode> {new IntNode(4, new DummyFilePlace())})),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("n5", new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n5", new DummyFilePlace()), "init",
                            new List<IExpressionNode> {new IntNode(5, new DummyFilePlace())})),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("n6", new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n6", new DummyFilePlace()), "init",
                            new List<IExpressionNode> {new IntNode(6, new DummyFilePlace())})),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("n7", new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n7", new DummyFilePlace()), "init",
                            new List<IExpressionNode> {new IntNode(7, new DummyFilePlace())})),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("n8", new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n8", new DummyFilePlace()), "init",
                            new List<IExpressionNode> {new IntNode(8, new DummyFilePlace())})),
                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                        new SingleDeclaration("n9", new NewObjectNode(new DummyFilePlace(), new LatteType("Node")))),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n9", new DummyFilePlace()), "init",
                            new List<IExpressionNode> {new IntNode(9, new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n1", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n3", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n1", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n2", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n2", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n3", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n3", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n6", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n3", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n5", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n3", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n4", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n4", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n2", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n5", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n7", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n7", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n8", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n8", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n9", new DummyFilePlace())})),
                    new ExpressionStatementNode(new DummyFilePlace(),
                        new MethodCallNode(new DummyFilePlace(), new VariableNode("n9", new DummyFilePlace()),
                            "addNeighbour", new List<IExpressionNode> {new VariableNode("n5", new DummyFilePlace())})),
                    new ReturnNode(new DummyFilePlace(), new VariableNode("n1", new DummyFilePlace())))),
                new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "bfs", new BlockNode(
                        new DummyFilePlace(), new WhileNode(new DummyFilePlace(),
                            new LogicalNegateNode(
                                new MethodCallNode(new DummyFilePlace(), new VariableNode("q", new DummyFilePlace()),
                                    "isEmpty", new List<IExpressionNode>()), new DummyFilePlace()), new BlockNode(
                                new DummyFilePlace(), new BlockNode(new DummyFilePlace(), new BlockNode(
                                    new DummyFilePlace(),
                                    new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                                        new SingleDeclaration("el",
                                            new MethodCallNode(new DummyFilePlace(),
                                                new VariableNode("q", new DummyFilePlace()), "get",
                                                new List<IExpressionNode>()))),
                                    new ExpressionStatementNode(new DummyFilePlace(),
                                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                                            new MethodCallNode(new DummyFilePlace(),
                                                new VariableNode("el", new DummyFilePlace()), "getValue",
                                                new List<IExpressionNode>()))),
                                    new DeclarationNode(new DummyFilePlace(), new LatteType("List"),
                                        new SingleDeclaration("neigh",
                                            new MethodCallNode(new DummyFilePlace(),
                                                new VariableNode("el", new DummyFilePlace()), "getNeighbours",
                                                new List<IExpressionNode>()))),
                                    new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.NotEquals,
                                        new VariableNode("neigh", new DummyFilePlace()),
                                        new NullNode(new DummyFilePlace()),
                                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                        new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                            new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                                                new SingleDeclaration("n",
                                                    new MethodCallNode(new DummyFilePlace(),
                                                        new VariableNode("neigh", new DummyFilePlace()), "getHead",
                                                        new List<IExpressionNode>()))),
                                            new IfNode(new DummyFilePlace(),
                                                new LogicalNegateNode(
                                                    new MethodCallNode(new DummyFilePlace(),
                                                        new VariableNode("n", new DummyFilePlace()), "isVisited",
                                                        new List<IExpressionNode>()), new DummyFilePlace()),
                                                new BlockNode(
                                                    new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                                        new BlockNode(new DummyFilePlace(),
                                                            new ExpressionStatementNode(new DummyFilePlace(),
                                                                new MethodCallNode(new DummyFilePlace(),
                                                                    new VariableNode("n", new DummyFilePlace()),
                                                                    "markAsVisited", new List<IExpressionNode>())),
                                                            new ExpressionStatementNode(new DummyFilePlace(),
                                                                new MethodCallNode(new DummyFilePlace(),
                                                                    new VariableNode("q", new DummyFilePlace()), "put",
                                                                    new List<IExpressionNode>
                                                                    {
                                                                        new VariableNode("n", new DummyFilePlace())
                                                                    })))))),
                                            new AssignmentNode(new DummyFilePlace(), "neigh",
                                                new MethodCallNode(new DummyFilePlace(),
                                                    new VariableNode("neigh", new DummyFilePlace()), "getTail",
                                                    new List<IExpressionNode>()))))))))))),
                    new FunctionArgument(new LatteType("Queue"), "q"))
            }, new List<IClassDefinitionNode>
            {
                new ClassDefinitionNode(new DummyFilePlace(), "Node", null, new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "init", new BlockNode(
                                new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "visited",
                                    new FalseNode(new DummyFilePlace())),
                                new AssignmentNode(new DummyFilePlace(), "value",
                                    new VariableNode("val", new DummyFilePlace())),
                                new AssignmentNode(new DummyFilePlace(), "neighbours",
                                    new NullNode(new DummyFilePlace()))),
                            new FunctionArgument(LatteType.Int, "val")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Bool, "isVisited",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(),
                                    new VariableNode("visited", new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "markAsVisited",
                            new BlockNode(new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "visited",
                                    new TrueNode(new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "getValue",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("value", new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("List"), "getNeighbours",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(),
                                    new VariableNode("neighbours", new DummyFilePlace())))),
                        new FunctionDefinitionNode(
                            new DummyFilePlace(), LatteType.Void, "addNeighbour", new BlockNode(new DummyFilePlace(),
                                new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                    new VariableNode("neighbours", new DummyFilePlace()),
                                    new NullNode(new DummyFilePlace()),
                                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                    new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                        new AssignmentNode(new DummyFilePlace(), "neighbours",
                                            new NewObjectNode(new DummyFilePlace(), new LatteType("List"))),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new MethodCallNode(new DummyFilePlace(),
                                                new VariableNode("neighbours", new DummyFilePlace()), "makeSingleton",
                                                new List<IExpressionNode>
                                                    {new VariableNode("n", new DummyFilePlace())}))))), new BlockNode(
                                    new DummyFilePlace(), new BlockNode(new DummyFilePlace(), new BlockNode(
                                        new DummyFilePlace(),
                                        new DeclarationNode(new DummyFilePlace(), new LatteType("List"),
                                            new SingleDeclaration("newNeighbours",
                                                new NewObjectNode(new DummyFilePlace(), new LatteType("List")))),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new MethodCallNode(new DummyFilePlace(),
                                                new VariableNode("newNeighbours", new DummyFilePlace()), "cons",
                                                new List<IExpressionNode>
                                                {
                                                    new VariableNode("n", new DummyFilePlace()),
                                                    new VariableNode("neighbours", new DummyFilePlace())
                                                })),
                                        new AssignmentNode(new DummyFilePlace(), "neighbours",
                                            new VariableNode("newNeighbours", new DummyFilePlace()))))))),
                            new FunctionArgument(new LatteType("Node"), "n"))
                    }, new ClassFieldNode(new DummyFilePlace(), "visited", LatteType.Bool),
                    new ClassFieldNode(new DummyFilePlace(), "value", LatteType.Int),
                    new ClassFieldNode(new DummyFilePlace(), "neighbours", new LatteType("List"))),
                new ClassDefinitionNode(new DummyFilePlace(), "List", null, new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "makeSingleton", new BlockNode(
                                new DummyFilePlace(),
                                new AssignmentNode(new DummyFilePlace(), "head",
                                    new VariableNode("node", new DummyFilePlace())),
                                new AssignmentNode(new DummyFilePlace(), "tail", new NullNode(new DummyFilePlace()))),
                            new FunctionArgument(new LatteType("Node"), "node")),
                        new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Node"), "getHead",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("head", new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("List"), "getTail",
                            new BlockNode(new DummyFilePlace(),
                                new ReturnNode(new DummyFilePlace(), new VariableNode("tail", new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "cons", new BlockNode(
                                new DummyFilePlace(),
                                new StructAssignmentNode(new DummyFilePlace(),
                                    new VariableNode("this", new DummyFilePlace()),
                                    "head", new VariableNode("newHead", new DummyFilePlace())),
                                new StructAssignmentNode(new DummyFilePlace(),
                                    new VariableNode("this", new DummyFilePlace()),
                                    "tail", new VariableNode("newTail", new DummyFilePlace()))),
                            new FunctionArgument(new LatteType("Node"), "newHead"),
                            new FunctionArgument(new LatteType("List"), "newTail"))
                    }, new ClassFieldNode(new DummyFilePlace(), "head", new LatteType("Node")),
                    new ClassFieldNode(new DummyFilePlace(), "tail", new LatteType("List"))),
                new ClassDefinitionNode(new DummyFilePlace(), "Queue", null, new List<IFunctionDefinitionNode>
                    {
                        new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Node"), "get", new BlockNode(
                            new DummyFilePlace(), new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                    new VariableNode("first", new DummyFilePlace()),
                                    new NullNode(new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new ReturnNode(new DummyFilePlace(), new NullNode(new DummyFilePlace()))))),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Node"),
                                new SingleDeclaration("retEl",
                                    new ObjectFieldNode(new DummyFilePlace(),
                                        new VariableNode("first", new DummyFilePlace()), "head"))),
                            new AssignmentNode(new DummyFilePlace(), "first",
                                new ObjectFieldNode(new DummyFilePlace(),
                                    new VariableNode("first", new DummyFilePlace()),
                                    "tail")),
                            new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                    new VariableNode("first", new DummyFilePlace()),
                                    new NullNode(new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new AssignmentNode(new DummyFilePlace(), "last",
                                            new NullNode(new DummyFilePlace()))))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("retEl", new DummyFilePlace())))),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "put", new BlockNode(
                                new DummyFilePlace(),
                                new DeclarationNode(new DummyFilePlace(), new LatteType("List"),
                                    new SingleDeclaration("newTail",
                                        new NewObjectNode(new DummyFilePlace(), new LatteType("List")))),
                                new ExpressionStatementNode(new DummyFilePlace(),
                                    new MethodCallNode(new DummyFilePlace(),
                                        new VariableNode("newTail", new DummyFilePlace()),
                                        "makeSingleton",
                                        new List<IExpressionNode> {new VariableNode("n", new DummyFilePlace())})),
                                new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                    new VariableNode("first", new DummyFilePlace()),
                                    new NullNode(new DummyFilePlace()),
                                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                    new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                        new AssignmentNode(new DummyFilePlace(), "first",
                                            new VariableNode("newTail", new DummyFilePlace())),
                                        new AssignmentNode(new DummyFilePlace(), "last",
                                            new VariableNode("newTail", new DummyFilePlace()))))), new BlockNode(
                                    new DummyFilePlace(), new BlockNode(new DummyFilePlace(), new BlockNode(
                                        new DummyFilePlace(),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new MethodCallNode(new DummyFilePlace(),
                                                new VariableNode("last", new DummyFilePlace()), "cons",
                                                new List<IExpressionNode>
                                                {
                                                    new MethodCallNode(new DummyFilePlace(),
                                                        new VariableNode("last", new DummyFilePlace()), "getHead",
                                                        new List<IExpressionNode>()),
                                                    new VariableNode("newTail", new DummyFilePlace())
                                                })),
                                        new AssignmentNode(new DummyFilePlace(), "last",
                                            new VariableNode("newTail", new DummyFilePlace()))))))),
                            new FunctionArgument(new LatteType("Node"), "n")),
                        new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Bool, "isEmpty", new BlockNode(
                            new DummyFilePlace(), new ReturnNode(new DummyFilePlace(), new CompareNode(
                                RelOperator.Equals,
                                new VariableNode("first", new DummyFilePlace()),
                                new NullNode(new DummyFilePlace()),
                                new DummyFilePlace()))))
                    }, new ClassFieldNode(new DummyFilePlace(), "first", new LatteType("List")),
                    new ClassFieldNode(new DummyFilePlace(), "last", new LatteType("List")))
            });
        }

        public string GetOutput()
        {
            return @"1
2
3
4
5
6
7
8
9
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}