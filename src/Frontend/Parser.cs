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
using LatteAntlr.Exceptions;
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
        public IProgram Parse(string file, string text)
        {
            try
            {
                var programTree = new AstGenerator(text).GenerateAst();

                var typeChecker = new StaticAnalysisChecker();

                typeChecker.Visit(programTree);

                Console.WriteLine("OK");

                return programTree;
            }
            catch (TypeCheckerException e)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine($"Type check error: {e}");
                Environment.Exit(-1);
            }
            catch (SyntaxException e)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine($"Syntax error: {e}");
                Environment.Exit(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine($"Error: {e}");
                Environment.Exit(-1);
            }

            return null;
        }
    }
}