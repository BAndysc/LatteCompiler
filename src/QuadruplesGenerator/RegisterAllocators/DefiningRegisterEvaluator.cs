using QuadruplesCommon;
using QuadruplesCommon.Quadruples;

namespace QuadruplesGenerator.RegisterAllocators
{
    public class DefiningRegisterEvaluator : QuadrupleVisitor<IRegister>
    {
        public override IRegister Visit(AddQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }

        public override IRegister Visit(SubQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }

        public override IRegister Visit(MulQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }

        public override IRegister Visit(DivQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }

        public override IRegister Visit(ModQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }

        public override IRegister Visit(ConcatQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }
        
        public override IRegister Visit(ImmediateValueQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }

        public override IRegister Visit(LoadQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }

        public override IRegister Visit(NegateQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }
        
        public override IRegister Visit(LogicalNegateQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }

        public override IRegister Visit(LocalQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(ReturnQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(StoreQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(FunctionCallQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }

        public override IRegister Visit(CompareQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(JumpQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(SetIfQuadruple quadruple)
        {
            return quadruple.Destination;
        }

        public override IRegister Visit(LabelQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(JumpAlwaysQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(LoadLabelPtrQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }

        public override IRegister Visit(FuncDefQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(ReturnVoidQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(LoadArgumentQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(StoreIndirectQuadruple quadruple)
        {
            return null;
        }

        public override IRegister Visit(LoadIndirectQuadruple quadruple)
        {
            return quadruple.ResultRegister;
        }
    }
}