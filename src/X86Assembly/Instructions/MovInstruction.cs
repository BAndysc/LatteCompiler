using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class MovInstruction : X86Instruction
    {
        public readonly IOperand From;
        public readonly IOperand To;

        public MovInstruction(Register32 to, Register32 from)
        {
            From = from;
            To = to;
        }

        public MovInstruction(Memory32 to, Register32 from)
        {
            From = from;
            To = to;
        }

        public MovInstruction(Register32 to, Memory32 from)
        {
            From = from;
            To = to;
        }
        
        public MovInstruction(Register32 to, ImmediateValue32 from)
        {
            From = from;
            To = to;
        }
        
        public MovInstruction(Memory32 to, ImmediateValue32 from)
        {
            From = from;
            To = to;
        }
    }
}