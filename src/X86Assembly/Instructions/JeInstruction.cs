namespace X86Assembly.Instructions
{
    public class JeInstruction : X86Instruction
    {
        public readonly X86Label Label;

        public JeInstruction(X86Label label)
        {
            Label = label;
        }
    }
}