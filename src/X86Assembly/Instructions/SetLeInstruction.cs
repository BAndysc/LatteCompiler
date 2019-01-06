using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class SetLeInstruction : IX86Instruction
    {
        public readonly Register8 Register;

        public SetLeInstruction(Register8 register)
        {
            Register = register;
        }
    }
}