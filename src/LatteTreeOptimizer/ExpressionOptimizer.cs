using System.Linq;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    internal class ExpressionOptimizer : ExpressionVisitor<IExpressionNode>
    {
        private BoolCompileTimeEvaluator boolOptimizer = new BoolCompileTimeEvaluator();
        private IntCompileTimeEvaluator intOptimizer = new IntCompileTimeEvaluator();
        
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
            return node;
        }

        public override IExpressionNode Visit(ILogicalNegateNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IAndNode node)
        {
            var val = boolOptimizer.Visit(node);

            if (val.HasValue)
            {
                if (val.Value)
                    return new TrueNode(node.FilePlace);
                return new FalseNode(node.FilePlace);
            }
            
            return new AndNode(Visit(node.Left), Visit(node.Right), node.FilePlace);

        }

        public override IExpressionNode Visit(IOrNode node)
        {
            var val = boolOptimizer.Visit(node);

            if (val.HasValue)
            {
                if (val.Value)
                    return new TrueNode(node.FilePlace);
                return new FalseNode(node.FilePlace);
            }
            
            return new OrNode(Visit(node.Left), Visit(node.Right), node.FilePlace);

        }

        public override IExpressionNode Visit(IBinaryNode node)
        {
            var val = intOptimizer.Visit(node);
            
            if (val.HasValue)
                return new IntNode(val.Value, node.FilePlace);
            
            return new BinaryNode(node.Operator, Visit(node.Left), Visit(node.Right), node.FilePlace);
        }

        public override IExpressionNode Visit(ICompareNode node)
        {
            var val = boolOptimizer.Visit(node);

            if (val.HasValue)
            {
                if (val.Value)
                    return new TrueNode(node.FilePlace);
                return new FalseNode(node.FilePlace);
            }
            
            return new CompareNode(node.Operator, Visit(node.Left), Visit(node.Right), node.FilePlace);
        }

        public override IExpressionNode Visit(IFunctionCallNode node)
        {
            return node;
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
            return node;
        }

        public override IExpressionNode Visit(IObjectFieldNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IObjectFieldWithOffsetNode node)
        {
            return node;
        }

        public override IExpressionNode Visit(IMethodCallNode node)
        {
            return new MethodCallNode(node.FilePlace, Visit(node.Object), node.MethodName, node.Arguments.Select(Visit));
        }

        public override IExpressionNode Visit(IMethodCallWithOffsetNode node)
        {
            return new MethodCallWithOffsetNode(node.FilePlace, Visit(node.Object), node.MethodName, node.Arguments.Select(Visit), node.ObjectType, node.MethodOffset);
        }
        public override IExpressionNode Visit(IArrayAccessNode node)
        {
            return new ArrayAccessNode(node.FilePlace, Visit(node.Array), Visit(node.Index));
        }

        public override IExpressionNode Visit(INewArrayNode node)
        {
            return new NewArrayNode(node.FilePlace, node.ArrayType, Visit(node.Size));
        }
    }
}