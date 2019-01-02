using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class ReturnQuadruple : QuadrupleBase
    {
        public readonly IRegister ValueRegister;

        public ReturnQuadruple(IFilePlace place, IRegister valueRegister) : base(place)
        {
            ValueRegister = valueRegister;
        }

        public override string ToString()
        {
            return $"ret {ValueRegister}";
        }
    }
}