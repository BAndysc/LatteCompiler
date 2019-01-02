namespace QuadruplesCommon
{
    public class Label
    {
        private readonly string label;

        public Label(int l)
        {
            label = $"l{l}";
        }

        public Label(string l)
        {
            label = l;
        }

        public override string ToString()
        {
            return label;
        }
    }
}