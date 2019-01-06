using System.Collections.Generic;
using QuadruplesCommon;

namespace QuadruplesCommon
{
    public interface IRegisterAllocator
    {
        IRegisterAllocation AllocateRegisters(IList<QuadrupleBase> instrs);
    }
}