using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class MulInstruction : X86Instruction
    {
        public readonly IOperand Factor;
        
        public MulInstruction(Register32 factor)
        {
            Factor = factor;
        }

        public MulInstruction(Memory32 factor)
        {
            Factor = factor;
        }
    }
}