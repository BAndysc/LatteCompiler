using LatteBase.AST;

namespace LatteBase.Visitors
{
    public abstract class FunctionDefinitionVisitor<T>
    {
        public abstract T Visit(IFunctionDefinition function);
    }
}