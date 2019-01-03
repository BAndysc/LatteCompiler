using System;
using System.IO;
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
            
            runtimeObject = AppDomain.CurrentDomain.BaseDirectory + "/../lib/runtime.o";
        }
        
        
        public void Compile(IProgram program)
        {
            var treeOptimizer = new TreeOptimizer();
            
            var quadProgram = new Generator().Visit(treeOptimizer.Visit(program));

            if (intermediateOutputFile != null)
            {
                File.WriteAllText(intermediateOutputFile, string.Join("\n", quadProgram));
            }
            
            X86Compiler compiler = new X86Compiler();
            var asm = compiler.Compile(quadProgram);
            
            var outputObjectFile = tempFileCreator.GetTempFile();
            
            File.WriteAllText(outputAsm, asm);

            runner.Run("nasm", $"-f elf32 -g -F dwarf  {outputAsm} -o {outputObjectFile}");

            runner.Run("gcc", $"-m32 {outputObjectFile} {runtimeObject} -o {outputBinary}");
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