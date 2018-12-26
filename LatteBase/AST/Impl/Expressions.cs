using System.Collections.Generic;
using System.Linq;
using LatteBase.AST;

namespace LatteBase.AST.Impl
{

    public class Node : INode
    {
        public IFilePlace FilePlace { get; }
        
        protected Node(IFilePlace place)
        {
            FilePlace = place;
        }
    }
    
    public class IntNode : Node, IIntNode
    {
        public int Value { get; }

        public IntNode(int value, IFilePlace context) : base(context)
        {
            Value = value;
        }
    }

    public class TrueNode : Node, ITrueNode
    {
        public TrueNode(IFilePlace place) : base(place)
        {
        }
    }

    public class FalseNode : Node, IFalseNode
    {
        public FalseNode(IFilePlace place) : base(place)
        {
        }
    }

    public class StringNode : Node, IStringNode
    {
        public string Text { get; }

        public StringNode(string value, IFilePlace context) : base(context)
        {
            Text = value;
        }
    }

    public class VariableNode : Node, IVariableNode
    {
        public string Variable { get; }

        public VariableNode(string variable, IFilePlace context) : base(context)
        {
            Variable = variable;
        }
    }
    
    public class NegateNode : Node, INegateNode
    {
        public IExpressionNode Expression { get; }

        public NegateNode(IExpressionNode expr, IFilePlace context) : base(context)
        {
            Expression = expr;
        }
    }

    public class AndNode : Node, IAndNode
    {
        public IExpressionNode Left { get; }
        public IExpressionNode Right { get; }

        public AndNode(IExpressionNode left, IExpressionNode right, IFilePlace context) : base(context)
        {
            Left = left;
            Right = right;
        }
    }
    
    public class OrNode : Node, IOrNode
    {
        public IExpressionNode Left { get; }
        public IExpressionNode Right { get; }

        public OrNode(IExpressionNode left, IExpressionNode right, IFilePlace context) : base(context)
        {
            Left = left;
            Right = right;
        }
    }
    
    public class BinaryNode : Node, IBinaryNode
    {
        public BinaryOperator Operator { get; }
        public IExpressionNode Left { get; }
        public IExpressionNode Right { get; }

        public BinaryNode(BinaryOperator oper, IExpressionNode left, IExpressionNode right, IFilePlace context) : base(context)
        {
            Operator = oper;
            Left = left;
            Right = right;
        }
    }
    
    public class CompareNode : Node, ICompareNode
    {
        public RelOperator Operator { get; }
        public IExpressionNode Left { get; }
        public IExpressionNode Right { get; }

        public CompareNode(RelOperator oper, IExpressionNode left, IExpressionNode right, IFilePlace context) : base(context)
        {
            Operator = oper;
            Left = left;
            Right = right;
        }
    }

    public class FunctionCallNode : Node, IFunctionCallNode
    {
        public string FunctionName { get; }
        public IList<IExpressionNode> Arguments { get; }

        public FunctionCallNode(string function, IList<IExpressionNode> arguments, IFilePlace context) : base(context)
        {
            FunctionName = function;
            Arguments = arguments;
        }
        
        public FunctionCallNode(IFilePlace place, string name, params IExpressionNode[] arguments) : this(name, arguments.ToList(), place) {}
    }
}