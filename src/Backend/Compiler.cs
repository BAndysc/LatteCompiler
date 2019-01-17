using System;
using System.IO;
using System.Linq;
using System.Text;
using Backend.Assembler;
using Backend.Linker;
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
        private readonly IOS os;
        private string intermediateOutputFile;
        private string outputAsm;

        private IAssembler assembler;
        private ILinker linker;

        public Compiler(ITempFileCreator tempFileCreator, IRunner runner, IOS os)
        {
            this.tempFileCreator = tempFileCreator;
            this.runner = runner;
            this.os = os;

            assembler = new AssemblerFactory(runner, os).CreateAssembler();
            linker = new LinkerFactory(runner, os).CreateLinker();

            linker.SetLibraryFolder(AppDomain.CurrentDomain.BaseDirectory + "/../lib/");
        }
        
        
        public void Compile(IProgram program)
        {
            var treeOptimizer = new TreeOptimizer();
            
            var quadProgram = new Generator().Visit(treeOptimizer.Visit(program));

            if (intermediateOutputFile != null)
            {
                var content = "";
                content += "#classes:\n";
                content += string.Join("\n", quadProgram.Classes);
                content += "\n#methods:\n";
                content += string.Join("\n",
                    quadProgram.Functions.SelectMany(f => f.Instructions).Select(q =>
                        $"{q,-40} ; {q.FilePlace.Text.Split('\n').FirstOrDefault()}"));
                File.WriteAllText(intermediateOutputFile, content);
            }
            
            X86Compiler compiler = new X86Compiler();
            var asm = compiler.Compile(quadProgram);
            
            var outputObjectFile = tempFileCreator.GetTempFile();
            
            File.WriteAllText(outputAsm, asm);

            assembler.WithDebugSymbols().SetOutput(outputObjectFile).Assembly(outputAsm);

            linker.WithStandardLibrary().AddObjectFile(outputObjectFile).Link();
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
            linker.SetOutput(outputFile);
        }
    }
}