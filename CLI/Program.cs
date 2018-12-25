using System;
using System.IO;
using Frontend;

namespace CLI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: ./cli [program] ");
                Environment.Exit(-1);
            }
            
            var text = File.ReadAllText(args[0]);
            
            Parser parser = new Parser();

            parser.Parse(text);
        }
    }
}