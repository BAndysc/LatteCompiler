using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class AddInstruction : X86Instruction
    {
        public readonly IOperand To;
        public readonly IOperand Value;

        public AddInstruction(Register32 to, Register32 value)
        {
            To = to;
            Value = value;
        }

        public AddInstruction(Register32 to, Memory32 value)
        {
            To = to;
            Value = value;
        }

        public AddInstruction(Memory32 to, Register32 value)
        {
            To = to;
            Value = value;
        }
        
        public AddInstruction(Register32 to, ImmediateValue32  value)
        {
            To = to;
            Value = value;
        }
        
        public AddInstruction(Memory32 to, ImmediateValue32 value)
        {
            To = to;
            Value = value;
        }
    }
}