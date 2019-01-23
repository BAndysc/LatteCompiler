using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Backend.Assembler
{
    public class WindowsNasm : Nasm
    {
        public WindowsNasm(IRunner runner) : base(runner, NasmTargets.Win32)
        {
        }

        public override IAssembler SetOutput(string file)
        {
            return base.SetOutput(file + ".obj");
        }

        internal override string GetDebugInfoParameters()
        {
            return "-gcv8";
        }
    }
}
