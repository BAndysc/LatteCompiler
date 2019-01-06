using X86Assembler.Operands;

namespace X86Assembler.Instructions
{
    public class SignedDivInstruction : IX86Instruction
    {
        public readonly IOperand Divisor;
        
        public SignedDivInstruction(Register32 register)
        {
            Divisor = register;
        }

        public SignedDivInstruction(Memory32 memory)
        {
            Divisor = memory;
        }
    }
}