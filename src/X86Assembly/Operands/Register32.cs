namespace X86Assembly.Operands
{
    public class Register32: IOperand, IRegister
    {
        public readonly string RegisterName;
        
        public static Register32 EAX = new Register32("EAX");
        public static Register32 EBX = new Register32("EBX");
        public static Register32 ECX = new Register32("ECX");
        public static Register32 EDX = new Register32("EDX");
        public static Register32 EBP = new Register32("EBP");
        public static Register32 ESP = new Register32("ESP");

        public Register32(string registerName)
        {
            RegisterName = registerName;
        }

        public int? ImplicitSize => 4;
        
        public int Size => 4;
    }
}