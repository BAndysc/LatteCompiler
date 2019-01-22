namespace X86Assembly.Operands
{
    public class Register8 : IOperand, IRegister
    {
        public readonly string RegisterName;
        
        public static Register8 AL = new Register8("AL");
        public static Register8 AH = new Register8("AH");
        
        public static Register8 CL = new Register8("CL");
        public static Register8 CH = new Register8("CH");

        public Register8(string registerName)
        {
            RegisterName = registerName;
        }
        
        public int? ImplicitSize => 1;
        
        public int Size => 1;

        protected bool Equals(Register8 other)
        {
            return string.Equals(RegisterName, other.RegisterName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Register8) obj);
        }

        public override int GetHashCode()
        {
            return (RegisterName != null ? RegisterName.GetHashCode() : 0);
        }
    }
}