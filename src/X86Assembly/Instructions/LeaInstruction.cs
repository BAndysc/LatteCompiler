using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class LeaInstruction : X86Instruction
    {
        public readonly IOperand From;
        public readonly IOperand To;

        public LeaInstruction(Register32 to, Register32 from)
        {
            From = from;
            To = to;
        }

        public LeaInstruction(Memory32 to, Register32 from)
        {
            From = from;
            To = to;
        }

        public LeaInstruction(Register32 to, Memory32 from)
        {
            From = from;
            To = to;
        }
        
        public LeaInstruction(Register32 to, ImmediateValue32 from)
        {
            From = from;
            To = to;
        }
        
        public LeaInstruction(Memory32 to, ImmediateValue32 from)
        {
            From = from;
            To = to;
        }
    }
}