using QuadruplesCommon;

namespace QuadruplesGenerator.RegisterAllocators
{
    public interface IRegisterAllocation
    {
        INativeRegister Get(IRegister register);
        void AllocRegister(IRegister register, INativeRegister nativeRegister);
        bool IsAllocated(IRegister required);
    }
}