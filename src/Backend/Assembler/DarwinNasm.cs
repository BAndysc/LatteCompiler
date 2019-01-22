using System;
using Utils;

namespace Backend.Assembler
{
    public class DarwinNasm : Nasm
    {
        public DarwinNasm(IRunner runner) : base(runner, NasmTargets.MachO)
        {
        }

        internal override string GetDebugInfoParameters()
        {
            return "-g -F dwarf";
        }
    }
}
