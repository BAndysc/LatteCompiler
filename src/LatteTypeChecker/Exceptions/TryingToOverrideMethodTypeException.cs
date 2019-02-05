using LatteBase;
using LatteBase.AST;

namespace LatteTypeChecker.Exceptions
{
    public class TryingToOverrideMethodTypeException : TypeCheckerException
    {
        private readonly string className;
        private readonly string methodName;
        private readonly ILatteType baseMethodType;
        private readonly ILatteType overridenMethodType;

        public TryingToOverrideMethodTypeException(IFilePlace source, string @className, string methodName, ILatteType baseMethodType, ILatteType overridenMethodType) : base(source)
        {
            this.className = className;
            this.methodName = methodName;
            this.baseMethodType = baseMethodType;
            this.overridenMethodType = overridenMethodType;
        }

        public override string ToString()
        {
            return $"In class {className} trying to override method {methodName} with different resulting type: {overridenMethodType} instead of {baseMethodType}.\n{base.ToString()}";
        }
    }
}