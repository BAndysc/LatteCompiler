using System;
namespace Backend.Assembler
{
    public interface IAssembler
    {
        IAssembler SetOutput(string file);
        IAssembler WithDebugSymbols();
        void Assembly(string sourceFile);
    }
}
