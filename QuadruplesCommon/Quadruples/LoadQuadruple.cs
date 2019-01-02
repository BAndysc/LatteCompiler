using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class LoadQuadruple : QuadrupleBase
    {
        public readonly int Local;
        public readonly IRegister ResultRegister;

        public LoadQuadruple(IFilePlace place, int local, IRegister resultRegister) : base(place)
        {
            ResultRegister = resultRegister;
            Local = local;
        }

        public override string ToString()
        {
            return $"{ResultRegister} = load {Local}";
        }
    }
}