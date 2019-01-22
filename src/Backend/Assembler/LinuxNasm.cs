using System;
using Utils;

namespace Backend.Assembler
{
    public class LinuxNasm : Nasm
    {
        public LinuxNasm(IRunner runner) : base(runner, NasmTargets.Elf32)
        {
        }

        internal override string GetDebugInfoParameters()
        {
            return "-g -F dwarf";
        }
    }
}
