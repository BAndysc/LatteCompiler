using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class AndInstruction : X86Instruction
    {
        public readonly IOperand What;
        public readonly IOperand With;

        public AndInstruction(Register32 what, Register32 with)
        {
            What = what;
            With = with;
        }

        public AndInstruction(Register32 what, Memory32 with)
        {
            What = what;
            With = with;
        }

        public AndInstruction(Memory32 what, Register32 with)
        {
            What = what;
            With = with;
        }
        
        public AndInstruction(Register32 what, ImmediateValue32  with)
        {
            What = what;
            With = with;
        }
        
        public AndInstruction(Memory32 what, ImmediateValue32 with)
        {
            What = what;
            With = with;
        }
    }
}