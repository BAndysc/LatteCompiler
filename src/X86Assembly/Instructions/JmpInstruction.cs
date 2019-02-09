namespace X86Assembly.Instructions
{
    public class JmpInstruction : X86Instruction
    {
        public readonly X86Label Label;
        public JmpInstruction(X86Label label)
        {
            Label = label;
        }
    }
}