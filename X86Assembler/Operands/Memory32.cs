namespace X86Assembler.Operands
{
    public class Memory32 : IOperand, IMemory
    {
        public readonly Register32 Register;
        public readonly int Offset;

        public Memory32(Register32 register, int offset)
        {
            this.Register = register;
            this.Offset = offset;
        }

        public int? ImplicitSize => null;
        
        public int Size => 4;
    }
}