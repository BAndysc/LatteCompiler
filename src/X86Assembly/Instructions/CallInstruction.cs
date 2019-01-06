namespace X86Assembly.Instructions
{
    public class CallInstruction : IX86Instruction
    {
        public readonly X86Label Function;

        public CallInstruction(X86Label label)
        {
            Function = label;
        }
        
    }
}