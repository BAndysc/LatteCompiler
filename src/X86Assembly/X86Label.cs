namespace X86Assembly
{
    public class X86Label
    {
        public readonly string Label;

        public X86Label(string label)
        {
            Label = label;
        }

        public override string ToString()
        {
            return Label;
        }

        protected bool Equals(X86Label other)
        {
            return string.Equals(Label, other.Label);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((X86Label) obj);
        }

        public override int GetHashCode()
        {
            return (Label != null ? Label.GetHashCode() : 0);
        }
    }
}