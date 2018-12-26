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
    }
}