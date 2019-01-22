using System;
using System.Collections.Generic;
using QuadruplesCommon;

namespace QuadruplesGenerator.RegisterAllocators
{
    public class RegisterAllocation<T> : IRegisterAllocation<T>
    {
        private Dictionary<IRegister, T> mapping;
        private Dictionary<IRegister, T> consts;

        public RegisterAllocation()
        {
            consts = new Dictionary<IRegister, T>();
            mapping = new Dictionary<IRegister, T>();
        }

        public T Get(IRegister register)
        {
            if (consts.ContainsKey(register))
                return consts[register];
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

        public bool IsIntConst(IRegister register)
        {
            return consts.ContainsKey(register);
        }

        public void SetConst(IRegister reg, T value)
        {
            consts[reg] = value;
        }
    }
}