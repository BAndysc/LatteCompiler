namespace QuadruplesCommon
{
    public class Register : IRegister
    {
        private readonly int registerNumber;

        public Register(int registerNumber)
        {
            this.registerNumber = registerNumber;
        }

        public override string ToString()
        {
            return $"r{registerNumber}";
        }

        protected bool Equals(Register other)
        {
            return registerNumber == other.registerNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Register) obj);
        }

        public override int GetHashCode()
        {
            return registerNumber;
        }
    }
}