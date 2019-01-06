using X86Assembler.Operands;

namespace X86Assembler.Instructions
{
    public class PushInstruction : IX86Instruction
    {
        public readonly IOperand Source;

        public PushInstruction(Register32 source)
        {
            Source = source;
        }
        
        public PushInstruction(Memory32 source)
        {
            Source = source;
        }
        
        public PushInstruction(ImmediateValue32 source)
        {
            Source = source;
        }
    }
}