using X86Assembly.Instructions;

namespace X86Assembly.Visitors
{
    public abstract class X86Visitor<T>
    {
        public abstract T Visit(AddInstruction instr);
        public abstract T Visit(AndInstruction instr);
        public abstract T Visit(CallInstruction instr);
        public abstract T Visit(CdqInstruction instr);
        public abstract T Visit(CompareInstruction instr);
        public abstract T Visit(JeInstruction instr);
        public abstract T Visit(JmpInstruction instr);
        public abstract T Visit(JneInstruction instr);
        public abstract T Visit(LeaveInstruction instr);
        public abstract T Visit(MovInstruction instr);
        public abstract T Visit(MovzxInstruction instr);
        public abstract T Visit(MulInstruction instr);
        public abstract T Visit(NegateInstruction instr);
        public abstract T Visit(PushInstruction instr);
        public abstract T Visit(RetInstruction instr);
        public abstract T Visit(SetEInstruction instr);
        public abstract T Visit(SetGeInstruction instr);
        public abstract T Visit(SetGInstruction instr);
        public abstract T Visit(SetLeInstruction instr);
        public abstract T Visit(SetLInstruction instr);
        public abstract T Visit(SetNeInstruction instr);
        public abstract T Visit(SignedDivInstruction instr);
        public abstract T Visit(SubInstruction instr);
        public abstract T Visit(LabelInstruction instr);
        public abstract T Visit(LeaInstruction instr);
        public abstract T Visit(SegmentMetaInstruction instr);
        public abstract T Visit(ExternMetaInstruction instr);
        public abstract T Visit(GlobalMetaInstruction instr);
        public abstract T Visit(DataMetaInstruction instr);
        public abstract T Visit(DataVtableInstruction instr);
        
        public T Visit(IX86Instruction instr)
        {
            return Visit((dynamic) instr);
        }
    }
}