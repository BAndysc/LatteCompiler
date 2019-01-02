using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class LocalQuadruple : QuadrupleBase
    {
        public readonly int Index;

        public LocalQuadruple(IFilePlace place, int index) : base(place)
        {
            Index = index;
        }

        public override string ToString()
        {
            return $"alloc #{Index}";
        }
    }
}