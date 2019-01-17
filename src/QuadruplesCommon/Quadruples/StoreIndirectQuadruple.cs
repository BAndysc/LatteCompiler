using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class StoreIndirectQuadruple : QuadrupleBase
    {
        public readonly IRegister ObjectAddr;
        public readonly int Offset;
        public readonly IRegister Value;

        public StoreIndirectQuadruple(IFilePlace filePlace, IRegister objectAddr, int offset, IRegister value) : base(filePlace)
        {
            this.ObjectAddr = objectAddr;
            this.Offset = offset;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"[{ObjectAddr} + {Offset}] = {Value}";
        }
    }
}