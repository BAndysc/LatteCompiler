using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class StoreQuadruple : QuadrupleBase
    {
        public readonly int Local;
        public readonly IRegister Value;

        public StoreQuadruple(IFilePlace place, int local, IRegister value) : base(place)
        {
            Local = local;
            Value = value;
        }

        public override string ToString()
        {
            return $"store {Value} to #{Local}";
        }
    }
}