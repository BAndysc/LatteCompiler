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

        protected bool Equals(Memory32 other)
        {
            return Equals(Register, other.Register) && Equals(Label, other.Label) && Offset == other.Offset;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Memory32) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Register != null ? Register.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Offset;
                return hashCode;
            }
        }
    }
}