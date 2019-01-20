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

    public interface INullNode : IExpressionNode
    {
    
    }

    public interface ICastExpressionNode : IExpressionNode
    {
        IExpressionNode Expression { get; }
        ILatteType CastType { get; }
    }

    public interface INewObjectNode : IExpressionNode
    {
        string TypeName { get; }
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

    public interface ILogicalNegateNode : IExpressionNode
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
        BinaryOperator Operator { get; set; }
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

    public interface IObjectFieldNode : IExpressionNode
    {
        IExpressionNode Object { get; }
        string FieldName { get; }
        int FieldOffset { get; set;  }
    }

    public interface IMethodCallNode : IExpressionNode
    {
        IExpressionNode Object { get; }
        string MethodName { get; }
        IList<IExpressionNode> Arguments { get; }
        ILatteType ObjectType { get; set; }
    }
}
