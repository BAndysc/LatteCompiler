namespace QuadruplesCommon
{
    public interface DirectValue
    {
        
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
    }
}