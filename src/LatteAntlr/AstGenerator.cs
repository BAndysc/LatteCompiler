using System;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using LatteAntlr.AST;
using LatteAntlr.AST.Generators;
using LatteAntlr.Exceptions;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace LatteAntlr
{
    public class AstGenerator
    {
        private readonly string sourceCode;

        public AstGenerator(string sourceCode)
        {
            this.sourceCode = sourceCode;
        }

        public IProgram GenerateAst()
        {
            AntlrInputStream inputStream = new AntlrInputStream(sourceCode);
            ITokenSource lexer = new LatteLexer(inputStream);
            ITokenStream stream = new CommonTokenStream(lexer);
            LatteParser parser = new LatteParser(stream);
            
            parser.BuildParseTree = true;
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new CustomErrorListener(sourceCode));
            //parser.ErrorHandler = new BailErrorStrategy();

            IProgram program;
            
            try
            {
                program = new ProgramGenerator().Visit(parser.program());
            }
            catch (Antlr4.Runtime.Misc.ParseCanceledException e)
            {
                throw new ParserException(e.InnerException, new FilePlace(0, ""));
            }
            
            if (parser.NumberOfSyntaxErrors > 0)
                program = null;
            
            return program;
        }
    }

    public class CustomErrorListener : IAntlrErrorListener<IToken>
    {
        private readonly string sourceCode;

        public CustomErrorListener(string sourceCode)
        {
            this.sourceCode = sourceCode;
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine,
            string msg, RecognitionException e)
        {
            throw new ParserException(new Exception(msg), new FilePlace(line, sourceCode.Split('\n')[line - 1]));
        }
    }
}