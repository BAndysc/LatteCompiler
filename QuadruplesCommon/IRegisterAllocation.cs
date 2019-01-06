using QuadruplesCommon;

namespace QuadruplesCommon
{
    public interface IRegisterAllocation<T>
    {
        T Get(IRegister register);
        void AllocRegister(IRegister register, T nativeRegister);
        bool IsAllocated(IRegister required);
        int MaxUsedRegisters { get; set; }
    }
}