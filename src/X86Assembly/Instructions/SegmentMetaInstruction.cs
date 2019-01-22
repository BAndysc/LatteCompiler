namespace X86Assembly.Instructions
{
    public class SegmentMetaInstruction : IX86Instruction
    {
        public readonly string Name;

        public SegmentMetaInstruction(string name)
        {
            Name = name;
        }
    }
    
    public class ExternMetaInstruction : IX86Instruction
    {
        public readonly string Symbol;

        public ExternMetaInstruction(string symbol)
        {
            Symbol = symbol;
        }
    }
    
    public class GlobalMetaInstruction : IX86Instruction
    {
        public readonly string Symbol;

        public GlobalMetaInstruction(string symbol)
        {
            Symbol = symbol;
        }
    }
    
    public class DataMetaInstruction : IX86Instruction
    {
        public readonly string Key;
        public readonly string Text;
        public readonly int? ZeroBytes;

        public DataMetaInstruction(string key, string text)
        {
            Text = text;
            Key = key;
        }

        public DataMetaInstruction(string key, int zeroBytes)
        {
            ZeroBytes = zeroBytes;
            Key = key;
        }
    }
}