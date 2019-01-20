using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class CallInstruction : IX86Instruction
    {
        public readonly X86Label Function;
        public readonly Register32 Register;

        public CallInstruction(X86Label label)
        {
            Function = label;
        }
        
        public CallInstruction(Register32 register)
        {
            Register = register;
        }
        
    }
}