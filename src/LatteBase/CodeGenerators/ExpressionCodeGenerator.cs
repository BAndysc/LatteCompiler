using System.Linq;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;

namespace LatteBase.CodeGenerators
{
    public class ExpressionCodeGenerator : ExpressionVisitor<string>
    {
        private LatteTypeCodeGenerator typeGen = new LatteTypeCodeGenerator();
        public override string Visit(IIntNode node)
        {
            return $"new IntNode({node.Value}, new DummyFilePlace())";
        }

        public override string Visit(ITrueNode node)
        {
            return $"new TrueNode(new DummyFilePlace())";
        }

        public override string Visit(IFalseNode node)
        {
            return $"new FalseNode(new DummyFilePlace())";
        }

        public override string Visit(IStringNode node)
        {
            return $"new StringNode(\"{node.Text}\", new DummyFilePlace())";
        }

        public override string Visit(IVariableNode node)
        {
            return $"new VariableNode(\"{node.Variable}\", new DummyFilePlace())";
        }

        public override string Visit(INegateNode node)
        {
            return $"new NegateNode({Visit(node.Expression)}, new DummyFilePlace())";
        }

        public override string Visit(ILogicalNegateNode node)
        {
            return $"new LogicalNegateNode({Visit(node.Expression)}, new DummyFilePlace())";
        }
        
        public override string Visit(IAndNode node)
        {
            return $"new AndNode(\n{Visit(node.Left)}, \n{Visit(node.Right)}, \nnew DummyFilePlace())";
        }

        public override string Visit(IOrNode node)
        {
            return $"new OrNode(\n{Visit(node.Left)}, \n{Visit(node.Right)}, \nnew DummyFilePlace())";
        }

        public override string Visit(IBinaryNode node)
        {
            return $"new BinaryNode(BinaryOperator.{node.Operator}, \n{Visit(node.Left)}, \n{Visit(node.Right)}, \nnew DummyFilePlace())";
        }

        public override string Visit(ICompareNode node)
        {
            return $"new CompareNode(RelOperator.{node.Operator}, \n{Visit(node.Left)}, \n{Visit(node.Right)}, \nnew DummyFilePlace())";
        }

        public override string Visit(IFunctionCallNode node)
        {
            return $"new FunctionCallNode(new DummyFilePlace(), \"{node.FunctionName}\"{string.Join("", node.Arguments.Select(Visit).Select(t => ", " +  t))})";
        }

        public override string Visit(INullNode node)
        {
            return $"new NullNode(new DummyFilePlace())";
        }

        public override string Visit(INewObjectNode node)
        {
            return $"new NewObjectNode(new DummyFilePlace(), {typeGen.Visit(node.Type)})";
        }

        public override string Visit(ICastExpressionNode node)
        {
            return $"new CastExpressionNode(new DummyFilePlace(), {typeGen.Visit(node.CastType)}, {Visit(node.Expression)})";
        }

        public override string Visit(IObjectFieldNode node)
        {
            return $"new ObjectFieldNode(new DummyFilePlace(), {Visit(node.Object)}, \"{node.FieldName}\")";
        }

        public override string Visit(IObjectFieldWithOffsetNode node)
        {
            return
                $"new ObjectFieldWithOffsetNode(new DummyFilePlace(), {Visit(node.Object)}, \"{node.FieldName}\", {node.FieldOffset})";
        }

        public override string Visit(IMethodCallNode node)
        {
            return $"new MethodCallNode(new DummyFilePlace(), {Visit(node.Object)}, \"{node.MethodName}\", new List<IExpressionNode>(){{{string.Join(", ", node.Arguments.Select(Visit))}}})";
        }
        
        public override string Visit(IMethodCallWithOffsetNode node)
        {
            return $"new MethodCallWithOffsetNode(new DummyFilePlace(), {Visit(node.Object)}, \"{node.MethodName}\", new List<IExpressionNode>(){{{string.Join(", ", node.Arguments.Select(Visit))}}}, {node.ObjectType})";
        }

        public override string Visit(IArrayAccessNode node)
        {
            return $"new ArrayAccessNode(new DummyFilePlace(), {Visit(node.Array)}, {Visit(node.Index)})";
        }

        public override string Visit(INewArrayNode node)
        {
            return $"new NewArrayNode(new DummyFilePlace(), {typeGen.Visit(node.ArrayType)}, {Visit(node.Size)})";
        }

        public override string Visit(IStringCompareNode node)
        {
            return $"new StringCompareNode(new DummyFilePlace(), {Visit(node.Left)}, {Visit(node.Right)})";
        }
    }
}