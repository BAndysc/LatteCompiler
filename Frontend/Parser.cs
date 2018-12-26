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
using LatteBase.AST;
using LatteBase.CodeGenerators;
using LatteBase.Visitors;
using LatteTreeOptimizer;
using LatteTypeChecker;
using LatteTypeChecker.Exceptions;

namespace Frontend
{
    public class Parser
    {
        public void Parse(string file, string text)
        {
            var programTree = new AstGenerator(text).GenerateAst();

            var typeChecker = new StaticAnalysisChecker();

            if (programTree == null)
            {
                Console.WriteLine("Syntax error");
                Environment.Exit(-1);
            }
            
            try {
                typeChecker.Visit(programTree);
            } 
            catch (TypeCheckerException e)
            {
                Console.WriteLine($"Type check error: {e}");
                Environment.Exit(-1);
            }
        }
    }
}