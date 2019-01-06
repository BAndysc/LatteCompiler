namespace QuadruplesCommon
{
    public class Label
    {
        public readonly string Text;

        public Label(int l)
        {
            Text = $"l{l}";
        }

        public Label(string l)
        {
            Text = l;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}