using System;
using System.Diagnostics;

namespace Utils
{
    public class Runner : IRunner
    {
        public bool Run(string command, string arguments)
        {
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo();

                procStartInfo.FileName = command;
                procStartInfo.Arguments = arguments;
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;

                using (Process process = new Process())
                {
                    process.StartInfo = procStartInfo;
                    process.Start();

                    process.WaitForExit();

                    string result = process.StandardOutput.ReadToEnd();
                    Console.WriteLine(result);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("*** Error occured executing the following commands.");
                Console.WriteLine(command);
                Console.WriteLine(arguments);
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}