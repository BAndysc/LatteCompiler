using X86Assembly.Operands;

namespace X86Assembly.Instructions
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