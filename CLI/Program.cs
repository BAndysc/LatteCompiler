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

                Console.WriteLine($"Compiling {arg}");
                
                var program = parser.Parse(Path.GetFileNameWithoutExtension(arg), text);
                
                var outputAsmFile = Path.GetDirectoryName(arg) + "/" + Path.GetFileNameWithoutExtension(arg) + ".s";
                var outputFile = Path.GetDirectoryName(arg) + "/" + Path.GetFileNameWithoutExtension(arg);

                var intermediate = Path.GetDirectoryName(arg) + "/" + Path.GetFileNameWithoutExtension(arg) + ".q";
                
                compiler.SetIntermediateOutput(intermediate);
                compiler.SetAssemblyOutput(outputAsmFile);
                compiler.SetOutput(outputFile);
                compiler.Compile(program);
            }
        }
    }
}