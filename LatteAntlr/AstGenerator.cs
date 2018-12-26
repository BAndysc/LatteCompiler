using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using LatteAntlr.AST;
using LatteAntlr.AST.Generators;
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

            parser.ErrorHandler = new BailErrorStrategy();

            IProgram program;
            
            try
            {
                program = new ProgramGenerator().Visit(parser.program());
            }
            catch (Antlr4.Runtime.Misc.ParseCanceledException e)
            {
                program = null;
            }
            
            
            if (parser.NumberOfSyntaxErrors > 0)
                program = null;
            
            return program;
        }
    }
}