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
// 	testMergeSort(dlugoscListy);
// 	return 0;
// }
// 
// 
// ////// merge sort na tablicoListach
// 
// void testMergeSort(int dlugoscListy){
// 	Lista start = generujTablicoListeDoSortowaniaMerge13co7Malejaco(dlugoscListy, true);
// 	Lista malejaco = mergeSort(start, 0, dlugoscListy);
// 	przejdzSieNaKoniecIWypisuj(malejaco, dlugoscListy);
// }
// 
// Lista mergeSort(Lista start, int pocz, int kon1Za){
// 	Lista i1, i2;
// 	if (kon1Za - pocz > 1){
// 		int srodek = (kon1Za - pocz) /2 + pocz;
// 		i1 = mergeSort(start, pocz, srodek);
// 		i2 = mergeSort(start, srodek, kon1Za);
// 		return scalaj(i1, srodek - pocz, i2, kon1Za - srodek);
// 	}
// 	Lista n = new Lista;
// 	n.wartosc = pokazWartosc(start, pocz);
// 	return n;
// }
// 
// Lista scalaj(Lista lj, int ljLength, Lista ld, int ldLength){
// 	int w1 = 0, w2 = 0, ws = 0;
// 	Lista start = generujTablicoListeDoSortowaniaMerge13co7Malejaco(ljLength + ldLength, false);
// 	int wart = pokazWartosc(lj, w1);
// 	int wart2 = pokazWartosc(ld, w2);
// 	while (ws < ljLength + ldLength){
// 		if (w1 == ljLength)	wart = -1;
// 		else wart = pokazWartosc(lj, w1);
// 		if (w2 == ldLength)	wart2 = -1;
// 		else wart2 = pokazWartosc(ld, w2);
// 		if (wart2 > wart){
// 			w2++;		
// 			ladujWartosc(start, ws, wart2);
// 		} else{
// 			w1++;
// 			ladujWartosc(start, ws, wart);
// 		}
// 		ws++;
// 	}
// 	return start;
// }
// 
// //////////////////////////////////
// int pokazWartosc(Lista start, int poz){
// 	int w = 0;
// 	Lista a = start;
// 	while (w != poz) {
// 		a = a.nastepny;
// 		w++;
// 	}
// 	return a.wartosc;
// }
// void ladujWartosc(Lista start, int poz, int wartosc){
// 	int w = 0;
// 	Lista a = start;
// 	while (w != poz) {
// 		a = a.nastepny;
// 		w++;
// 	}
// 	a.wartosc = wartosc;
// }
// ///////////////////////////////
// 
// Lista generujTablicoListeDoSortowaniaMerge13co7Malejaco(int dlugoscListy, boolean pisz){
// 	if (pisz) printString("robimy liste do mergeSorta:");
// 	Lista start = new Lista, a, n;
// 	a = start;
// 	int wsk = 1;
// 	start.wartosc = 0;
// 	if (pisz) printInt(start.wartosc);
// 	while (wsk != dlugoscListy){
// 		start.poprzedni = null;
// 		a.nastepny = new Lista;
// 		n = a;
// 		a = a.nastepny;
// 		if (wsk % 5 == 3) a.wartosc = dlugoscListy - wsk / 2;
// 		else a.wartosc = wsk % 13;
// 		
// 		a.poprzedni = n;
// 		//a.wartosc = wsk;
// 		if (pisz) printInt(a.wartosc);
// 		wsk++;
// 	}
// 	a.nastepny = null;
// 	if (pisz) printString("wygenerowal liste 2kierunkowa dziwna dlugosci :");
// 	if (pisz) printInt(dlugoscListy);
// 	if (pisz) printString("__________");
// 	return start;
// }
// 
// ###### listy
// 
// Lista przejdzSieNaKoniecIWypisuj(Lista start, int dl){
// 	Lista a = start, b = start;
// 	printString("idziemy na koniec listy (ma byc nierosnaco): ");
// 	int wsk = 0;
// 	while (wsk < dl){
// 		printInt(a.wartosc);
// 		b = a;
// 		a = a.nastepny;
// 		wsk++;
// 	}
// 	return b;
// }
// 
// class Lista{
// 	Lista poprzedni, nastepny;
// 	int wartosc;
// }
// 
// 
// 
// 

