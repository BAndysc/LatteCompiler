namespace X86Assembly
{
    public interface IOperand
    {
        int? ImplicitSize { get; }
        int Size { get; }
    }
}