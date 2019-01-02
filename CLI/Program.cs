using System;
using System.Collections.Generic;
using System.IO;
using Frontend;
using LatteTreeOptimizer;
using QuadruplesGenerator;
using QuadruplesGenerator.RegisterAllocators;

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

                var program = parser.Parse(Path.GetFileNameWithoutExtension(arg), text);

                var treeOptimizer = new TreeOptimizer();

                var allocator = new NaiveRegisterAllocator();
                allocator.AddRegisterToPool(X86Register.EAX);
                allocator.AddRegisterToPool(X86Register.ECX);
                allocator.AddRegisterToPool(X86Register.EBX);
                allocator.AddRegisterToPool(X86Register.EDX);

                var gen = new Generator().Visit(treeOptimizer.Visit(program));
                
                foreach (var quad in gen.Program)
                {
                  //  Console.WriteLine(quad);
                }

                var regs = allocator.AllocateRegisters(gen);

                var generator= new X86Generator(regs);

                if (gen.ConstStrings.Count > 0)
                {
                    Console.WriteLine("segment .data");
                    foreach (var str in gen.ConstStrings)
                    {
                        Console.WriteLine($"    {str.Key}: db {str.Value}, 0");
                    }
                }
                
                Console.WriteLine("segment .text");
                Console.WriteLine("    global main");
                Console.WriteLine("    extern printInt");
                Console.WriteLine("    extern printString");
                Console.WriteLine("    extern error");
                Console.WriteLine("    extern readInt");
                Console.WriteLine("    extern readString");
                foreach (var quad in gen.Program)
                {
                    generator.Visit(quad);
                }
            }
        }
    }
}