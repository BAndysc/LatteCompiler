using System.Linq;
using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteBase.CodeGenerators
{
    public class FunctionCodeGenerator : TopDefinitionVisitor<string>
    {
        public override string Visit(ITopFunctionNode topFunction)
        {
            var statementGenerator = new StatementCodeGenerator();
            var args = topFunction.Arguments.Select(t => $"new FunctionArgument(LatteType.{t.Type}, \"{t.Name}\")");
            return $"new TopFunctionNode(new DummyFilePlace(), LatteType.{topFunction.ReturnType}, \"{topFunction.Name}\", {statementGenerator.Visit(topFunction.Body)}{string.Join("", args.Select(t => ", " + t))})";
        }
    }
}