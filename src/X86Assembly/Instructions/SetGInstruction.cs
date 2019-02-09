using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class SetGInstruction : X86Instruction
    {
        public readonly Register8 Register;

        public SetGInstruction(Register8 register)
        {
            Register = register;
        }
    }
}