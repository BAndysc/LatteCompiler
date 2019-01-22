namespace X86Assembly.Operands
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

        protected bool Equals(ImmediateValue32 other)
        {
            return Value == other.Value && Equals(Label, other.Label);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ImmediateValue32) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ (Label != null ? Label.GetHashCode() : 0);
            }
        }
    }
}