using LatteBase.AST;

namespace LatteBase.Visitors
{
    public abstract class ProgramVisitor<T>
    {
        public abstract T Visit(IProgram program);
    }
}