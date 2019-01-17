using LatteBase.AST;

namespace LatteBase.Visitors
{
    public abstract class ProgramFunctionVisitor<T>
    {   
        public abstract T Visit(IProgram program);
        public abstract T Visit(IFunctionDefinition function);
        public abstract T Visit(IClassDefinitionNode @class);
        
        public T Visit(IExpressionNode node)
        {
            return Visit((dynamic)node);
        }
    }
}