using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class ImmediateValueQuadruple : QuadrupleBase
    {
        public readonly DirectValue Value;
        public readonly IRegister ResultRegister;

        public ImmediateValueQuadruple(IFilePlace place, DirectValue value, IRegister resultRegister) : base(place)
        {
            Value = value;
            ResultRegister = resultRegister;
        }
        
        public override string ToString()
        {
            return $"{ResultRegister} = {Value}";
        }
    }
}