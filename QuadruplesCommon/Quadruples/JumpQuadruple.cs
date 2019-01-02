using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class JumpQuadruple : QuadrupleBase
    {
        public readonly Label Destination;
        public readonly RelOperator Operator;
        
        public JumpQuadruple(IFilePlace filePlace, Label destination, RelOperator @operator) : base(filePlace)
        {
            Destination = destination;
            Operator = @operator;
        }

        public override string ToString()
        {
            return $"jump {Destination} if {Operator}";
        }
    }
}