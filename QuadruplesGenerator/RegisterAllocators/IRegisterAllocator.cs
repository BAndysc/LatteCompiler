using QuadruplesCommon;

namespace QuadruplesGenerator.RegisterAllocators
{
    public interface IRegisterAllocator
    {
        IRegisterAllocation AllocateRegisters(QuadruplesProgram program);
    }
}