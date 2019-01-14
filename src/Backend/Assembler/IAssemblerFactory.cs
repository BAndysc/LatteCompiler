using System;
namespace Backend.Assembler
{

    public interface IAssemblerFactory
    {
        IAssembler CreateAssembler();
    }

}
