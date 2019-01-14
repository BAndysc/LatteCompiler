using System;
using System.IO;
using LatteTypeChecker;
using NUnit.Framework;
using TestPrograms;
using Utils;

namespace Backend.Tests
{
    public abstract class CompilerTestBase
    {
        protected void TestProgram(ITestProgramProvider programProvider)
        {
            var tempFileCreator = new TempFileCreator();
            var runner = new Runner();
            Compiler compiler = new Compiler(tempFileCreator, runner, new OS(runner));

            var outputProgramFile = tempFileCreator.GetTempFile();
            string asmOut = tempFileCreator.GetTempFile();

            string programOutput;
            
            compiler.SetIntermediateOutput(null);
            compiler.SetAssemblyOutput(asmOut);
            compiler.SetOutput(outputProgramFile);
            
            var program = programProvider.GetProgram();
            
            var typeChecker = new StaticAnalysisChecker();

            typeChecker.Visit(program);
            
            compiler.Compile(program);

            string[] lines = null;
            if (programProvider.GetInput() != null)
                lines = programProvider.GetInput().Split('\n');
            
            runner.Run(outputProgramFile, "", out programOutput, lines);
            
            Assert.AreEqual(programProvider.GetOutput(), programOutput);
        }
    }
}