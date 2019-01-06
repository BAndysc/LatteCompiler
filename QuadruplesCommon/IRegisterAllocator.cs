using System.Collections.Generic;
using QuadruplesCommon;

namespace QuadruplesCommon
{
    public interface IRegisterAllocator<T>
    {
        IRegisterAllocation<T> AllocateRegisters(IList<QuadrupleBase> instrs);
    }
}