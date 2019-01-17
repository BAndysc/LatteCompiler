using LatteBase.AST;

namespace LatteBase.Visitors
{
    public abstract class ClassDefinitionVisitor<T>
    {
        public abstract T Visit(IClassDefinitionNode function);
    }
}