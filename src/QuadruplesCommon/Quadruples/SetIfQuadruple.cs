using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class SetIfQuadruple : QuadrupleBase
    {
        public readonly RelOperator Operator;
        public readonly IRegister Destination;

        public SetIfQuadruple(IFilePlace filePlace, RelOperator @operator, IRegister destination) : base(filePlace)
        {
            this.Operator = @operator;
            this.Destination = destination;
        }

        public override string ToString()
        {
            return $"{Destination} = 1 if {Operator} else 0";
        }
    }
}