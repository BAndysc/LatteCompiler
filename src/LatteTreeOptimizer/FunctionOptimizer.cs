using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    internal class FunctionOptimizer : TopDefinitionVisitor<IFunctionDefinition>
    {
        public override IFunctionDefinition Visit(IFunctionDefinition function)
        {
            var statementOptimizer = new StatementOptimizer();
            return new FunctionDefinition(function.FilePlace, 
                function.ReturnType, 
                function.Name, 
                function.Arguments, 
                statementOptimizer.Visit(function.Body));
        }
    }
}