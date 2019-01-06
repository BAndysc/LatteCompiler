using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using LatteBase;
using LatteBase.AST;

namespace LatteBase.AST.Impl
{
    public class EmptyNode : Node, IEmptyNode
    {
        public EmptyNode(IFilePlace place) : base(place)
        {
        }
    }

    public class BlockNode : Node, IBlockNode
    {
        public BlockNode(IFilePlace place, IEnumerable<IStatement> statements) : base(place)
        {
            Statements = statements;
        }

        public BlockNode(IFilePlace place, params IStatement[] statements) : this(place, statements.ToList())
        {
        }

        public IEnumerable<IStatement> Statements { get; }
    }

    public class SingleDeclaration : ISingleDeclaration
    {
        public SingleDeclaration(string name, IExpressionNode value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public IExpressionNode Value { get; }
    }

    public class DeclarationNode : Node, IDeclarationNode
    {
        public DeclarationNode(IFilePlace place, LatteType type, IEnumerable<ISingleDeclaration> declarations) :
            base(place)
        {
            Type = type;
            Declarations = declarations;
        }

        public DeclarationNode(IFilePlace place, LatteType type, params ISingleDeclaration[] declarations) : this(place,
            type, declarations.ToList())
        {
        }

        public LatteType Type { get; }
        public IEnumerable<ISingleDeclaration> Declarations { get; }
    }

    public class AssignmentNode : Node, IAssignmentNode
    {
        public AssignmentNode(IFilePlace place, string variable, IExpressionNode value) : base(place)
        {
            Variable = variable;
            Value = value;
        }

        public string Variable { get; }
        public IExpressionNode Value { get; }
    }

    public class IncrementNode : Node, IIncrementNode
    {
        public IncrementNode(IFilePlace place, string variable) : base(place)
        {
            Variable = variable;
        }

        public string Variable { get; }
    }

    public class DecrementNode : Node, IDecrementNode
    {
        public DecrementNode(IFilePlace place, string variable) : base(place)
        {
            Variable = variable;
        }

        public string Variable { get; }
    }

    public class ReturnNode : Node, IReturnNode
    {
        public ReturnNode(IFilePlace place, IExpressionNode returnExpression) : base(place)
        {
            ReturnExpression = returnExpression;
        }

        public IExpressionNode ReturnExpression { get; }
    }

    public class VoidReturnNode : Node, IVoidReturnNode
    {
        public VoidReturnNode(IFilePlace place) : base(place)
        {
        }
    }

    public class IfNode : Node, IIfNode
    {
        public IfNode(IFilePlace place, IExpressionNode condition, IStatement statement) : base(place)
        {
            Condition = condition;
            Statement = statement;
        }

        public IExpressionNode Condition { get; }
        public IStatement Statement { get; }
    }

    public class IfElseNode : Node, IIfElseNode
    {
        public IfElseNode(IFilePlace place, IExpressionNode condition, IStatement statement,
            IStatement elseStatement) : base(place)
        {
            Condition = condition;
            Statement = statement;
            ElseStatement = elseStatement;
        }

        public IExpressionNode Condition { get; }
        public IStatement Statement { get; }
        public IStatement ElseStatement { get; }
    }

    public class WhileNode : Node, IWhileNode
    {
        public WhileNode(IFilePlace place, IExpressionNode condition, IStatement statement) : base(place)
        {
            Condition = condition;
            Statement = statement;
        }

        public IExpressionNode Condition { get; }
        public IStatement Statement { get; }
    }

    public class ExpressionStatementNode : Node, IExpressionStatementNode
    {
        public ExpressionStatementNode(IFilePlace place, IExpressionNode expression) : base(place)
        {
            Expression = expression;
        }

        public IExpressionNode Expression { get; }
    }
}