using System;
using System.Diagnostics;

namespace Utils
{
    public class Runner : IRunner
    {
        public bool Run(string command, string arguments, out string standardOut, string[] inputs = null)
        {
            Console.WriteLine("running " + command + " " + arguments);
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo();

                procStartInfo.FileName = command;
                procStartInfo.Arguments = arguments;
                procStartInfo.RedirectStandardInput = true;
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                using (Process process = new Process())
                {
                    process.StartInfo = procStartInfo;
                    process.Start();
                    if (inputs != null)
                    {
                        foreach (var line in inputs)
                            process.StandardInput.WriteLine(line);                        
                    }
                    
                    process.WaitForExit();

                    standardOut = process.StandardOutput.ReadToEnd();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("*** Error occured executing the following commands.");
                Console.WriteLine(command);
                Console.WriteLine(arguments);
                Console.WriteLine(ex.Message);
                standardOut = null;
                return false;
            }
        }
    }
}