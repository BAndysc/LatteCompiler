using X86Assembly.Operands;
using X86Assembly.Visitors;

namespace X86IntelAsm
{
    internal class IntelAsmOperandTranslator : X86OperandVisitor<string>
    {
        public override string Visit(Register32 operand)
        {
            return operand.RegisterName;
        }

        public override string Visit(Register8 operand)
        {
            return operand.RegisterName;
        }

        public override string Visit(Memory32 operand)
        {
            return $"[{Visit(operand.Register)} + {operand.Offset}]";
        }

        public override string Visit(ImmediateValue32 operand)
        {
            return operand.ToString();
        }
    }
}