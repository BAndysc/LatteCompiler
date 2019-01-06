using System.Collections.Generic;
using QuadruplesCommon;
using QuadruplesCommon.Quadruples;

namespace QuadruplesGenerator.RegisterAllocators
{
    public class RequiredRegistersEvaluator : QuadrupleVisitor<HashSet<IRegister>>
    {
        public override HashSet<IRegister> Visit(AddQuadruple quadruple)
        {
            return new HashSet<IRegister>() {quadruple.RegisterA, quadruple.RegisterB};
        }

        public override HashSet<IRegister> Visit(SubQuadruple quadruple)
        {
            return new HashSet<IRegister>() {quadruple.RegisterA, quadruple.RegisterB};
        }

        public override HashSet<IRegister> Visit(MulQuadruple quadruple)
        {
            return new HashSet<IRegister>() {quadruple.RegisterA, quadruple.RegisterB};
        }

        public override HashSet<IRegister> Visit(DivQuadruple quadruple)
        {
            return new HashSet<IRegister>() {quadruple.RegisterA, quadruple.RegisterB};
        }

        public override HashSet<IRegister> Visit(ModQuadruple quadruple)
        {
            return new HashSet<IRegister>() {quadruple.RegisterA, quadruple.RegisterB};
        }
        
        public override HashSet<IRegister> Visit(ConcatQuadruple quadruple)
        {
            return new HashSet<IRegister>() {quadruple.RegisterA, quadruple.RegisterB};
        }
        
        public override HashSet<IRegister> Visit(ImmediateValueQuadruple quadruple)
        {
            return new HashSet<IRegister>() {};
        }

        public override HashSet<IRegister> Visit(LoadQuadruple quadruple)
        {
            return new HashSet<IRegister>() {};
        }

        public override HashSet<IRegister> Visit(LocalQuadruple quadruple)
        {
            return new HashSet<IRegister>() {};
        }

        public override HashSet<IRegister> Visit(ReturnQuadruple quadruple)
        {
            return new HashSet<IRegister>() {quadruple.ValueRegister};
        }

        public override HashSet<IRegister> Visit(StoreQuadruple quadruple)
        {
            return new HashSet<IRegister>() {quadruple.Value};
        }

        public override HashSet<IRegister> Visit(FunctionCallQuadruple quadruple)
        {
            return new HashSet<IRegister>(quadruple.Arguments);
        }

        public override HashSet<IRegister> Visit(NegateQuadruple quadruple)
        {
            return new HashSet<IRegister>() {quadruple.Value};
        }

        public override HashSet<IRegister> Visit(LogicalNegateQuadruple quadruple)
        {
            return new HashSet<IRegister>(){quadruple.Value};
        }

        public override HashSet<IRegister> Visit(CompareQuadruple quadruple)
        {
            return new HashSet<IRegister>(){quadruple.RegValue, quadruple.CompareTo};
        }

        public override HashSet<IRegister> Visit(JumpQuadruple quadruple)
        {
            return new HashSet<IRegister>();
        }

        public override HashSet<IRegister> Visit(SetIfQuadruple quadruple)
        {
            return new HashSet<IRegister>();
        }

        public override HashSet<IRegister> Visit(LabelQuadruple quadruple)
        {
            return new HashSet<IRegister>();
        }

        public override HashSet<IRegister> Visit(JumpAlwaysQuadruple quadruple)
        {
            return new HashSet<IRegister>();
        }

        public override HashSet<IRegister> Visit(LoadLabelPtrQuadruple quadruple)
        {
            return new HashSet<IRegister>();
        }

        public override HashSet<IRegister> Visit(FuncDefQuadruple quadruple)
        {
            return new HashSet<IRegister>();
        }

        public override HashSet<IRegister> Visit(ReturnVoidQuadruple quadruple)
        {
            return new HashSet<IRegister>();
        }

        public override HashSet<IRegister> Visit(LoadArgumentQuadruple quadruple)
        {
            return new HashSet<IRegister>();
        }
    }
}