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
    }
}