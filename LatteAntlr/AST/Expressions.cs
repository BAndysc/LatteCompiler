using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using LatteBase.AST;

namespace LatteAntlr.AST
{

    internal class Node : INode
    {
        public IFilePlace FilePlace { get; }
        
        protected Node(IFilePlace place)
        {
            FilePlace = place;
        }
    }

    internal class FilePlace : IFilePlace
    {
        public int LineNumber { get; }
        public string Text { get; }

        public FilePlace(int line, string text)
        {
            LineNumber = line;
            Text = text;
        }
        
        public FilePlace(ParserRuleContext context)
        {
            LineNumber = context.Start.Line;
            Text = context.Start.InputStream.GetText(new Interval(context.Start.StartIndex, context.Stop.StopIndex));
        }
    }
    
    
    internal class IntNode : Node, IIntNode
    {
        public int Value { get; }

        public IntNode(int value, IFilePlace context) : base(context)
        {
            Value = value;
        }
    }

    internal class TrueNode : Node, ITrueNode
    {
        public TrueNode(IFilePlace place) : base(place)
        {
        }
    }

    internal class FalseNode : Node, IFalseNode
    {
        public FalseNode(IFilePlace place) : base(place)
        {
        }
    }

    internal class StringNode : Node, IStringNode
    {
        public string Text { get; }

        public StringNode(string value, IFilePlace context) : base(context)
        {
            Text = value;
        }
    }

    internal class VariableNode : Node, IVariableNode
    {
        public string Variable { get; }

        public VariableNode(string variable, IFilePlace context) : base(context)
        {
            Variable = variable;
        }
    }
    
    internal class NegateNode : Node, INegateNode
    {
        public IExpressionNode Expression { get; }

        public NegateNode(IExpressionNode expr, IFilePlace context) : base(context)
        {
            Expression = expr;
        }
    }

    internal class AndNode : Node, IAndNode
    {
        public IExpressionNode Left { get; }
        public IExpressionNode Right { get; }

        public AndNode(IExpressionNode left, IExpressionNode right, IFilePlace context) : base(context)
        {
            Left = left;
            Right = right;
        }
    }
    
    internal class OrNode : Node, IOrNode
    {
        public IExpressionNode Left { get; }
        public IExpressionNode Right { get; }

        public OrNode(IExpressionNode left, IExpressionNode right, IFilePlace context) : base(context)
        {
            Left = left;
            Right = right;
        }
    }
    
    internal class BinaryNode : Node, IBinaryNode
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
    
    internal class CompareNode : Node, ICompareNode
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

    internal class FunctionCallNode : Node, IFunctionCallNode
    {
        public string FunctionName { get; }
        public IEnumerable<IExpressionNode> Arguments { get; }

        public FunctionCallNode(string function, IEnumerable<IExpressionNode> arguments, IFilePlace context) : base(context)
        {
            FunctionName = function;
            Arguments = arguments;
        }
    }
}