using X86Assembler.Operands;

namespace X86Assembler.Instructions
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