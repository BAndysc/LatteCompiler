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
                Environment.Exit(-1);
            }

            foreach (var arg in args)
            {
                var text = File.ReadAllText(arg);

                Parser parser = new Parser();
                Compiler compiler = new Compiler(new TempFileCreator(), new Runner()); 

                var program = parser.Parse(Path.GetFileNameWithoutExtension(arg), text);

                var fileName = Path.GetFileNameWithoutExtension(arg);
                
                var baseDir = Path.GetDirectoryName(arg);

                if (!string.IsNullOrEmpty(baseDir))
                    baseDir = baseDir + "/";
                
                var outputAsmFile = baseDir + fileName + ".s";
                var outputFile = baseDir + fileName;
                var intermediate = baseDir + fileName + ".q";
                
                //compiler.SetIntermediateOutput(intermediate);
                compiler.SetAssemblyOutput(outputAsmFile);
                compiler.SetOutput(outputFile);
                compiler.Compile(program);
            }
        }
    }
}