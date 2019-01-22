using System.Linq;
using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteBase.CodeGenerators
{
    public class StatementCodeGenerator : StatementVisitor<string>
    {
        private LatteTypeCodeGenerator typeGen = new LatteTypeCodeGenerator();
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
            return $"new BlockNode(new DummyFilePlace(), {string.Join(", \n", node.Statements.Select(Visit))})";
        }

        public override string Visit(IDeclarationNode node)
        {
            var declarations = node.Declarations.Select(t => $"new SingleDeclaration(\"{t.Name}\", {(t.Value == null ? "null" : expressionGenerator.Visit(t.Value))})");
            return $"new DeclarationNode(new DummyFilePlace(), {typeGen.Visit(node.Type)}, {string.Join(", ", declarations)})";
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
            return $"new IfNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Condition)}, new BlockNode(new DummyFilePlace(), {Visit(node.Statement)}))";
        }

        public override string Visit(IIfElseNode node)
        {
            return $"new IfElseNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Condition)}, new BlockNode(new DummyFilePlace(), {Visit(node.Statement)}), new BlockNode(new DummyFilePlace(), {Visit(node.ElseStatement)}))";
        }

        public override string Visit(IWhileNode node)
        {
            return $"new WhileNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Condition)}, new BlockNode(new DummyFilePlace(), {Visit(node.Statement)}))";
        }

        public override string Visit(IExpressionStatementNode node)
        {
            return $"new ExpressionStatementNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Expression)})";
        }

        public override string Visit(IStructAssignmentNode node)
        {
            return $"new StructAssignmentNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Object)}, \"{node.FieldName}\", {expressionGenerator.Visit(node.Value)})";
        }
        
        public override string Visit(IStructAssignmentWithOffsetNode node)
        {
            return $"new StructAssignmentWithOffsetNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Object)}, \"{node.FieldName}\", {expressionGenerator.Visit(node.Value)}, {node.FieldOffset})";
        }

        public override string Visit(IStructIncrementNode node)
        {
            return $"new StructIncrementNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Object)}, \"{node.FieldName}\")";
        }

        public override string Visit(IStructIncrementWithOffsetNode node)
        {
            return $"new StructIncrementWithOffsetNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Object)}, \"{node.FieldName}\", {node.FieldOffset})";
        }

        public override string Visit(IStructDecrementNode node)
        {
            return $"new StructDecrementNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Object)}, \"{node.FieldName}\")";
        }

        public override string Visit(IStructDecrementWithOffsetNode node)
        {
            return $"new StructDecrementWithOffsetNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Object)}, \"{node.FieldName}\", {node.FieldOffset})";
        }

        public override string Visit(IArrayAssignmentNode node)
        {
            return $"new ArrayAssignmentNode(new DummyFilePlace(), {expressionGenerator.Visit(node.Array)}, {expressionGenerator.Visit(node.Index)}, {expressionGenerator.Visit(node.Value)})";
        }

        public override string Visit(IForEachNode node)
        {
            return $"new ForEachNode(new DummyFilePlace(), {typeGen.Visit(node.IteratorType)}, \"{node.IteratorName}\", {expressionGenerator.Visit(node.Array)}, {Visit(node.Body)})";
        }
    }
}