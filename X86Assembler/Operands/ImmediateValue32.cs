namespace X86Assembler.Operands
{
    public class ImmediateValue32 : IOperand, IImmediate
    {
        public readonly int? Value;
        public readonly X86Label Label;
        
        public ImmediateValue32(X86Label value)
        {
            Value = null;
            Label = value;
        }
        
        public ImmediateValue32(int value)
        {
            Label = null;
            Value = value;
        }

        public override string ToString()
        {
            return Value.HasValue ? Value.Value.ToString() : Label.Label;
        }

        public int? ImplicitSize => null;
        
        public int Size => 4;
    }
}