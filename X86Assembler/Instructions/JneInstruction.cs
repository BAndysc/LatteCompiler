namespace X86Assembler.Instructions
{
    public class JneInstruction : IX86Instruction
    {
        public readonly X86Label Label;
        public JneInstruction(X86Label label)
        {
            Label = label;
        }
    }
}