using System;
namespace Backend.Linker
{
    public interface ILinker
    {
        ILinker AddObjectFile(string file);
        ILinker SetOutput(string file);
        ILinker WithStandardLibrary();
        void Link();
        void SetLibraryFolder(string path);
    }
}
