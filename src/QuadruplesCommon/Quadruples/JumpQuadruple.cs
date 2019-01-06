using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class JumpQuadruple : QuadrupleBase
    {
        public readonly Label Destination;
        public readonly Label Else;
        public readonly RelOperator Operator;
        
        public JumpQuadruple(IFilePlace filePlace, Label destination,  Label elseLabel, RelOperator @operator) : base(filePlace)
        {
            Destination = destination;
            Else = elseLabel;
            Operator = @operator;
        }

        public override string ToString()
        {
            return $"jump {Destination} if {Operator} else {Else}";
        }
    }
}