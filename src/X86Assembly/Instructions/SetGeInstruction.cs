using X86Assembly.Operands;

namespace X86Assembly.Instructions
{
    public class SetGeInstruction : X86Instruction
    {
        public readonly Register8 Register;

        public SetGeInstruction(Register8 register)
        {
            Register = register;
        }
    }
}