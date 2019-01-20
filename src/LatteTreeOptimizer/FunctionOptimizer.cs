using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    internal class FunctionOptimizer : FunctionDefinitionVisitor<IFunctionDefinitionNode>
    {
        public override IFunctionDefinitionNode Visit(IFunctionDefinitionNode function)
        {
            var statementOptimizer = new StatementOptimizer();
            return new FunctionDefinitionNode(function.FilePlace, 
                function.ReturnType, 
                function.Name, 
                function.Arguments, 
                statementOptimizer.Visit(function.Body));
        }
    }
}