using System;
using System.Diagnostics;
using System.IO;
using Backend;
using Frontend;
using Utils;

namespace CLI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: ./cli [program] ");
                //Environment.Exit(-1);
                args = new string[] {"/Users/bartek/Programowanie/LatteCompiler/test2.lat"};
            }

            foreach (var arg in args)
            {
                if (!File.Exists(arg))
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine("File doesn't exist");
                    continue;
                }
                
                var text = File.ReadAllText(arg);

                Parser parser = new Parser();
                var runner = new Runner();
                Compiler compiler = new Compiler(new TempFileCreator(), runner, new OS(runner)); 

                var program = parser.Parse(Path.GetFileNameWithoutExtension(arg), text);

                var fileName = Path.GetFileNameWithoutExtension(arg);
                
                var baseDir = Path.GetDirectoryName(arg);

                if (!string.IsNullOrEmpty(baseDir))
                    baseDir = baseDir + "/";
                
                var outputAsmFile = baseDir + fileName + ".s";
                var outputFile = baseDir + fileName;
                var intermediate = baseDir + fileName + ".q";
                
                compiler.SetIntermediateOutput(intermediate);
                compiler.SetAssemblyOutput(outputAsmFile);
                compiler.SetOutput(outputFile);
                compiler.Compile(program);
            }
        }
    }
}