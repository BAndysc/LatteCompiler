using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// // autor: Pawel Magryta pm262455
// 
// 
// 
// 
// 
// 
// 
// 
// int main(){
// 	int dlugoscListy = 30;
// 	listaTest(dlugoscListy );
// 	return 0;
// }
// 
// 
// ###### krotki test listy:
// # lista to klasa z publicznymi obiektami bez metod
// 
// void listaTest(int dlugoscListy){
// 	 30;
// 	Lista lista = zwrocListeDlugosci(dlugoscListy);
// 	Lista odKonca = przejdzSieNaKoniecIWypisuj(lista, dlugoscListy);
// 	lista = wrocNaPoczatekIWypisuj(odKonca, dlugoscListy);
// 	printString("po spacerku wartosc pierwszego elementu:");
// 	printInt(lista.wartosc);
// 	if (dlugoscListy >= 5){
// 		Lista drugi = lista.nastepny;
// 		printString("po spacerku wartosc drugiego elementu:");
// 		printInt(lista.nastepny.wartosc);
// 	} else {
// 		return;
// 	}
// }
// 
// 
// Lista przejdzSieNaKoniecIWypisuj(Lista start, int dl){
// 	Lista a = start, b = start;
// 	printString("idziemy na koniec listy: ");
// 	int i = 0;
// 	while (i < dl){
// 		printInt(a.wartosc);
// 		b = a;
// 		a = a.nastepny;
// 		i++;
// 	}
// 	return b;
// }
// 
// Lista wrocNaPoczatekIWypisuj(Lista odKonca, int dl){
// 	Lista a = odKonca, b;
// 	printString("wracamy na poczatek listy: ");
// 	int w = dl;
// 	while (w > 0){
// 		printInt(a.wartosc);
// 		b = a;
// 		a = a.poprzedni;
// 		w--;
// 	}
// 	return b;
// }
// 
// class Lista{
// 	Lista poprzedni, nastepny;
// 	int wartosc;
// }
// 
// Lista zwrocListeDlugosci(int dlugoscListy){
// 	printString("Krotki test listy:");
// 	Lista start = new Lista, a, n;
// 	a = start;
// 	int wsk = 1;
// 	start.wartosc = 0;
// 	while (wsk != dlugoscListy){
// 		start.poprzedni = null;
// 		a.nastepny = new Lista;
// 		n = a;
// 		a = a.nastepny;
// 		a.wartosc = wsk;
// 		a.poprzedni = n;
// 		wsk++;
// 	}
// 	a.nastepny = null;
// 	printString("wygenerowal liste 2kierunkowa dlugosci :");
// 	printInt(dlugoscListy);
// 	printString("__________");
// 	return start;
// }
// 
// 
// 
// 
// 

