using System.Collections.Generic;
using QuadruplesCommon;

namespace QuadruplesGenerator.RegisterAllocators
{
    public class RegisterAllocation<T> : IRegisterAllocation<T>
    {
        private Dictionary<IRegister, T> mapping;

        public RegisterAllocation()
        {
            mapping = new Dictionary<IRegister, T>();
        }

        public T Get(IRegister register)
        {
            return mapping[register];
        }

        public void AllocRegister(IRegister register, T native)
        {
            mapping[register] = native;
        }

        public bool IsAllocated(IRegister required)
        {
            return mapping.ContainsKey(required);
        }

        public int MaxUsedRegisters { get; set;  }
    }
}