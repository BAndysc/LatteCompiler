using System.Collections.Generic;

namespace LatteBase.AST
{
    public interface IExpressionNode : INode
    {
        
    }
    
    public interface IIntNode : IExpressionNode
    {
        int Value { get; }
    }

    public interface ITrueNode : IExpressionNode
    {
        
    }

    public interface IFalseNode : IExpressionNode
    {
        
    }

    public interface IStringNode : IExpressionNode
    {
        string Text { get; }
    }

    public interface IVariableNode : IExpressionNode
    {
        string Variable { get; }
    }
    
    public interface INegateNode : IExpressionNode
    {
        IExpressionNode Expression { get; }
    }

    public interface IAndNode : IExpressionNode
    {
        IExpressionNode Left { get; }
        IExpressionNode Right { get; }
    }
    
    public interface IOrNode : IExpressionNode
    {
        IExpressionNode Left { get; }
        IExpressionNode Right { get; }
    }
    
    public interface IBinaryNode : IExpressionNode
    {
        BinaryOperator Operator { get; }
        IExpressionNode Left { get; }
        IExpressionNode Right { get; }
    }
    
    public interface ICompareNode : IExpressionNode
    {
        RelOperator Operator { get; }
        IExpressionNode Left { get; }
        IExpressionNode Right { get; }
    }

    public interface IFunctionCallNode : IExpressionNode
    {
        string FunctionName { get; }
        IList<IExpressionNode> Arguments { get; }
    }
}