namespace TestPrograms.Community
{
    public class TestProgramProviderMergeSort : ITestProgramProvider
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
                            new FunctionCallNode(new DummyFilePlace(), "testMergeSort",
                                new VariableNode("dlugoscListy", new DummyFilePlace()))),
                        new ReturnNode(new DummyFilePlace(), new IntNode(0, new DummyFilePlace())))),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "testMergeSort", new BlockNode(
                            new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("start",
                                    new FunctionCallNode(new DummyFilePlace(),
                                        "generujTablicoListeDoSortowaniaMerge13co7Malejaco",
                                        new VariableNode("dlugoscListy", new DummyFilePlace()),
                                        new TrueNode(new DummyFilePlace())))),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("malejaco",
                                    new FunctionCallNode(new DummyFilePlace(), "mergeSort",
                                        new VariableNode("start", new DummyFilePlace()),
                                        new IntNode(0, new DummyFilePlace()),
                                        new VariableNode("dlugoscListy", new DummyFilePlace())))),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "przejdzSieNaKoniecIWypisuj",
                                    new VariableNode("malejaco", new DummyFilePlace()),
                                    new VariableNode("dlugoscListy", new DummyFilePlace())))),
                        new FunctionArgument(LatteType.Int, "dlugoscListy")),
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Lista"), "mergeSort", new BlockNode(
                            new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("i1", null),
                                new SingleDeclaration("i2", null)),
                            new IfNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                new BinaryNode(BinaryOperator.Sub,
                                    new VariableNode("kon1Za", new DummyFilePlace()),
                                    new VariableNode("pocz", new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new IntNode(1, new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(), new DeclarationNode(new DummyFilePlace(),
                                        LatteType.Int,
                                        new SingleDeclaration("srodek", new BinaryNode(BinaryOperator.Add,
                                            new BinaryNode(BinaryOperator.Div,
                                                new BinaryNode(BinaryOperator.Sub,
                                                    new VariableNode("kon1Za", new DummyFilePlace()),
                                                    new VariableNode("pocz", new DummyFilePlace()),
                                                    new DummyFilePlace()),
                                                new IntNode(2, new DummyFilePlace()),
                                                new DummyFilePlace()),
                                            new VariableNode("pocz", new DummyFilePlace()),
                                            new DummyFilePlace()))),
                                    new AssignmentNode(new DummyFilePlace(), "i1",
                                        new FunctionCallNode(new DummyFilePlace(), "mergeSort",
                                            new VariableNode("start", new DummyFilePlace()),
                                            new VariableNode("pocz", new DummyFilePlace()),
                                            new VariableNode("srodek", new DummyFilePlace()))),
                                    new AssignmentNode(new DummyFilePlace(), "i2",
                                        new FunctionCallNode(new DummyFilePlace(), "mergeSort",
                                            new VariableNode("start", new DummyFilePlace()),
                                            new VariableNode("srodek", new DummyFilePlace()),
                                            new VariableNode("kon1Za", new DummyFilePlace()))),
                                    new ReturnNode(new DummyFilePlace(), new FunctionCallNode(new DummyFilePlace(),
                                        "scalaj",
                                        new VariableNode("i1", new DummyFilePlace()), new BinaryNode(BinaryOperator.Sub,
                                            new VariableNode("srodek", new DummyFilePlace()),
                                            new VariableNode("pocz", new DummyFilePlace()),
                                            new DummyFilePlace()), new VariableNode("i2", new DummyFilePlace()),
                                        new BinaryNode(
                                            BinaryOperator.Sub,
                                            new VariableNode("kon1Za", new DummyFilePlace()),
                                            new VariableNode("srodek", new DummyFilePlace()),
                                            new DummyFilePlace()))))))),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("n",
                                    new NewObjectNode(new DummyFilePlace(), new LatteType("Lista")))),
                            new StructAssignmentNode(new DummyFilePlace(), new VariableNode("n", new DummyFilePlace()),
                                "wartosc",
                                new FunctionCallNode(new DummyFilePlace(), "pokazWartosc",
                                    new VariableNode("start", new DummyFilePlace()),
                                    new VariableNode("pocz", new DummyFilePlace()))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("n", new DummyFilePlace()))),
                        new FunctionArgument(new LatteType("Lista"), "start"),
                        new FunctionArgument(LatteType.Int, "pocz"),
                        new FunctionArgument(LatteType.Int, "kon1Za")),
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Lista"), "scalaj", new BlockNode(
                            new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("w1", new IntNode(0, new DummyFilePlace())),
                                new SingleDeclaration("w2", new IntNode(0, new DummyFilePlace())),
                                new SingleDeclaration("ws", new IntNode(0, new DummyFilePlace()))),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"), new SingleDeclaration(
                                "start",
                                new FunctionCallNode(new DummyFilePlace(),
                                    "generujTablicoListeDoSortowaniaMerge13co7Malejaco",
                                    new BinaryNode(BinaryOperator.Add,
                                        new VariableNode("ljLength", new DummyFilePlace()),
                                        new VariableNode("ldLength", new DummyFilePlace()),
                                        new DummyFilePlace()), new FalseNode(new DummyFilePlace())))),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("wart",
                                    new FunctionCallNode(new DummyFilePlace(), "pokazWartosc",
                                        new VariableNode("lj", new DummyFilePlace()),
                                        new VariableNode("w1", new DummyFilePlace())))),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("wart2",
                                    new FunctionCallNode(new DummyFilePlace(), "pokazWartosc",
                                        new VariableNode("ld", new DummyFilePlace()),
                                        new VariableNode("w2", new DummyFilePlace())))),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                new VariableNode("ws", new DummyFilePlace()),
                                new BinaryNode(BinaryOperator.Add,
                                    new VariableNode("ljLength", new DummyFilePlace()),
                                    new VariableNode("ldLength", new DummyFilePlace()),
                                    new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(), new IfElseNode(new DummyFilePlace(),
                                        new CompareNode(
                                            RelOperator.Equals,
                                            new VariableNode("w1", new DummyFilePlace()),
                                            new VariableNode("ljLength", new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new BlockNode(new DummyFilePlace(),
                                            new BlockNode(new DummyFilePlace(),
                                                new AssignmentNode(new DummyFilePlace(), "wart",
                                                    new NegateNode(new IntNode(1, new DummyFilePlace()),
                                                        new DummyFilePlace())))),
                                        new BlockNode(new DummyFilePlace(),
                                            new BlockNode(new DummyFilePlace(),
                                                new AssignmentNode(new DummyFilePlace(), "wart",
                                                    new FunctionCallNode(new DummyFilePlace(), "pokazWartosc",
                                                        new VariableNode("lj", new DummyFilePlace()),
                                                        new VariableNode("w1", new DummyFilePlace())))))),
                                    new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                            new VariableNode("w2", new DummyFilePlace()),
                                            new VariableNode("ldLength", new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new BlockNode(new DummyFilePlace(),
                                            new BlockNode(new DummyFilePlace(),
                                                new AssignmentNode(new DummyFilePlace(), "wart2",
                                                    new NegateNode(new IntNode(1, new DummyFilePlace()),
                                                        new DummyFilePlace())))),
                                        new BlockNode(new DummyFilePlace(),
                                            new BlockNode(new DummyFilePlace(),
                                                new AssignmentNode(new DummyFilePlace(), "wart2",
                                                    new FunctionCallNode(new DummyFilePlace(), "pokazWartosc",
                                                        new VariableNode("ld", new DummyFilePlace()),
                                                        new VariableNode("w2", new DummyFilePlace())))))),
                                    new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.GreaterThan,
                                        new VariableNode("wart2", new DummyFilePlace()),
                                        new VariableNode("wart", new DummyFilePlace()),
                                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                        new DummyFilePlace(), new BlockNode(new DummyFilePlace(),
                                            new IncrementNode(new DummyFilePlace(), "w2"),
                                            new ExpressionStatementNode(new DummyFilePlace(),
                                                new FunctionCallNode(new DummyFilePlace(), "ladujWartosc",
                                                    new VariableNode("start", new DummyFilePlace()),
                                                    new VariableNode("ws", new DummyFilePlace()),
                                                    new VariableNode("wart2", new DummyFilePlace())))))), new BlockNode(
                                        new DummyFilePlace(), new BlockNode(new DummyFilePlace(), new BlockNode(
                                            new DummyFilePlace(), new IncrementNode(new DummyFilePlace(), "w1"),
                                            new ExpressionStatementNode(new DummyFilePlace(),
                                                new FunctionCallNode(new DummyFilePlace(), "ladujWartosc",
                                                    new VariableNode("start", new DummyFilePlace()),
                                                    new VariableNode("ws", new DummyFilePlace()),
                                                    new VariableNode("wart", new DummyFilePlace()))))))),
                                    new IncrementNode(new DummyFilePlace(), "ws"))))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("start", new DummyFilePlace()))),
                        new FunctionArgument(new LatteType("Lista"), "lj"),
                        new FunctionArgument(LatteType.Int, "ljLength"),
                        new FunctionArgument(new LatteType("Lista"), "ld"),
                        new FunctionArgument(LatteType.Int, "ldLength")),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Int, "pokazWartosc", new BlockNode(
                            new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("w", new IntNode(0, new DummyFilePlace()))),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("a", new VariableNode("start", new DummyFilePlace()))),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.NotEquals,
                                new VariableNode("w", new DummyFilePlace()),
                                new VariableNode("poz", new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(),
                                    new AssignmentNode(new DummyFilePlace(), "a",
                                        new ObjectFieldNode(new DummyFilePlace(),
                                            new VariableNode("a", new DummyFilePlace()),
                                            "nastepny")),
                                    new IncrementNode(new DummyFilePlace(), "w"))))),
                            new ReturnNode(new DummyFilePlace(),
                                new ObjectFieldNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                    "wartosc"))), new FunctionArgument(new LatteType("Lista"), "start"),
                        new FunctionArgument(LatteType.Int, "poz")),
                    new FunctionDefinitionNode(new DummyFilePlace(), LatteType.Void, "ladujWartosc", new BlockNode(
                            new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("w", new IntNode(0, new DummyFilePlace()))),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("a", new VariableNode("start", new DummyFilePlace()))),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.NotEquals,
                                new VariableNode("w", new DummyFilePlace()),
                                new VariableNode("poz", new DummyFilePlace()),
                                new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                new DummyFilePlace(),
                                new BlockNode(new DummyFilePlace(),
                                    new AssignmentNode(new DummyFilePlace(), "a",
                                        new ObjectFieldNode(new DummyFilePlace(),
                                            new VariableNode("a", new DummyFilePlace()),
                                            "nastepny")),
                                    new IncrementNode(new DummyFilePlace(), "w"))))),
                            new StructAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                "wartosc", new VariableNode("wartosc", new DummyFilePlace()))),
                        new FunctionArgument(new LatteType("Lista"), "start"),
                        new FunctionArgument(LatteType.Int, "poz"),
                        new FunctionArgument(LatteType.Int, "wartosc")),
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Lista"),
                        "generujTablicoListeDoSortowaniaMerge13co7Malejaco", new BlockNode(new DummyFilePlace(),
                            new IfNode(new DummyFilePlace(), new VariableNode("pisz", new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode(new DummyFilePlace(), "printString",
                                                new StringNode("robimy liste do mergeSorta:",
                                                    new DummyFilePlace())))))),
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
                            new IfNode(new DummyFilePlace(), new VariableNode("pisz", new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                                new ObjectFieldNode(new DummyFilePlace(),
                                                    new VariableNode("start", new DummyFilePlace()), "wartosc")))))),
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
                                    new IfElseNode(new DummyFilePlace(), new CompareNode(RelOperator.Equals,
                                        new BinaryNode(BinaryOperator.Mod,
                                            new VariableNode("wsk", new DummyFilePlace()),
                                            new IntNode(5, new DummyFilePlace()),
                                            new DummyFilePlace()),
                                        new IntNode(3, new DummyFilePlace()),
                                        new DummyFilePlace()), new BlockNode(new DummyFilePlace(), new BlockNode(
                                        new DummyFilePlace(), new StructAssignmentNode(new DummyFilePlace(),
                                            new VariableNode("a", new DummyFilePlace()), "wartosc", new BinaryNode(
                                                BinaryOperator.Sub,
                                                new VariableNode("dlugoscListy", new DummyFilePlace()),
                                                new BinaryNode(BinaryOperator.Div,
                                                    new VariableNode("wsk", new DummyFilePlace()),
                                                    new IntNode(2, new DummyFilePlace()),
                                                    new DummyFilePlace()),
                                                new DummyFilePlace())))), new BlockNode(new DummyFilePlace(),
                                        new BlockNode(new DummyFilePlace(), new StructAssignmentNode(
                                            new DummyFilePlace(),
                                            new VariableNode("a", new DummyFilePlace()), "wartosc", new BinaryNode(
                                                BinaryOperator.Mod,
                                                new VariableNode("wsk", new DummyFilePlace()),
                                                new IntNode(13, new DummyFilePlace()),
                                                new DummyFilePlace()))))),
                                    new StructAssignmentNode(new DummyFilePlace(),
                                        new VariableNode("a", new DummyFilePlace()), "poprzedni",
                                        new VariableNode("n", new DummyFilePlace())),
                                    new IfNode(new DummyFilePlace(), new VariableNode("pisz", new DummyFilePlace()),
                                        new BlockNode(new DummyFilePlace(),
                                            new BlockNode(new DummyFilePlace(),
                                                new ExpressionStatementNode(new DummyFilePlace(),
                                                    new FunctionCallNode(new DummyFilePlace(), "printInt",
                                                        new ObjectFieldNode(new DummyFilePlace(),
                                                            new VariableNode("a", new DummyFilePlace()),
                                                            "wartosc")))))),
                                    new IncrementNode(new DummyFilePlace(), "wsk"))))),
                            new StructAssignmentNode(new DummyFilePlace(), new VariableNode("a", new DummyFilePlace()),
                                "nastepny", new NullNode(new DummyFilePlace())),
                            new IfNode(new DummyFilePlace(), new VariableNode("pisz", new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode(new DummyFilePlace(), "printString",
                                                new StringNode("wygenerowal liste 2kierunkowa dziwna dlugosci :",
                                                    new DummyFilePlace())))))),
                            new IfNode(new DummyFilePlace(), new VariableNode("pisz", new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode(new DummyFilePlace(), "printInt",
                                                new VariableNode("dlugoscListy", new DummyFilePlace())))))),
                            new IfNode(new DummyFilePlace(), new VariableNode("pisz", new DummyFilePlace()),
                                new BlockNode(new DummyFilePlace(),
                                    new BlockNode(new DummyFilePlace(),
                                        new ExpressionStatementNode(new DummyFilePlace(),
                                            new FunctionCallNode(new DummyFilePlace(), "printString",
                                                new StringNode("__________", new DummyFilePlace())))))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("start", new DummyFilePlace()))),
                        new FunctionArgument(LatteType.Int, "dlugoscListy"),
                        new FunctionArgument(LatteType.Bool, "pisz")),
                    new FunctionDefinitionNode(new DummyFilePlace(), new LatteType("Lista"),
                        "przejdzSieNaKoniecIWypisuj",
                        new BlockNode(new DummyFilePlace(),
                            new DeclarationNode(new DummyFilePlace(), new LatteType("Lista"),
                                new SingleDeclaration("a", new VariableNode("start", new DummyFilePlace())),
                                new SingleDeclaration("b", new VariableNode("start", new DummyFilePlace()))),
                            new ExpressionStatementNode(new DummyFilePlace(),
                                new FunctionCallNode(new DummyFilePlace(), "printString",
                                    new StringNode("idziemy na koniec listy (ma byc nierosnaco): ",
                                        new DummyFilePlace()))),
                            new DeclarationNode(new DummyFilePlace(), LatteType.Int,
                                new SingleDeclaration("wsk", new IntNode(0, new DummyFilePlace()))),
                            new WhileNode(new DummyFilePlace(), new CompareNode(RelOperator.LessThan,
                                new VariableNode("wsk", new DummyFilePlace()),
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
                                    new IncrementNode(new DummyFilePlace(), "wsk"))))),
                            new ReturnNode(new DummyFilePlace(), new VariableNode("b", new DummyFilePlace()))),
                        new FunctionArgument(new LatteType("Lista"), "start"),
                        new FunctionArgument(LatteType.Int, "dl"))
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
            return @"robimy liste do mergeSorta:
0
1
2
29
4
5
6
7
26
9
10
11
12
24
1
2
3
4
21
6
7
8
9
19
11
12
0
1
16
3
wygenerowal liste 2kierunkowa dziwna dlugosci :
30
__________
idziemy na koniec listy (ma byc nierosnaco): 
29
26
24
21
19
16
12
12
11
11
10
9
9
8
7
7
6
6
5
4
4
3
3
2
2
1
1
1
0
0
";
        }

        public string GetInput()
        {
            return null;
        }
    }
}