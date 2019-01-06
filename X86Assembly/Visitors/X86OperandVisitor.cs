using X86Assembly.Operands;

namespace X86Assembly.Visitors
{
    public abstract class X86OperandVisitor<T>
    {
        public abstract T Visit(Register32 operand);
        public abstract T Visit(Register8 operand);
        public abstract T Visit(Memory32 operand);
        public abstract T Visit(ImmediateValue32 operand);
        
        public T Visit(IOperand operand)
        {
            return Visit((dynamic) operand);
        }
    }
}