using System.Linq;
using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteBase.CodeGenerators
{
    public class FunctionCodeGenerator : TopDefinitionVisitor<string>
    {
        public override string Visit(IFunctionDefinition function)
        {
            var statementGenerator = new StatementCodeGenerator();
            var args = function.Arguments.Select(t => $"new FunctionArgument(LatteType.{t.Type}, \"{t.Name}\")");
            return $"new TopFunctionNode(new DummyFilePlace(), LatteType.{function.ReturnType}, \"{function.Name}\", {statementGenerator.Visit(function.Body)}{string.Join("", args.Select(t => ", " + t))})";
        }
    }
}