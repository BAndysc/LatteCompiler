using QuadruplesCommon;

namespace QuadruplesCommon
{
    public interface IRegisterAllocation
    {
        INativeRegister Get(IRegister register);
        void AllocRegister(IRegister register, INativeRegister nativeRegister);
        bool IsAllocated(IRegister required);
        int MaxUsedRegisters { get; set; }
    }
}