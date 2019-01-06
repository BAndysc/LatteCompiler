namespace X86Assembler.Instructions
{
    public class JmpInstruction : IX86Instruction
    {
        public readonly X86Label Label;
        public JmpInstruction(X86Label label)
        {
            Label = label;
        }
    }
}