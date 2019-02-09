using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using QuadruplesCommon;
using QuadruplesCommon.Quadruples;

namespace QuadruplesGenerator.RegisterAllocators
{
    public class NaiveRegisterAllocator<T> : IRegisterAllocator<T>
    {
        private readonly IRegisterProvider<T> registerProvider;

        public NaiveRegisterAllocator(IRegisterProvider<T> registerProvider)
        {
            this.registerProvider = registerProvider;
        }
        
        public IRegisterAllocation<T> AllocateRegisters(IList<QuadrupleBase> instrs)
        {
            var x86Registers = new List<T>();
            var mapping = new RegisterAllocation<T>();
            
            
            var defining = new DefiningRegisterEvaluator();
            var required = new RequiredRegistersEvaluator();
            
            HashSet<IRegister> allregisters = new HashSet<IRegister>();
            
            Dictionary<IRegister, int> firstUsage = new Dictionary<IRegister, int>();
            Dictionary<IRegister, int> lastUsage = new Dictionary<IRegister, int>();

            HashSet<IRegister> consts = new HashSet<IRegister>();
            HashSet<IRegister> bannedConst = new HashSet<IRegister>();
            
            for (int i = 0; i < instrs.Count; ++i)
            {
                var instr = instrs[i];
                var def = defining.Visit(instr);
                if (def != null && !bannedConst.Contains(def))
                {
                    if (consts.Contains(def))
                    {
                        consts.Remove(def);
                        bannedConst.Add(def);
                    }
                    else
                        consts.Add(def);
                }
            }
            
            for(int i = 0; i < instrs.Count; ++i)
            {
                var instr = instrs[i];
                var def = defining.Visit(instr);
                var usng = required.Visit(instr);

                if (instrs[i] is ImmediateValueQuadruple && !bannedConst.Contains(def))
                {
                    ImmediateValueQuadruple immQuad = instrs[i] as ImmediateValueQuadruple;
                    mapping.SetConst(def, registerProvider.GetConstRegister(immQuad.Value.AsInt));
                    def = null;
                }
                else if (def != null && mapping.IsIntConst(def))
                    throw new Exception("Unsupported not SSA!");

                if (def != null)
                    usng.Add(def);
                
                foreach (var reg in usng)
                {
                    if (reg == null)
                        continue;
                    
                    if (mapping.IsIntConst(reg))
                        continue;
                    
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
            for (int i = 0; i < instrs.Count; ++i)
            {
                var instr = instrs[i];
                var def = defining.Visit(instr);
                var usng = required.Visit(instr);
                
                if (def != null)
                    usng.Add(def);

                foreach (var reg in usng)
                {
                    if (reg == null)
                        continue;
                    
                    if (mapping.IsIntConst(reg))
                        continue;
                    
                    if (i == firstUsage[reg])
                    {
                        if (x86Registers.Count == 0)
                            x86Registers.Add(registerProvider.GetNextFreeRegister());

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
            }

            return mapping;
        }
    }
}