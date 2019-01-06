using System.Collections.Generic;

namespace LatteBase.AST
{
    public interface IStatement : INode
    {
        
    }
    
    public interface ISingleDeclaration
    {
        string Name { get; }
        IExpressionNode Value { get; }
    }

    public interface IEmptyNode : IStatement
    {
    }
    public interface IBlockNode : IStatement
    {
        IEnumerable<IStatement> Statements { get; }
    }
    public interface IDeclarationNode : IStatement
    {
        LatteType Type { get; }
        IEnumerable<ISingleDeclaration> Declarations { get; }
    }
    public interface IAssignmentNode : IStatement
    {
        string Variable { get; }
        IExpressionNode Value { get; }
    }
    public interface IIncrementNode : IStatement
    {
        string Variable { get; }
    }
    public interface IDecrementNode : IStatement
    {
        string Variable { get; }
    }
    public interface IReturnNode : IStatement
    {
        IExpressionNode ReturnExpression { get; }
    }
    public interface IVoidReturnNode : IStatement
    {
    }
    public interface IIfNode : IStatement
    {
        IExpressionNode Condition { get; }
        IStatement Statement { get; }
    }
    public interface IIfElseNode : IStatement
    {
        IExpressionNode Condition { get; }
        IStatement Statement { get; }
        IStatement ElseStatement { get; }
    }
    public interface IWhileNode : IStatement
    {
        IExpressionNode Condition { get; }
        IStatement Statement { get; }
    }
    public interface IExpressionStatementNode : IStatement
    {
        IExpressionNode Expression { get; }
    }
}