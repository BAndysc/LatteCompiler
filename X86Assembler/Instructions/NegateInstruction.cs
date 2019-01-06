using X86Assembler.Operands;

namespace X86Assembler.Instructions
{
    public class NegateInstruction : IX86Instruction
    {
        public readonly IOperand What;
        
        public NegateInstruction(Register32 register)
        {
            What = register;
        }

        public NegateInstruction(Memory32 memory)
        {
            What = memory;
        }
    }
}