using X86Assembler.Operands;

namespace X86Assembler.Instructions
{
    public class SubInstruction : IX86Instruction
    {
        public readonly IOperand From;
        public readonly IOperand Value;

        public SubInstruction(Register32 from, Register32 value)
        {
            From = from;
            Value = value;
        }

        public SubInstruction(Register32 from, Memory32 value)
        {
            From = from;
            Value = value;
        }

        public SubInstruction(Memory32 from, Register32 value)
        {
            From = from;
            Value = value;
        }
        
        public SubInstruction(Register32 from, ImmediateValue32  value)
        {
            From = from;
            Value = value;
        }
        
        public SubInstruction(Memory32 from, ImmediateValue32 value)
        {
            From = from;
            Value = value;
        }
    }
}