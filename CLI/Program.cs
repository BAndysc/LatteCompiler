using System;
using System.IO;
using Frontend;

namespace CLI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 0)
            {
                Console.WriteLine("Usage: ./cli [program] ");
                Environment.Exit(-1);
            }

            //foreach (var arg in args)
            {
                var text = File.ReadAllText("/home/bartek/RiderProjects/Latte/test.lat");
            
                Parser parser = new Parser();

                parser.Parse(Path.GetFileNameWithoutExtension("/home/bartek/RiderProjects/Latte/test.lat"), text);                
            }

        }
    }
}