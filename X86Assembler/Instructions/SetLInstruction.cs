using X86Assembler.Operands;

namespace X86Assembler.Instructions
{
    public class SetLInstruction : IX86Instruction
    {
        public readonly Register8 Register;

        public SetLInstruction(Register8 register)
        {
            Register = register;
        }
    }
}