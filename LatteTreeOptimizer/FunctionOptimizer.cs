using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    internal class FunctionOptimizer : TopDefinitionVisitor<ITopFunctionNode>
    {
        public override ITopFunctionNode Visit(ITopFunctionNode topFunction)
        {
            var statementOptimizer = new StatementOptimizer();
            return new TopFunctionNode(topFunction.FilePlace, 
                topFunction.ReturnType, 
                topFunction.Name, 
                topFunction.Arguments, 
                statementOptimizer.Visit(topFunction.Body));
        }
    }
}