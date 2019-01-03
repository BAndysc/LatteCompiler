using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class LoadArgumentQuadruple : QuadrupleBase
    {
        public readonly int argumentIndex;
        public readonly int localIndex;

        public LoadArgumentQuadruple(IFilePlace source, int argumentIndex, int localIndex) : base(source)
        {
            this.argumentIndex = argumentIndex;
            this.localIndex = localIndex;
        }

        public override string ToString()
        {
            return $"#{localIndex} = load argument {argumentIndex}";
        }
    }
}