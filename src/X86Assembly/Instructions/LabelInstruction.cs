namespace X86Assembly.Instructions
{
    public class LabelInstruction : IX86Instruction
    {
        public readonly X86Label Label;

        public LabelInstruction(X86Label label)
        {
            Label = label;
        }
    }
}