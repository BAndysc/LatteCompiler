using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class MulInstruction : IX86Instruction
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