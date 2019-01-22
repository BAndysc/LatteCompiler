using System.Linq;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;

namespace LatteBase.CodeGenerators
{
    public class ProgramCodeGenerator : ProgramVisitor<string>
    {
        public override string Visit(IProgram program)
        {
            var funGenerator = new FunctionCodeGenerator();
            var classGenerator = new ClassCodeGenerator();

            var functions = string.Join(",\n", program.Functions.Select(t => funGenerator.Visit(t)));

            var classes = string.Join(", ", program.Classes.Select(classGenerator.Visit));
            
            return $"new ProgramNode(new List<IFunctionDefinitionNode>(){{{functions}}}, new List<IClassDefinitionNode>(){{{classes}}})";
        }
    }
}