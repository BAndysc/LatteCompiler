using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class LogicalNegateQuadruple : QuadrupleBase
    {
        public readonly IRegister Value;
        public readonly IRegister ResultRegister;

        public LogicalNegateQuadruple(IFilePlace source, IRegister value, IRegister resultRegister) : base(source)
        {
            Value = value;
            ResultRegister = resultRegister;
        }

        public override string ToString()
        {
            return $"{ResultRegister} = !{Value}";
        }
    }
}