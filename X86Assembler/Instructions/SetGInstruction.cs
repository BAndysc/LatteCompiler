using X86Assembler.Operands;

namespace X86Assembler.Instructions
{
    public class SetGInstruction : IX86Instruction
    {
        public readonly Register8 Register;

        public SetGInstruction(Register8 register)
        {
            Register = register;
        }
    }
}