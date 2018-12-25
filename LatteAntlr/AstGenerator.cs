using System;
using Antlr4.Runtime;
using LatteAntlr.AST.Generators;
using LatteBase.AST;

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

            return new ProgramGenerator().Visit(parser.program());
        }
    }
}