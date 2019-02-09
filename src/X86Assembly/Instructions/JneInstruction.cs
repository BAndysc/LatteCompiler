namespace X86Assembly.Instructions
{
    public class JneInstruction : X86Instruction
    {
        public readonly X86Label Label;
        public JneInstruction(X86Label label)
        {
            Label = label;
        }
    }
}