using System;
namespace Utils
{
    public class OS : IOS
    {
        private readonly IRunner runner;

        private readonly bool isUnix;
        private readonly bool isLinux;
        private readonly bool isOSX;

        public OS(IRunner runner)
        {
            this.runner = runner;
            int p = (int)Environment.OSVersion.Platform;

            if (p == 2 || p == 128)
            {
                isLinux = true;
                isUnix = true;
                isOSX = false;
            }
            else if (p == 4)
            {
                isUnix = true;
                runner.Run("uname", "", out var uname);
                isOSX = uname.Trim().ToLower() == "darwin";
                isLinux = !isOSX;
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
    }
}
