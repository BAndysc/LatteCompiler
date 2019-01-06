using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class SubQuadruple : QuadrupleBase
    {
        public readonly IRegister RegisterA;
        public readonly IRegister RegisterB;
        public readonly IRegister ResultRegister;

        public SubQuadruple(IFilePlace place, IRegister registerA, IRegister registerB, IRegister resultRegister) : base(place)
        {
            RegisterA = registerA;
            RegisterB = registerB;
            ResultRegister = resultRegister;
        }
        public override string ToString()
        {
            return $"{ResultRegister} = {RegisterA} - {RegisterB}";
        }
    }
}