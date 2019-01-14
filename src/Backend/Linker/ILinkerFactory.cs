using System;
namespace Backend.Linker
{
    public interface ILinkerFactory
    {
        ILinker CreateLinker();
    }
}
