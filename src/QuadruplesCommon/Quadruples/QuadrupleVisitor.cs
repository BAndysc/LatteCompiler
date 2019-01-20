namespace QuadruplesCommon.Quadruples
{
    public abstract class QuadrupleVisitor<T>
    {
        public abstract T Visit(AddQuadruple quadruple);
        public abstract T Visit(SubQuadruple quadruple);
        public abstract T Visit(MulQuadruple quadruple);
        public abstract T Visit(DivQuadruple quadruple);
        public abstract T Visit(ModQuadruple quadruple);
        public abstract T Visit(ConcatQuadruple quadruple);
        public abstract T Visit(ImmediateValueQuadruple quadruple);
        public abstract T Visit(LoadQuadruple quadruple);
        public abstract T Visit(LocalQuadruple quadruple);
        public abstract T Visit(ReturnQuadruple quadruple);
        public abstract T Visit(ReturnVoidQuadruple quadruple);
        public abstract T Visit(StoreQuadruple quadruple);
        public abstract T Visit(FunctionCallQuadruple quadruple);
        public abstract T Visit(CompareQuadruple quadruple);
        public abstract T Visit(JumpQuadruple quadruple);
        public abstract T Visit(JumpAlwaysQuadruple quadruple);
        public abstract T Visit(SetIfQuadruple quadruple);
        public abstract T Visit(LabelQuadruple quadruple);
        public abstract T Visit(LoadLabelPtrQuadruple quadruple);
        public abstract T Visit(FuncDefQuadruple quadruple);
        public abstract T Visit(LoadArgumentQuadruple quadruple); 
        public abstract T Visit(NegateQuadruple quadruple);
        public abstract T Visit(LogicalNegateQuadruple quadruple);
        public abstract T Visit(StoreIndirectQuadruple quadruple);
        public abstract T Visit(LoadIndirectQuadruple quadruple);
        public abstract T Visit(VirtualCallQuadruple quadruple);
        public abstract T Visit(InitVtableQuadruple quadruple);
        
        public T Visit(QuadrupleBase quadruple)
        {
            return Visit((dynamic) quadruple);
        }
    }
}