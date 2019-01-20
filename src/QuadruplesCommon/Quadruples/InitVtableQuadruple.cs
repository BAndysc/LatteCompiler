using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class InitVtableQuadruple : QuadrupleBase
    {
        public readonly IRegister Addr;
        public readonly string ObjectType;

        public InitVtableQuadruple(IFilePlace source, IRegister addr, string objectType) : base(source)
        {
            this.Addr = addr;
            this.ObjectType = objectType;
        }

        public override string ToString()
        {
            return $"init vtable [{ObjectType}] to {Addr}";
        }
    }
}