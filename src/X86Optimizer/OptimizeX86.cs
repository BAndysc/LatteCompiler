using System.Collections.Generic;
using X86Assembly;
using X86Assembly.Instructions;
using X86Assembly.Operands;

namespace X86Optimizer
{
    public class OptimizeX86
    {
        public IList<IX86Instruction> Optimize(IEnumerable<IX86Instruction> instrs)
        {
            IList<IX86Instruction> newInstrs = new List<IX86Instruction>();

            IX86Instruction prev = null;

            foreach (var instr in instrs)
            {
                if (prev == null || !Optimize(prev, instr))
                {
                    newInstrs.Add(instr);
                }

                prev = instr;
            }

            return newInstrs;
        }

        private bool Optimize(IX86Instruction prev, IX86Instruction current, bool dynamicCall = false)
        {
            if (dynamicCall)
                return false;
            
            return Optimize((dynamic) prev, (dynamic) current, true);
        }

        private bool Optimize(MovInstruction prev, MovInstruction current, bool dynamicCall)
        {
            return Equals(prev.To, current.From) && Equals(prev.From, current.To);
        }
    }
}