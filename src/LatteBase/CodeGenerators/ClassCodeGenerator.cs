using System.Linq;
using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteBase.CodeGenerators
{
    public class ClassCodeGenerator : ClassDefinitionVisitor<string>
    {
        public override string Visit(IClassDefinitionNode classNode)
        {
            var typeGenerator = new LatteTypeCodeGenerator();
            var funGenerator = new FunctionCodeGenerator();

            var functions = string.Join(", ", classNode.Methods.Select(funGenerator.Visit));

            var fields = string.Join(", ",
                classNode.Fields.Select(t =>
                    $"new ClassFieldNode(new DummyFilePlace(), \"{t.FiledName}\", {typeGenerator.Visit(t.FieldType)})"));

            if (!string.IsNullOrEmpty(fields))
                fields = ", " + fields;

            return
                $"new ClassDefinitionNode(new DummyFilePlace(), \"{classNode.ClassName}\", \"{classNode.SuperClass}\", new List<IFunctionDefinitionNode>(){{{functions}}}{fields})";
        }
    }
}