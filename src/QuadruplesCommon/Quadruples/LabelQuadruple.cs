using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class LabelQuadruple : QuadrupleBase
    {
        public readonly Label Label;

        public LabelQuadruple(IFilePlace filePlace, Label label) : base(filePlace)
        {
            Label = label;
        }

        public override string ToString()
        {
            return $"{Label}:";
        }
    }
}