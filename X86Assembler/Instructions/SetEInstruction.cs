using X86Assembler.Operands;

namespace X86Assembler.Instructions
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