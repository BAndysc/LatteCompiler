using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class SetNeInstruction : X86Instruction
    {
        public readonly Register8 Register;

        public SetNeInstruction(Register8 register)
        {
            Register = register;
        }
    }
}