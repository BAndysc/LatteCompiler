using System;
using System.IO;
using System.Linq;
using System.Text;
using LatteBase.AST;
using LatteTreeOptimizer;
using QuadruplesGenerator;
using Utils;
using X86Generator;

namespace Backend
{
    public class Compiler
    {
        private readonly ITempFileCreator tempFileCreator;
        private readonly IRunner runner;
        private string intermediateOutputFile;
        private string outputAsm;
        private string outputBinary;
        private string runtimeObject;

        public Compiler(ITempFileCreator tempFileCreator, IRunner runner)
        {
            this.tempFileCreator = tempFileCreator;
            this.runner = runner;

            var libDir = AppDomain.CurrentDomain.BaseDirectory + "/../lib/";

            var libs = new string[] {"runtime.o", "libc.a", "crt1.o", "crti.o", "crtn.o"};
            
            runtimeObject = string.Join(" ", libs.Select(t => libDir + t));
        }
        
        
        public void Compile(IProgram program)
        {
            var treeOptimizer = new TreeOptimizer();
            
            var quadProgram = new Generator().Visit(treeOptimizer.Visit(program));

            if (intermediateOutputFile != null)
            {
                File.WriteAllText(intermediateOutputFile, string.Join("\n", quadProgram.Functions.SelectMany(f => f.Instructions).Select(q => $"{q,-40} ; {q.FilePlace.Text.Split('\n').FirstOrDefault()}")));
            }
            
            X86Compiler compiler = new X86Compiler();
            var asm = compiler.Compile(quadProgram);
            
            var outputObjectFile = tempFileCreator.GetTempFile();
            
            File.WriteAllText(outputAsm, asm);

            runner.Run("nasm", $"-f elf32 -g -F dwarf  {outputAsm} -o {outputObjectFile}");

            runner.Run("ld", $"-o {outputBinary} -melf_i386 {outputObjectFile} {runtimeObject}");
        }

        public void SetIntermediateOutput(string intermediateOutput)
        {
            intermediateOutputFile = intermediateOutput;
        }
        
        public void SetAssemblyOutput(string outputAsmFile)
        {
            outputAsm = outputAsmFile;
        }

        public void SetOutput(string outputFile)
        {
            outputBinary = outputFile;
        }
    }
}