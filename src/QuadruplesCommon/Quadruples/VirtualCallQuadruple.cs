using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class VirtualCallQuadruple : QuadrupleBase
    {
        public readonly string FunctionName;
        public readonly IRegister ResultRegister;
        public readonly IEnumerable<IRegister> Arguments;
        public readonly IRegister This;
        public readonly int MethodOffset;

        public VirtualCallQuadruple(IFilePlace source, string functionName, IRegister resultRegister, IRegister @this, int methodOffset, IEnumerable<IRegister> arguments) : base(source)
        {
            FunctionName = functionName;
            Arguments = arguments;
            ResultRegister = resultRegister;
            This = @this;
            MethodOffset = methodOffset;
        }

        public override string ToString()
        {
            return $"{ResultRegister} = vcall {FunctionName}({string.Join(", ", Arguments)})";
        }
    }
}