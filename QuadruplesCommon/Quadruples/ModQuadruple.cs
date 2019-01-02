using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class ModQuadruple : QuadrupleBase
    {
        public readonly IRegister RegisterA;
        public readonly IRegister RegisterB;
        public readonly IRegister ResultRegister;

        public ModQuadruple(IFilePlace place, IRegister registerA, IRegister registerB, IRegister resultRegister) : base(place)
        {
            RegisterA = registerA;
            RegisterB = registerB;
            ResultRegister = resultRegister;
        }
        public override string ToString()
        {
            return $"{ResultRegister} = {RegisterA} % {RegisterB}";
        }
    }
}