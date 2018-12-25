using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Sharpen;
using Antlr4.Runtime.Tree;
using LatteAntlr;
using LatteBase;
using LatteBase.Visitors;
using LatteTypeChecker;

namespace Frontend
{
    public class Parser
    {
        public void Parse(string text)
        {
            var programTree = new AstGenerator(text).GenerateAst();

            var typeChecker = new TypeChecker();

            typeChecker.Visit(programTree);
        }
    }
//
//    public class Listener2 : LatteBaseListener
//    {
//        public override void EnterProgram(LatteParser.ProgramContext context)
//        {
//         //   Console.WriteLine("Enter program");
//        }
//
//        public override void VisitErrorNode(IErrorNode node)
//        {
//         //   Console.WriteLine("?? " + node.GetText());
//        }
//    }
//
//    public class BBB : IAntlrErrorListener<int>
//    {
//        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine,
//            string msg, RecognitionException e)
//        {
//            throw new NotImplementedException();
//        }
//    }
//    
//    
//    public class Listener : BaseErrorListener
//    {
//        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine,
//            string msg, RecognitionException e)
//        {
//            Console.WriteLine("SYNTAX ERROR!: " + msg);
//        }
//        
//        public override void ReportAmbiguity(Antlr4.Runtime.Parser recognizer, DFA dfa, int startIndex, int stopIndex, bool exact, BitSet ambigAlts,
//            ATNConfigSet configs)
//        {
//            Console.WriteLine("uu");
//        }
//
//        public override void ReportAttemptingFullContext(Antlr4.Runtime.Parser recognizer, DFA dfa, int startIndex, int stopIndex, BitSet conflictingAlts,
//            SimulatorState conflictState)
//        {
//            Console.WriteLine("bbfb");
//        }
//
//        public override void ReportContextSensitivity(Antlr4.Runtime.Parser recognizer, DFA dfa, int startIndex, int stopIndex, int prediction,
//            SimulatorState acceptState)
//        {
//            Console.WriteLine("saa");
//        }
//        
//    }
    
    public interface IMemory
    {
        void Set(string id, int value);
        void Alloc(string id, int value);
        int? Get(string id);
        IMemory BlockCopy();
    }

    public class FreeLoc
    {
        private int nextLoc = 0;
        public int GetLocation()
        {
            return nextLoc++;
        }
    }
    
    public class State
    {
        public State(FreeLoc loc)
        {
            freeLoc = loc;
        }
        
        public State(State state)
        {
            this.state = new Dictionary<string, int>(state.state);
            freeLoc = state.freeLoc;
        }
        
        private Dictionary<string, int> state = new Dictionary<string, int>();

        private FreeLoc freeLoc;

        public int Realloc(string id)
        {
            int loc = freeLoc.GetLocation();
            state[id] = loc;
            return loc;
        }

        public int Get(string id)
        {
            return state[id];
        }

        public bool Contains(string id)
        {
            return state.ContainsKey(id);
        }
    }

    public class Store
    {
        private Dictionary<int, int> memory = new Dictionary<int, int>();


        public void Set(int loc, int value)
        {
            memory[loc] = value;
        }

        public int Get(int loc)
        {
            return memory[loc];
        }
    }
    
    public class Memory : IMemory
    {
        private readonly State _state;
        private readonly Store _store;

        public Memory(State state, Store store)
        {
            _state = state;
            _store = store;
        }

        public void Alloc(string id, int value)
        {
            _store.Set(_state.Realloc(id), value);
        }
        
        public void Set(string id, int value)
        {
            _store.Set(_state.Get(id), value);
        }

        public int? Get(string id)
        {
            if (!_state.Contains(id))
                return null;
            return _store.Get(_state.Get(id));
        }

        public IMemory BlockCopy()
        {
            return new Memory(new State(_state), _store);
        }
    }
    
}