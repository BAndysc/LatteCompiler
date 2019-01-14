using System;
using Utils;

namespace Backend.Assembler
{
    public class DarwinNasm : Nasm
    {
        public DarwinNasm(IRunner runner) : base(runner, NasmTargets.MachO)
        {
        }
    }
}