namespace TestPrograms.Community
{
    public class TestProgramProviderList : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return new ProgramNode(new List<IFunctionDefinitionNode>
                {
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "main", new BlockNode(
                        new DummyFilePlace(),
                        new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                            new SingleDeclaration("dlugoscListy", new IntNode(30, new DummyFilePlace()))),
                        new ExpressionStatementNode(new DummyFilePlace(),
                            new FunctionCallNode(new DummyFilePlace(), "listaTest",
                                new VariableNode("dlugoscListy", new DummyFilePlace()))),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "listaTest", new BlockNode(
                            new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(), new IntNode(30, new DummyFilePlace())),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("lista",
                                    new FunctionCallNode(new DummyFilePlace(), "zwrocListeDlugosci",
                                        new VariableNode("dlugoscListy", new DummyFilePlace())))),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("odKonca",
                                    new FunctionCallNode(new DummyFilePlace(), "przejdzSieNaKoniecIWypisuj",
                                        new VariableNode("lista", new DummyFilePlace()),
                                        new VariableNode("dlugoscListy", new DummyFilePlace())))),
                            new AssignmentNode(new DummyFilePlace(), "lista",
                                new FunctionCallNode(new DummyFilePlace(), "wrocNaPoczatekIWypisuj",
                                    new VariableNode("odKonca", new DummyFilePlace()),
                                    new VariableNode("dlugoscListy", new DummyFilePlace()))),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("po spacerku wartosc pierwszego elementu:", new DummyFilePlace()))),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printInt",
                                    new ObjectFieldNode(new DummyFilePlace(),
                                        new VariableNode("lista", new DummyFilePlace()),
                                        "wartosc"))),
                            new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterEquals,
                                    new VariableNode("dlugoscListy", new DummyFilePlace()),
                                    new IntNode(5, new DummyFilePlace()),
                                    new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                    new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                            new SingleDeclaration("drugi",
                                                new ObjectFieldNode(new DummyFilePlace(),
                                                    new VariableNode("lista", new DummyFilePlace()), "nastepny"))),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode(new DummyFilePlace(), "printString",
                                                new StringNode("po spacerku wartosc drugiego elementu:",
                                                    new DummyFilePlace()))),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                                new ObjectFieldNode(new DummyFilePlace(),
                                                    new ObjectFieldNode(new DummyFilePlace(),
                                                        new VariableNode("lista", new DummyFilePlace()), "nastepny"),
                                                    "wartosc")))))),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new BlockNode(new DummyFilePlace(),
                                            new VoidReturnNode(new DummyFilePlace())))))),
                        new FunctionArgument(LatteType.Int, "dlugoscListy")),
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Lista"),
                        "przejdzSieNaKoniecIWypisuj",
                        new BlockNode(new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("a", new VariableNode("start", new DummyFilePlace())),
                                new SingleDeclaration("b", new VariableNode("start", new DummyFilePlace()))),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("idziemy na koniec listy: ", new DummyFilePlace()))),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("i", new IntNode(0, new DummyFilePlace()))),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                new VariableNode("i", new DummyFilePlace()),
                                new VariableNode("dl", new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                    new ExpressionStatementNode(new DummyFilePlace(),
                                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                                            new ObjectFieldNode(new DummyFilePlace(),
                                                new VariableNode("a", new DummyFilePlace()), "wartosc"))),
                                    new AssignmentNode(new DummyFilePlace(), "b",
                                        new VariableNode("a", new DummyFilePlace())),
                                    new AssignmentNode(new DummyFilePlace(), "a",
                                        new ObjectFieldNode(new DummyFilePlace(),
                                            new VariableNode("a", new DummyFilePlace()), "nastepny")),
                                    new IncrementNode(new DummyFilePlace(), "i"))))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("b", new DummyFilePlace()))),
                        new FunctionArgument(new LatteType("Lista"), "start"),
                        new FunctionArgument(LatteType.Int, "dl")),
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Lista"), "wrocNaPoczatekIWypisuj",
                        new BlockNode(new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("a", new VariableNode("odKonca", new DummyFilePlace())),
                                new SingleDeclaration("b", null)),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("wracamy na poczatek listy: ", new DummyFilePlace()))),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("w", new VariableNode("dl", new DummyFilePlace()))),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                new VariableNode("w", new DummyFilePlace()),
                                new IntNode(0, new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                    new ExpressionStatementNode(new DummyFilePlace(),
                                        new FunctionCallNode(new DummyFilePlace(), "printInt",
                                            new ObjectFieldNode(new DummyFilePlace(),
                                                new VariableNode("a", new DummyFilePlace()), "wartosc"))),
                                    new AssignmentNode(new DummyFilePlace(), "b",
                                        new VariableNode("a", new DummyFilePlace())),
                                    new AssignmentNode(new DummyFilePlace(), "a",
                                        new ObjectFieldNode(new DummyFilePlace(),
                                            new VariableNode("a", new DummyFilePlace()), "poprzedni")),
                                    new DecrementNode(new DummyFilePlace(), "w"))))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("b", new DummyFilePlace()))),
                        new FunctionArgument(new LatteType("Lista"), "odKonca"),
                        new FunctionArgument(LatteType.Int, "dl")),
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Lista"), "zwrocListeDlugosci",
                        new BlockNode(new DummyFilePlace(),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("Krotki test listy: ", new DummyFilePlace()))),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("start",
                                    new NewObjectNode(new DummyFilePlace(), new LatteType("Lista"))),
                                new SingleDeclaration("a", null), new SingleDeclaration("n", null)),
                            new AssignmentNode(new DummyFilePlace(), "a",
                                new VariableNode("start", new DummyFilePlace())),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("wsk", new IntNode(1, new DummyFilePlace()))),
                            new StructAssignmentNode(new DummyFilePlace(),
                                new VariableNode("start", new DummyFilePlace()),
                                "wartosc", new IntNode(0, new DummyFilePlace())),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.NotEquals,
                                new VariableNode("wsk", new DummyFilePlace()),
                                new VariableNode("dlugoscListy", new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                    new StructAssignmentNode(new DummyFilePlace(),
                                        new VariableNode("start", new DummyFilePlace()), "poprzedni",
                                        new NullNode(new DummyFilePlace())),
                                    new StructAssignmentNode(new DummyFilePlace(),
                                        new VariableNode("a", new DummyFilePlace()), "nastepny",
                                        new NewObjectNode(new DummyFilePlace(), new LatteType("Lista"))),
                                    new AssignmentNode(new DummyFilePlace(), "n",
                                        new VariableNode("a", new DummyFilePlace())),
                                    new AssignmentNode(new DummyFilePlace(), "a",
                                        new ObjectFieldNode(new DummyFilePlace(),
                                            new VariableNode("a", new DummyFilePlace()), "nastepny")),
                                    new StructAssignmentNode(new DummyFilePlace(),
                                        new VariableNode("a", new DummyFilePlace()), "wartosc",
                                        new VariableNode("wsk", new DummyFilePlace())),
                                    new StructAssignmentNode(new DummyFilePlace(),
                                        new VariableNode("a", new DummyFilePlace()), "poprzedni",
                                        new VariableNode("n", new DummyFilePlace())),
                                    new IncrementNode(new DummyFilePlace(), "wsk"))))),
                            new StructAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                "nastepny", new NullNode(new DummyFilePlace())),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("wygenerowal liste 2kierunkowa dlugosci :", new DummyFilePlace()))),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printInt",
                                    new VariableNode("dlugoscListy", new DummyFilePlace()))),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("__________", new DummyFilePlace()))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("start", new DummyFilePlace()))),
                        new FunctionArgument(LatteType.Int, "dlugoscListy"))
                },
                new List<IClassDefinitionNode>
                {
                    new ClassDefinitionNode(new DummyFilePlace(), "Lista", null, new List<IFunctionDefinitionNode>(),
                        new ClassFieldNode(new DummyFilePlace(), "poprzedni", new LatteType("Lista")),
                        new ClassFieldNode(new DummyFilePlace(), "nastepny", new LatteType("Lista")),
                        new ClassFieldNode(new DummyFilePlace(), "wartosc", LatteType.Int))
                });
        }

        public string GetOutput()
        {
            return @"Krotki test listy: 
wygenerowal liste 2kierunkowa dlugosci :
30
__________
idziemy na koniec listy: 
0
1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21
22
23
24
25
26
27
28
29
wracamy na poczatek listy: 
29
28
27
26
25
24
23
22
21
20
19
18
17
16
15
14
13
12
11
10
9
8
7
6
5
4
3
2
1
0
po spacerku wartosc pierwszego elementu:
0
po spacerku wartosc drugiego elementu:
1
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}