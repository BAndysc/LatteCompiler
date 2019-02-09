using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class SignedDivInstruction : X86Instruction
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