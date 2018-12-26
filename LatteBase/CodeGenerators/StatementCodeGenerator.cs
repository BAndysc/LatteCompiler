using System.Linq;
using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteBase.CodeGenerators
{
    public class StatementCodeGenerator : StatementVisitor<string>
    {
        private readonly ExpressionCodeGenerator expressionGenerator;
        
        public StatementCodeGenerator()
        {
            expressionGenerator = new ExpressionCodeGenerator();
        }

        public override string Visit(IEmptyNode node)
        {
            return $"new EmptyNode(new DummyFilePlace())";
        }

        public override string Visit(IBlockNode node)
        {
            return $"new BlockNode(new DummyFilePlace(), new List<IStatement>(){{\n {string.Join(", \n", node.Statements.Select(Visit))} \n}})";
        }

        public override string Visit(IDeclarationNode node)
        {
            var declarations = node.Declarations.Select(t => $"new SingleDeclaration(\"{t.Name}\", {(t.Value == null ? "null" : expressionGenerator.Visit(t.Value))})");
            return $"new DeclarationNode(new DummyFilePlace(), LatteType.{node.Type}, new List<ISingleDeclaration>(){{ {string.Join(", ", declarations)} }})";
        }

        public override string Visit(IAssignmentNode node)
        {
            return $"new AssignmentNode(new DummyFilePlace(), \"{node.Variable}\", {expressionGenerator.Visit(node.Value)})";
        }

        public override string Visit(IIncrementNode node)
        {
            return $"new IncrementNode(new DummyFilePlace(), \"{node.Variable}\")";
        }

        public override string Visit(IDecrementNode node)
        {   
            return $"new DecrementNode(new DummyFilePlace(), \"{node.Variable}\")";
        }

        public override string Visit(IReturnNode node)
        {
            return $"new ReturnNode(new DummyFilePlace(), {expressionGenerator.Visit(node.ReturnExpression)})";
        }

        public override string Visit(IVoidReturnNode node)
        {
            return $"new VoidReturnNode(new DummyFilePlace())";
        }

        public override string Visit(IIfNode node)
        {
            return $"new IfNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Condition)}, {Visit(node.Statement)})";
        }

        public override string Visit(IIfElseNode node)
        {
            return $"new IfElseNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Condition)}, {Visit(node.Statement)}, {Visit(node.ElseStatement)})";
        }

        public override string Visit(IWhileNode node)
        {
            return $"new WhileNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Condition)}, {Visit(node.Statement)})";
        }

        public override string Visit(IExpressionStatementNode node)
        {
            return $"new ExpressionStatementNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Expression)})";
        }
    }
}