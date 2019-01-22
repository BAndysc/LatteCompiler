using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Backend.Linker
{
    public class WindowsLinker : ILinker
    {
        private readonly IRunner runner;

        private List<string> objectFiles;
        private string outputFile;
        private bool withStdLib;
        private string libraryPath;

        public WindowsLinker(IRunner runner)
        {
            objectFiles = new List<string>();
            this.runner = runner;
        }

        public ILinker AddObjectFile(string file)
        {
            objectFiles.Add(file);
            return this;
        }

        public void Link()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LIB")) ||
                string.IsNullOrEmpty(Environment.GetEnvironmentVariable("INCLUDE")))
            {
                throw new Exception("Environment variables LIB and INCLUDE are not set, cl.exe cannot work without them.\n" +
                                    "Please run `Developer Command Prompt For Visual Studio`, then run following commands:\n" +
                                    " $ echo %LIB%\n" +
                                    " $ echo %INCLUDE%\n" +
                                    "and add those variables to your environment variables");
            }
            
            if (withStdLib)
            {
                objectFiles.Add(libraryPath + @"\runtime.obj");
                objectFiles.Add(libraryPath + @"\osx_layer.obj");
            }

            string args = string.Join(" ", objectFiles);

            if (outputFile != null)
                args += " /Fe" + outputFile;

            string stdOut;
            runner.Run("cl", args, out stdOut);

            objectFiles.Clear();
            Console.WriteLine(stdOut);
        }

        public void SetLibraryFolder(string path)
        {
            libraryPath = path.Replace("/", "\\");
        }

        public ILinker SetOutput(string file)
        {
            outputFile = file;
            return this;
        }

        public ILinker WithStandardLibrary()
        {
            withStdLib = true;
            return this;
        }
    }
}
