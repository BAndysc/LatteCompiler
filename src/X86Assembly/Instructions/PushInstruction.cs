using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class PushInstruction : X86Instruction
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