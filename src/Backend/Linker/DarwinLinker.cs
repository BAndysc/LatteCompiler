using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Backend.Linker
{
    public class DarwinLinker : ILinker
    {
        private List<string> objectFiles;
        private string outputFile;
        private bool withStdLib;
        private string libraryPath;
        private readonly IRunner runner;

        public DarwinLinker(IRunner runner)
        {
            objectFiles = new List<string>();
            this.runner = runner;
        }

        public ILinker AddObjectFile(string file)
        {
            objectFiles.Add(file);
            return this;
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

        public void SetLibraryFolder(string path)
        {
            this.libraryPath = path;
        }

        public void Link()
        {
            string args = "-m32";

            if (withStdLib)
            {
                string sysroot = Environment.GetEnvironmentVariable("LATTE_OS_X_SDK");

                if (string.IsNullOrEmpty(sysroot))
                    throw new Exception("Set LATTE_OS_X_SDK environment path to 32-bit OS X SDK to build");

                args += $" -isysroot {sysroot}";

                var libs = new string[] { "runtime.o", "osx_layer.o" };
                objectFiles.AddRange(libs.Select(t => libraryPath + t));
            }

            if (outputFile != null)
                args += $" -o {outputFile}";

            args += " " + string.Join(" ", objectFiles);

            runner.Run("gcc", args, out var @o);

            objectFiles.Clear();
        }
    }
}
