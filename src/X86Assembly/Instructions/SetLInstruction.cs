using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class SetLInstruction : X86Instruction
    {
        public readonly Register8 Register;

        public SetLInstruction(Register8 register)
        {
            Register = register;
        }
    }
}