using System.Collections.Generic;
using System.IO;
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
        public DeclarationNode(IFilePlace place, ILatteType type, IEnumerable<ISingleDeclaration> declarations) :
            base(place)
        {
            Type = type;
            Declarations = declarations;
        }

        public DeclarationNode(IFilePlace place, ILatteType type, params ISingleDeclaration[] declarations) : this(place,
            type, declarations.ToList())
        {
        }

        public ILatteType Type { get; }
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

    public class StructAssignmentNode : Node, IStructAssignmentNode
    {
        public StructAssignmentNode(IFilePlace place, IExpressionNode o, string fieldName, IExpressionNode value) : base(place)
        {
            Object = o;
            FieldName = fieldName;
            Value = value;
        }

        public IExpressionNode Object { get; }
        public string FieldName { get; }
        public IExpressionNode Value { get; }
    }

    public class StructAssignmentWithOffsetNode : StructAssignmentNode, IStructAssignmentWithOffsetNode
    {
        public StructAssignmentWithOffsetNode(IFilePlace place, IExpressionNode o, string fieldName, IExpressionNode value, int fieldOffset) : base(place, o, fieldName, value)
        {
            FieldOffset = fieldOffset;
        }
        
        public int FieldOffset { get; set; }
    }
    
    public class StructIncrementNode : Node, IStructIncrementNode
    {
        public IExpressionNode Object { get; }
        public string FieldName { get; }

        public StructIncrementNode(IFilePlace place, IExpressionNode o, string fieldName) : base(place)
        {
            Object = o;
            FieldName = fieldName;
        }
    }

    public class StructIncrementWithOffsetNode : StructIncrementNode, IStructIncrementWithOffsetNode
    {
        public int FieldOffset { get; }

        public StructIncrementWithOffsetNode(IFilePlace place, IExpressionNode o, string fieldName, int offset) : base(place, o, fieldName)
        {
            FieldOffset = offset;
        }
    }
    
    public class StructDecrementNode : Node, IStructDecrementNode
    {
        public IExpressionNode Object { get; }
        public string FieldName { get; }

        public StructDecrementNode(IFilePlace place, IExpressionNode o, string fieldName) : base(place)
        {
            Object = o;
            FieldName = fieldName;
        }
    }

    public class StructDecrementWithOffsetNode : StructDecrementNode, IStructDecrementWithOffsetNode
    {
        public int FieldOffset { get; }

        public StructDecrementWithOffsetNode(IFilePlace place, IExpressionNode o, string fieldName, int offset) : base(place, o, fieldName)
        {
            FieldOffset = offset;
        }
    }
    
    
    public class ArrayAssignmentNode : Node, IArrayAssignmentNode 
    {
        public IExpressionNode Array { get; }
        public IExpressionNode Index { get; }
        public IExpressionNode Value { get; }

        public ArrayAssignmentNode(IFilePlace place, IExpressionNode array, IExpressionNode index, IExpressionNode value) : base(place)
        {
            Array = array;
            Index = index;
            Value = value;
        }
    }

    public class ForEachNode : Node, IForEachNode
    {
        public ForEachNode(IFilePlace place, ILatteType iteratorType, string iteratorName, IExpressionNode array, IStatement body) : base(place)
        {
            IteratorType = iteratorType;
            IteratorName = iteratorName;
            Array = array;
            Body = body;
        }

        public ILatteType IteratorType { get; }
        public string IteratorName { get; }
        public IExpressionNode Array { get; }
        public IStatement Body { get; }
    }
}