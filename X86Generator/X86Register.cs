using QuadruplesCommon;

namespace X86Generator
{
    public class X86Register : INativeRegister
    {
        public readonly string Name;

        public X86Register(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
        
        public static INativeRegister EAX = new X86Register("EAX");
        public static INativeRegister ECX = new X86Register("ECX");
        public static INativeRegister EDX = new X86Register("EDX");
        public static INativeRegister EBX = new X86Register("EBX");
        public static INativeRegister EBP = new X86Register("EBP");
        public static INativeRegister ESP = new X86Register("ESP");
    }
}