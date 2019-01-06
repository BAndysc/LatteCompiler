using X86Assembler.Operands;

namespace X86Assembler.Instructions
{
    public class SetGeInstruction : IX86Instruction
    {
        public readonly Register8 Register;

        public SetGeInstruction(Register8 register)
        {
            Register = register;
        }
    }
}