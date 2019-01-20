using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;

namespace LatteBase.Transformers
{
    public abstract class StatementTransformer : StatementVisitor<IStatement>
    {
        protected abstract StatementVisitor<IStatement> GetTransformerForBlock();

        protected abstract ExpressionVisitor<IExpressionNode> ExpressionVisitor { get; }
        
        public override IStatement Visit(IEmptyNode node)
        {
            return node;
        }

        public override IStatement Visit(IBlockNode node)
        {
            var visitor = GetTransformerForBlock();
            return new BlockNode(node.FilePlace, node.Statements.Select(visitor.Visit).ToList());
        }

        public override IStatement Visit(IDeclarationNode node)
        {
            var declarations = new List<ISingleDeclaration>();

            foreach (var decl in node.Declarations)
                declarations.Add(new SingleDeclaration(decl.Name, decl.Value == null ? null : ExpressionVisitor.Visit(decl.Value)));
            
            return new DeclarationNode(node.FilePlace, node.Type, declarations);
        }

        public override IStatement Visit(IAssignmentNode node)
        {
            return new AssignmentNode(node.FilePlace, node.Variable, ExpressionVisitor.Visit(node.Value));
        }

        public override IStatement Visit(IIncrementNode node)
        {
            return node;
        }

        public override IStatement Visit(IDecrementNode node)
        {
            return node;
        }

        public override IStatement Visit(IReturnNode node)
        {
            return new ReturnNode(node.FilePlace, ExpressionVisitor.Visit(node.ReturnExpression));
        }

        public override IStatement Visit(IVoidReturnNode node)
        {
            return node;
        }

        public override IStatement Visit(IIfNode node)
        {
            return new IfNode(node.FilePlace, ExpressionVisitor.Visit(node.Condition), Visit(node.Statement));
        }

        public override IStatement Visit(IIfElseNode node)
        {
            return new IfElseNode(node.FilePlace, ExpressionVisitor.Visit(node.Condition), Visit(node.Statement), Visit(node.ElseStatement));
        }

        public override IStatement Visit(IWhileNode node)
        {
            return new WhileNode(node.FilePlace, ExpressionVisitor.Visit(node.Condition), Visit(node.Statement));
        }

        public override IStatement Visit(IExpressionStatementNode node)
        {
            return new ExpressionStatementNode(node.FilePlace, ExpressionVisitor.Visit(node.Expression));
        }

        public override IStatement Visit(IStructAssignmentNode node)
        {
            return new StructAssignmentNode(node.FilePlace, ExpressionVisitor.Visit(node.Object), node.FieldName, ExpressionVisitor.Visit(node.Value));
        }
        
        public override IStatement Visit(IStructAssignmentWithOffsetNode node)
        {
            return new StructAssignmentWithOffsetNode(node.FilePlace, ExpressionVisitor.Visit(node.Object), node.FieldName, ExpressionVisitor.Visit(node.Value), node.FieldOffset);
        }

        public override IStatement Visit(IStructIncrementNode node)
        {
            return new StructIncrementNode(node.FilePlace, ExpressionVisitor.Visit(node.Object), node.FieldName);
        }

        public override IStatement Visit(IStructIncrementWithOffsetNode node)
        {
            return new StructIncrementWithOffsetNode(node.FilePlace, ExpressionVisitor.Visit(node.Object), node.FieldName, node.FieldOffset);
        }

        public override IStatement Visit(IStructDecrementNode node)
        {
            return new StructDecrementNode(node.FilePlace, ExpressionVisitor.Visit(node.Object), node.FieldName);
        }

        public override IStatement Visit(IStructDecrementWithOffsetNode node)
        {
            return new StructDecrementWithOffsetNode(node.FilePlace, ExpressionVisitor.Visit(node.Object), node.FieldName, node.FieldOffset);
        }
    }
}