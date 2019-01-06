namespace QuadruplesCommon
{
    public interface DirectValue
    {
        int AsInt { get; }
    }

    public class DirectIntValue : DirectValue
    {
        public readonly int Value;

        public DirectIntValue(int value)
        {
            Value = value;
        }
        
        public override string ToString()
        {
            return $"{Value}";
        }

        public int AsInt => Value;
    }

    public class DirectBoolValue : DirectValue
    {
        public readonly bool Value;

        public DirectBoolValue(bool value)
        {
            Value = value;
        }
        
        public override string ToString()
        {
            if (Value)
                return "1";
            return "0";
        }

        public int AsInt => Value ? 1 : 0;
    }
}