using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class SetEInstruction : IX86Instruction
    {
        public readonly Register8 Register;

        public SetEInstruction(Register8 register)
        {
            Register = register;
        }
    }
}