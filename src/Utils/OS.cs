using System;
namespace Utils
{
    public class OS : IOS
    {
        private readonly IRunner runner;

        private readonly bool isUnix;
        private readonly bool isLinux;
        private readonly bool isOSX;
        private readonly bool isWindows;

        public OS(IRunner runner)
        {
            this.runner = runner;
            int p = (int)Environment.OSVersion.Platform;

            if (p == 2)
            {
                isWindows = true;
                isLinux = false;
                isUnix = false;
                isOSX = false;
            }
            else if (p == 128)
            {
                isLinux = true;
                isUnix = true;
                isOSX = false;
                isWindows = false;
            }
            else if (p == 4)
            {
                isUnix = true;
                string uname;
                runner.Run("uname", "", out uname);
                isOSX = uname.Trim().ToLower() == "darwin";
                isLinux = !isOSX;
                isWindows = false;
            }
        }

        public bool IsLinux()
        {
            return isLinux;
        }

        public bool IsOSX()
        {
            return isOSX;
        }

        public bool IsWindows()
        {
            return isWindows;
        }
    }
}
