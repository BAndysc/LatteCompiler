using System.Collections.Generic;
using QuadruplesCommon;

namespace QuadruplesGenerator.RegisterAllocators
{
    public class RegisterAllocation : IRegisterAllocation
    {
        private Dictionary<IRegister, INativeRegister> mapping;

        public RegisterAllocation()
        {
            mapping = new Dictionary<IRegister, INativeRegister>();
        }

        public INativeRegister Get(IRegister register)
        {
            return mapping[register];
        }

        public void AllocRegister(IRegister register, INativeRegister native)
        {
            mapping[register] = native;
        }

        public bool IsAllocated(IRegister required)
        {
            return mapping.ContainsKey(required);
        }
    }
}