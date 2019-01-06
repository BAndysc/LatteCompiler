using X86Assembler.Operands;

namespace X86Assembler.Instructions
{
    public class MovzxInstruction : IX86Instruction
    {
        public readonly Register32 To;
        public readonly Register8 From;
        
        public MovzxInstruction(Register32 to, Register8 from)
        {
            To = to;
            From = from;
        }
    }
}