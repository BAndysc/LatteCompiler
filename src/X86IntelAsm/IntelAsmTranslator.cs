using System;
using X86Assembly;
using X86Assembly.Instructions;
using X86Assembly.Visitors;

namespace X86IntelAsm
{
    internal class SizeModifier
    {
        public string Visit(IOperand operand)
        {
            if (operand.ImplicitSize.HasValue)
                return "";

            switch (operand.Size)
            {
                case 1:
                    return "byte";
                case 2:
                    return "word";
                case 4:
                    return "dword";
                case 8:
                    return "qword";
                default:
                    throw new ArgumentException();
            }
        }
    }
    
    public class IntelAsmTranslator : X86Visitor<string>
    {
        private readonly bool withIndent;
        private IntelAsmOperandTranslator operandTranslator = new IntelAsmOperandTranslator();

        private SizeModifier sizeOf = new SizeModifier();
            
        public IntelAsmTranslator(bool withIndent)
        {
            this.withIndent = withIndent;
        }

        private string Indent(string str, bool noIdent = false)
        {
            str = str.Replace("  ", " ");
            if (withIndent && !noIdent)
                return "    " + str;
            return str;
        }
        
        public override string Visit(AddInstruction instr)
        {
            return Indent($"add {sizeOf.Visit(instr.Value)} {operandTranslator.Visit(instr.To)}, {operandTranslator.Visit(instr.Value)}");
        }

        public override string Visit(AndInstruction instr)
        {
            return Indent($"and {sizeOf.Visit(instr.With)} {operandTranslator.Visit(instr.What)}, {operandTranslator.Visit(instr.With)}");
        }

        public override string Visit(CallInstruction instr)
        {
            return Indent($"call {instr.Function.Label}");
        }

        public override string Visit(CdqInstruction instr)
        {
            return Indent("cdq");
        }

        public override string Visit(CompareInstruction instr)
        {
            return Indent($"cmp {sizeOf.Visit(instr.B)} {operandTranslator.Visit(instr.A)}, {operandTranslator.Visit(instr.B)}");
        }

        public override string Visit(JeInstruction instr)
        {
            return Indent($"je {instr.Label}");
        }

        public override string Visit(JmpInstruction instr)
        {
            return Indent($"jmp {instr.Label}");
        }

        public override string Visit(JneInstruction instr)
        {
            return Indent($"jne {instr.Label}");
        }

        public override string Visit(LeaveInstruction instr)
        {
            return Indent("leave");
        }

        public override string Visit(MovInstruction instr)
        {
            return Indent($"mov {sizeOf.Visit(instr.From)} {operandTranslator.Visit(instr.To)}, {operandTranslator.Visit(instr.From)}");
        }
        
        public override string Visit(LeaInstruction instr)
        {
            return Indent($"lea {sizeOf.Visit(instr.From)} {operandTranslator.Visit(instr.To)}, {operandTranslator.Visit(instr.From)}");
        }
        
        public override string Visit(MovzxInstruction instr)
        {
            return Indent($"movzx {operandTranslator.Visit(instr.To)}, {operandTranslator.Visit(instr.From)}");
        }

        public override string Visit(MulInstruction instr)
        {
            return Indent($"mul {sizeOf.Visit(instr.Factor)} {operandTranslator.Visit(instr.Factor)}");
        }

        public override string Visit(NegateInstruction instr)
        {
            return Indent($"neg  {sizeOf.Visit(instr.What)} {operandTranslator.Visit(instr.What)}");
        }

        public override string Visit(PushInstruction instr)
        {
            return Indent($"push  {sizeOf.Visit(instr.Source)} {operandTranslator.Visit(instr.Source)}");
        }

        public override string Visit(RetInstruction instr)
        {
            return Indent("ret");
        }

        public override string Visit(SetEInstruction instr)
        {
            return Indent($"sete {operandTranslator.Visit(instr.Register)}");
        }

        public override string Visit(SetGeInstruction instr)
        {
            return Indent($"setge {operandTranslator.Visit(instr.Register)}");
        }

        public override string Visit(SetGInstruction instr)
        {
            return Indent($"setg {operandTranslator.Visit(instr.Register)}");
        }

        public override string Visit(SetLeInstruction instr)
        {
            return Indent($"setle {operandTranslator.Visit(instr.Register)}");
        }

        public override string Visit(SetLInstruction instr)
        {
            return Indent($"setl {operandTranslator.Visit(instr.Register)}");
        }

        public override string Visit(SetNeInstruction instr)
        {
            return Indent($"setne {operandTranslator.Visit(instr.Register)}");
        }

        public override string Visit(SignedDivInstruction instr)
        {
            return Indent($"idiv {sizeOf.Visit(instr.Divisor)} {operandTranslator.Visit(instr.Divisor)}");
        }

        public override string Visit(SubInstruction instr)
        {
            return Indent($"sub  {sizeOf.Visit(instr.Value)} {operandTranslator.Visit(instr.From)}, {operandTranslator.Visit(instr.Value)}");
        }

        public override string Visit(LabelInstruction instr)
        {
            return Indent($"{instr.Label.Label}:", true);
        }
    }
}