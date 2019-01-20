namespace X86Assembly.Operands
{
    public class Memory32 : IOperand, IMemory
    {
        public readonly Register32 Register;
        public readonly X86Label Label;
        public readonly int Offset;

        public Memory32(Register32 register, int offset)
        {
            this.Register = register;
            this.Offset = offset;
        }
        
        public Memory32(X86Label label, int offset)
        {
            this.Label = label;
            this.Offset = offset;
        }

        public int? ImplicitSize => null;
        
        public int Size => 4;
    }
}