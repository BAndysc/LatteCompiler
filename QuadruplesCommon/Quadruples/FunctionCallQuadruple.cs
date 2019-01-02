using System.Collections.Generic;
using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class FunctionCallQuadruple : QuadrupleBase
    {
        public readonly string FunctionName;
        public readonly IRegister ResultRegister;
        public  readonly IEnumerable<IRegister> Arguments;

        public FunctionCallQuadruple(IFilePlace source, string functionName, IRegister resultRegister, IEnumerable<IRegister> arguments) : base(source)
        {
            FunctionName = functionName;
            Arguments = arguments;
            ResultRegister = resultRegister;
        }

        public override string ToString()
        {
            return $"{ResultRegister} = call {FunctionName}({string.Join(", ", Arguments)})";
        }
    }
}