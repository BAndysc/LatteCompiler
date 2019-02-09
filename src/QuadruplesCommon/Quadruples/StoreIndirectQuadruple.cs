using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class StoreIndirectQuadruple : QuadrupleBase
    {
        public readonly IRegister ObjectAddr;
        public readonly IRegister OffsetReg;
        public readonly int OffsetRegMul;
        public readonly int Offset;
        public readonly IRegister Value;

        public StoreIndirectQuadruple(IFilePlace filePlace, IRegister objectAddr, IRegister offsetReg, int offsetRegMul, int offset, IRegister value) : base(filePlace)
        {
            this.ObjectAddr = objectAddr;
            this.Offset = offset;
            this.Value = value;
            OffsetReg = offsetReg;
            OffsetRegMul = offsetRegMul;
        }

        public override string ToString()
        {
            return $"[{ObjectAddr} + {Offset} + {OffsetReg?.ToString() ?? "0"} * {OffsetRegMul}] = {Value}";
        }
    }
}