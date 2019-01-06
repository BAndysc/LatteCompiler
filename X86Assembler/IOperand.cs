namespace X86Assembler
{
    public interface IOperand
    {
        int? ImplicitSize { get; }
        int Size { get; }
    }
}