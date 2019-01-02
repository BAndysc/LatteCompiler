using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using QuadruplesCommon;

namespace QuadruplesGenerator.RegisterAllocators
{
    public class NaiveRegisterAllocator : IRegisterAllocator
    {
        private List<INativeRegister> nativeRegisters = new List<INativeRegister>();
        
        public void AddRegisterToPool(INativeRegister register)
        {
            nativeRegisters.Add(register);
        }
        
        public IRegisterAllocation AllocateRegisters(QuadruplesProgram program)
        {
            var x86Registers = new List<INativeRegister>(nativeRegisters); //{"EAX", "EDX", "ECX", "EBX"};//, "EBX", "EDI", "ESI"};
            var mapping = new RegisterAllocation();
            var currentUsedRegisters = new HashSet<IRegister>();
            int maxUsed = 0;
            for (int i = program.Program.Count - 1; i >= 0; --i)
            {
                var quad = program.Program[i];
                var definingRegister = new DefiningRegisterEvaluator().Visit(quad);
                var usedRegisters = new RequiredRegistersEvaluator().Visit(quad);

                foreach (var required in usedRegisters)
                {
                    if (!mapping.IsAllocated(required))
                    {
                        if (x86Registers.Count == 0)
                            throw new OutOfMemoryException();
                        mapping.AllocRegister(required, x86Registers[0]);
                        x86Registers.RemoveAt(0);
                    }
                    currentUsedRegisters.Add(required);
                }

                if (definingRegister != null && mapping.IsAllocated(definingRegister))
                {
                    x86Registers.Add(mapping.Get(definingRegister));
                    currentUsedRegisters.Remove(definingRegister);
                }

                maxUsed = Math.Max(maxUsed, currentUsedRegisters.Count);
            }

            return mapping;
        }
    }
}