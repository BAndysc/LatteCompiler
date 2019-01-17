using LatteBase;
using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class BadCastException : TypeCheckerException
    {
        public readonly ILatteType RealType;
        public readonly ILatteType CastType;
        
        public BadCastException(IFilePlace source, ILatteType realType, ILatteType castType) : base(source)
        {
            RealType = realType;
            CastType = castType;
        }

        public override string ToString()
        {
            return $"Can not cast {RealType} to {CastType}.\n{base.ToString()}";
        }
    }
}