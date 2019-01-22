using System;
using Utils;

namespace Backend.Assembler
{
    public class AssemblerFactory : IAssemblerFactory
    {
        private readonly IRunner runner;
        private readonly IOS os;

        public AssemblerFactory(IRunner runner, IOS os)
        {
            this.runner = runner;
            this.os = os;
        }

        public IAssembler CreateAssembler()
        {
            if (os.IsLinux())
                return new LinuxNasm(runner);
            else if (os.IsOSX())
                return new DarwinNasm(runner);
            else if (os.IsWindows())
                return new WindowsNasm(runner);
            throw new Exception("Unsupported OS!");
        }
    }
}
