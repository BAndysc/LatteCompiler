using X86Assembler.Operands;

namespace X86Assembler.Instructions
{
    public class SetNeInstruction : IX86Instruction
    {
        public readonly Register8 Register;

        public SetNeInstruction(Register8 register)
        {
            Register = register;
        }
    }
}