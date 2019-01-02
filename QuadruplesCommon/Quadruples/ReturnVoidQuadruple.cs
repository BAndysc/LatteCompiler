using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class ReturnVoidQuadruple : QuadrupleBase
    {
        public ReturnVoidQuadruple(IFilePlace filePlace) : base(filePlace)
        {
        }

        public override string ToString()
        {
            return $"return";
        }
    }
    
    
}