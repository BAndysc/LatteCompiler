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
        
        public IRegisterAllocation AllocateRegisters(IList<QuadrupleBase> instrs)
        {
            var x86Registers = new List<INativeRegister>(nativeRegisters);
            var mapping = new RegisterAllocation();
            
            
            var defining = new DefiningRegisterEvaluator();
            var required = new RequiredRegistersEvaluator();
            
            HashSet<IRegister> allregisters = new HashSet<IRegister>();
            
            Dictionary<IRegister, int> firstUsage = new Dictionary<IRegister, int>();
            Dictionary<IRegister, int> lastUsage = new Dictionary<IRegister, int>();
            
            for(int i = 0; i < instrs.Count; ++i)
            {
                var instr = instrs[i];
                var def = defining.Visit(instr);
                var usng = required.Visit(instr);

                if (def != null)
                    usng.Add(def);

                foreach (var reg in usng)
                {
                    allregisters.Add(reg);
                    if (firstUsage.ContainsKey(reg))
                        firstUsage[reg] = Math.Min(i, firstUsage[reg]);
                    else
                        firstUsage[reg] = i;
                
                
                    if (lastUsage.ContainsKey(reg))
                        lastUsage[reg] = Math.Max(i, lastUsage[reg]);
                    else
                        lastUsage[reg] = i;       
                }
            }

            int used = 0;
            mapping.MaxUsedRegisters = 0;
            for (int i = 0; i < instrs.Count; ++i)
            {
                var instr = instrs[i];
                var def = defining.Visit(instr);
                var usng = required.Visit(instr);
                
                if (def != null)
                    usng.Add(def);

                foreach (var reg in usng)
                {
                    if (i == firstUsage[reg])
                    {
                        var native = x86Registers[x86Registers.Count - 1];
                        x86Registers.RemoveAt(x86Registers.Count - 1);
                        mapping.AllocRegister(reg, native);
                        used++;
                    }

                    if (i == lastUsage[reg])
                    {
                        x86Registers.Add(mapping.Get(reg));
                        used--;
                    }
                }

                mapping.MaxUsedRegisters = Math.Max(mapping.MaxUsedRegisters, used);
            }

            return mapping;
        }
    }
}