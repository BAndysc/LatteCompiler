using System;
using Utils;

namespace Backend.Assembler
{
    public abstract class Nasm : IAssembler
    {
        private readonly IRunner runner;
        private readonly NasmTargets target;
        private string output;

        private bool withDebug;

        public Nasm(IRunner runner, NasmTargets target)
        {
            this.runner = runner;
            this.target = target;
        }

        public void Assembly(string sourceFile)
        {
            string args = $"-f {target.ToString().ToLower()}";
            args += " " + sourceFile;
            if (withDebug)
                args += " " + GetDebugInfoParameters();

            if (output != null)
                args += $" -o {output}";

            string res;
            runner.Run("nasm", args, out res);
            Console.WriteLine(res);
        }

        internal abstract string GetDebugInfoParameters();

        public virtual IAssembler SetOutput(string file)
        {
            output = file;
            return this;
        }

        public IAssembler WithDebugSymbols()
        {
            withDebug = true;
            return this;
        }
    }

    public enum NasmTargets
    {
        Elf32,
        MachO,
        Win32
    }
}
