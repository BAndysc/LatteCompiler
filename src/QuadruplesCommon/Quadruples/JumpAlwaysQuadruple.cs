using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class JumpAlwaysQuadruple : QuadrupleBase
    {
        public readonly Label Destination;
        
        public JumpAlwaysQuadruple(IFilePlace filePlace, Label destination) : base(filePlace)
        {
            Destination = destination;
        }

        public override string ToString()
        {
            return $"jump {Destination}";
        }
    }
}