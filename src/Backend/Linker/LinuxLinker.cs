using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Backend.Linker
{
    public class LinuxLinker : ILinker
    {
        private List<string> objectFiles;
        private string outputFile;
        private bool withStdLib;
        private string libraryPath;
        private readonly IRunner runner;

        public LinuxLinker(IRunner runner)
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

        public void Link()
        {
            string args = "-melf_i386";

            if (withStdLib)
            {
                var libs = new string[] { "runtime.o", "libc.a", "crt1.o", "crti.o" };
                objectFiles.AddRange(libs.Select(t => libraryPath + t));
            }

            if (outputFile != null)
                args += $" -o {outputFile}";

            args += " " + string.Join(" ", objectFiles);

            runner.Run("ld", args, out var @o);

            objectFiles.Clear();
        }

        public void SetLibraryFolder(string path)
        {
            this.libraryPath = path;
        }
    }
}
