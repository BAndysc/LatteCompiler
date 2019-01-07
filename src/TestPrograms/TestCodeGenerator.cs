using System;
using System.IO;
using System.Linq;
using LatteAntlr;
using LatteBase.CodeGenerators;

namespace TestPrograms
{
    public class TestCodeGenerator
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: ./TestPrograms [program] ");
                Environment.Exit(-1);
            }

            var codeGenerator = new ProgramCodeGenerator();
            
            foreach (var arg in args)
            {
                var fileName = Path.GetFileNameWithoutExtension(arg);
                fileName = string.Join("", fileName.Split('_').Select(t => t.Substring(0, 1).ToUpper() + t.Substring(1)));
                var text = File.ReadAllText(arg);
                
                var outFile = Path.ChangeExtension(arg, "output");
                
                var inFile = Path.ChangeExtension(arg, "input");

                string input = null;
                string output = "";

                if (File.Exists(inFile))
                {
                    input = File.ReadAllText(inFile);
                    input = "@\"" + input + "\"";
                }
                else
                    input = "null";
                
                if (File.Exists(outFile))
                    output = File.ReadAllText(outFile);

                var programTree = new AstGenerator(text).GenerateAst();

                var code = codeGenerator.Visit(programTree);

                var comentedSource = string.Join("\n", text.Split('\n').Select(t => "// " + t));
                
                var str = @"using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;


// Author: ...
// Source: ...

" + comentedSource + @"

namespace TestPrograms.Good
{
    public class TestProgramProvider" + fileName + @" : ITestProgramProvider
    {
        public IProgram GetProgram()
        {
            return " + code + @";
        }

        public string GetOutput()
        {
            return @" + "\"" + output + "\"" + @";
        }

        public string GetInput()
        {
            return " + input + @";
        }
    }
}";
                
                File.WriteAllText(Path.ChangeExtension(arg, "cs"), str);
                
                Console.WriteLine(@"    public class " + fileName + @"Test : CompilerTestBase
    {
        [Test]
        public void Test" + fileName + @"()
        {
            TestProgram(new TestProgramProvider" + fileName + @"());
        }
    }");
            }
        }
    }
}