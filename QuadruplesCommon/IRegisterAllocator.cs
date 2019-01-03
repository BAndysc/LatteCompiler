using QuadruplesCommon;

namespace QuadruplesCommon
{
    public interface IRegisterAllocator
    {
        IRegisterAllocation AllocateRegisters(QuadruplesProgram program);
    }
}