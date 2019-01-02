using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class FuncDefQuadruple : QuadrupleBase
    {
        public readonly string FunctionName;

        public FuncDefQuadruple(IFilePlace filePlace, string functionName) : base(filePlace)
        {
            FunctionName = functionName;
        }

        public override string ToString()
        {
            return $"{FunctionName}: ";
        }
    }
}