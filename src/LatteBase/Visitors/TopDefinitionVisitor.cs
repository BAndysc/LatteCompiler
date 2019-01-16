using LatteBase.AST;

namespace LatteBase.Visitors
{
    public abstract class TopDefinitionVisitor<T>
    {
        public abstract T Visit(IFunctionDefinition function);
    }
}