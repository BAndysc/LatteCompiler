using System.Linq;
using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteBase.CodeGenerators
{
    public class ProgramCodeGenerator : ProgramVisitor<string>
    {
        public override string Visit(IProgram program)
        {
            var funGenerator = new FunctionCodeGenerator();
            return $"new ProgramNode(new List<ITopFunctionNode>(){{ {string.Join(",\n", program.Functions.Select(t => funGenerator.Visit(t)))} }})";
        }
    }
}