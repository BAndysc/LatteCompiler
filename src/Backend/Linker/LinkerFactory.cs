using System;
using Utils;

namespace Backend.Linker
{
    public class LinkerFactory : ILinkerFactory
    {
        private readonly IRunner runner;
        private readonly IOS os;

        public LinkerFactory(IRunner runner, IOS os)
        {
            this.runner = runner;
            this.os = os;
        }

        public ILinker CreateLinker()
        {
            if (os.IsLinux())
                return new LinuxLinker(runner);
            else if (os.IsOSX())
                return new DarwinLinker(runner);
            else if (os.IsWindows())
                return new WindowsLinker(runner);

            throw new Exception("Unsupported operating system!");
        }
    }
}
