using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class LoadIndirectQuadruple : QuadrupleBase
    {
        public readonly IRegister Address;
        public readonly int Offset;
        public readonly IRegister ResultRegister;
        
        public LoadIndirectQuadruple(IFilePlace filePlace, IRegister addr, int offset, IRegister result) : base(filePlace)
        {
            Address = addr;
            Offset = offset;
            ResultRegister = result;
        }

        public override string ToString()
        {
            return $"{ResultRegister} = getelementptr [{Address} + {Offset}]";
        }
    }
}