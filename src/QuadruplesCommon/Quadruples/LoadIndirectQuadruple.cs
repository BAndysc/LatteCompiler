using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class LoadIndirectQuadruple : QuadrupleBase
    {
        public readonly IRegister Address;
        public readonly IRegister OffsetReg;
        public readonly int OffsetRegMul;
        public readonly int Offset;
        public readonly IRegister ResultRegister;
        
        public LoadIndirectQuadruple(IFilePlace filePlace, IRegister addr, IRegister offsetReg, int offsetRegMul, int offset, IRegister result) : base(filePlace)
        {
            Address = addr;
            this.OffsetReg = offsetReg;
            this.OffsetRegMul = offsetRegMul;
            Offset = offset;
            ResultRegister = result;
        }

        public override string ToString()
        {
            return $"{ResultRegister} = getelementptr [{Address} + {Offset} + {OffsetReg?.ToString() ?? "-"} * {OffsetRegMul}]";
        }
    }
}