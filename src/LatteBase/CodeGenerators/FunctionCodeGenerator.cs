using System.Linq;
using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteBase.CodeGenerators
{
    public class FunctionCodeGenerator : FunctionDefinitionVisitor<string>
    {
        private LatteTypeCodeGenerator typeGen = new LatteTypeCodeGenerator();
        
        public override string Visit(IFunctionDefinitionNode function)
        {
            var statementGenerator = new StatementCodeGenerator();
            var args = function.Arguments.Select(t => $"new FunctionArgument({typeGen.Visit(t.Type)}, \"{t.Name}\")");
            return $"new FunctionDefinitionNode(new DummyFilePlace(), {typeGen.Visit(function.ReturnType)}, \"{function.Name}\", {statementGenerator.Visit(function.Body)}{string.Join("", args.Select(t => ", " + t))})";
        }
    }
}