using System.Linq;
using LatteBase.AST;
using LatteBase.Visitors;

namespace LatteBase.CodeGenerators
{
    public class ExpressionCodeGenerator : ExpressionVisitor<string>
    {
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
            return $"new StringNode({node.Text}, new DummyFilePlace())";
        }

        public override string Visit(IVariableNode node)
        {
            return $"new VariableNode(\"{node.Variable}\", new DummyFilePlace())";
        }

        public override string Visit(INegateNode node)
        {
            return $"new NegateNode({Visit(node.Expression)}, new DummyFilePlace())";
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
            return $"new FunctionCallNode(\"{node.FunctionName}\", new List<IExpressionNode>(){{{string.Join(", ", node.Arguments.Select(Visit))}}}, new DummyFilePlace())";
        }
    }
}