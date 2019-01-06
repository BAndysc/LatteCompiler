using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class CompareInstruction : IX86Instruction
    {
        public readonly IOperand A;
        public readonly IOperand B;
        
        public CompareInstruction(Register32 a, Register32 b)
        {
            A = a;
            B = b;
        }
        
        public CompareInstruction(Register32 a, Memory32 b)
        {
            A = a;
            B = b;
        }
        
        public CompareInstruction(Memory32 a, Register32 b)
        {
            A = a;
            B = b;
        }
        
        public CompareInstruction(Memory32 a, ImmediateValue32 b)
        {
            A = a;
            B = b;
        }
        public CompareInstruction(Register32 a, ImmediateValue32 b)
        {
            A = a;
            B = b;
        }
    }
}