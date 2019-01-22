using System.Linq;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;

namespace LatteBase.Transformers
{
    public class ExpressionTransformer : ExpressionVisitor<IExpressionNode>
    {
        public override IExpressionNode Visit(IIntNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(ITrueNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IFalseNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IStringNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IVariableNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(INegateNode node)
        {
            return new NegateNode(Visit(node.Expression), node.FilePlace);
        }

        public override IExpressionNode Visit(ILogicalNegateNode node)
        {
            return new LogicalNegateNode(Visit(node.Expression), node.FilePlace);
        }

        public override IExpressionNode Visit(IAndNode node)
        {
            return new AndNode(Visit(node.Left), Visit(node.Right), node.FilePlace);
        }

        public override IExpressionNode Visit(IOrNode node)
        {
            return new OrNode(Visit(node.Left), Visit(node.Right), node.FilePlace);
        }

        public override IExpressionNode Visit(IBinaryNode node)
        {
            return new BinaryNode(node.Operator, Visit(node.Left), Visit(node.Right), node.FilePlace);
        }

        public override IExpressionNode Visit(ICompareNode node)
        {
            return new CompareNode(node.Operator, Visit(node.Left), Visit(node.Right), node.FilePlace);
        }

        public override IExpressionNode Visit(IFunctionCallNode node)
        {
            return new FunctionCallNode(node.FunctionName, node.Arguments.Select(Visit).ToList(), node.FilePlace);
        }

        public override IExpressionNode Visit(INullNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(INewObjectNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(ICastExpressionNode node)
        {
            return new CastExpressionNode(node.FilePlace, node.CastType, Visit(node.Expression), node.ForceCast);
        }
        

        public override IExpressionNode Visit(IObjectFieldNode node)
        {
            return new ObjectFieldNode(node.FilePlace, Visit(node.Object), node.FieldName);
        }

        public override IExpressionNode Visit(IObjectFieldWithOffsetNode node)
        {
            return new ObjectFieldWithOffsetNode(node.FilePlace, Visit(node.Object), node.FieldName, node.FieldOffset);
        }

        public override IExpressionNode Visit(IMethodCallNode node)
        {
            return new MethodCallNode(node.FilePlace, Visit(node.Object), node.MethodName, node.Arguments.Select(Visit));
        }

        public override IExpressionNode Visit(IMethodCallWithOffsetNode node)
        {
            return new MethodCallWithOffsetNode(node.FilePlace, Visit(node.Object), node.MethodName,
                node.Arguments.Select(Visit), node.ObjectType, node.MethodOffset);
        }

        public override IExpressionNode Visit(IArrayAccessNode node)
        {
            return new ArrayAccessNode(node.FilePlace, Visit(node.Array), Visit(node.Index));
        }

        public override IExpressionNode Visit(INewArrayNode node)
        {
            return new NewArrayNode(node.FilePlace, node.ArrayType, Visit(node.Size));
        }

        public override IExpressionNode Visit(IStringCompareNode node)
        {
            return new StringCompareNode(node.FilePlace, Visit(node.Left), Visit(node.Right));
        }
    }

}