using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class CompareQuadruple : QuadrupleBase
    {
        public readonly IRegister RegValue;
        public readonly IRegister CompareTo;

        public CompareQuadruple(IFilePlace filePlace, IRegister regValue, IRegister compareTo) : base(filePlace)
        {
            this.RegValue = regValue;
            this.CompareTo = compareTo;
        }

        public override string ToString()
        {
            return $"compare {RegValue} == {CompareTo}";
        }
    }
}