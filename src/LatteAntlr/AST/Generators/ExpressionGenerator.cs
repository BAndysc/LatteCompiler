using System.Linq;
using LatteAntlr.Exceptions;
using LatteAntlr.Visitors;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace LatteAntlr.AST.Generators
{

    internal class ExpressionGenerator : LatteBaseExpressionVisitor<IExpressionNode>
    {
        public override IExpressionNode VisitEId(LatteParser.EIdContext context)
        {
            return new VariableNode(context.ID().GetText(), new FilePlace(context));
        }

        public override IExpressionNode VisitEFunCall(LatteParser.EFunCallContext context)
        {
            var args = context.expr().Select(Visit).ToList();
            var name = context.ID().GetText();
            return new FunctionCallNode(name, args, new FilePlace(context));
        }

        public override IExpressionNode VisitERelOp(LatteParser.ERelOpContext context)
        {
            var @operator = new RelOperatorVisitor().Visit(context.relOp());
            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);
            return new CompareNode(@operator, left, right, new FilePlace(context));
        }

        public override IExpressionNode VisitETrue(LatteParser.ETrueContext context)
        {
            return new TrueNode(new FilePlace(context));
        }

        public override IExpressionNode VisitEOr(LatteParser.EOrContext context)
        {
            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);
            return new OrNode(left, right, new FilePlace(context));
        }

        public override IExpressionNode VisitEInt(LatteParser.EIntContext context)
        {
            int asInt;
            if (!int.TryParse(context.INT().GetText(), out asInt))
                throw new IntegerOutOfRangeException(context.INT().GetText(), new FilePlace(context));
                
            return new IntNode(asInt, new FilePlace(context));
        }

        public override IExpressionNode VisitEUnOp(LatteParser.EUnOpContext context)
        {
            var logical = new IsLogicalNegationVisitor().Visit(context.unOp());
            var expr = Visit(context.expr());
            if (logical)
                return new LogicalNegateNode(expr, new FilePlace(context));
            
            return new NegateNode(expr, new FilePlace(context));
        }

        public override IExpressionNode VisitEStr(LatteParser.EStrContext context)
        {
            return new StringNode(context.STR().GetText().Substring(1, context.STR().GetText().Length-2), new FilePlace(context));
        }

        public override IExpressionNode VisitEMulOp(LatteParser.EMulOpContext context)
        {
            var @operator = new BinaryOperatorVisitor().Visit(context.mulOp());
            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);
            return new BinaryNode(@operator, left, right, new FilePlace(context));
        }

        public override IExpressionNode VisitEAnd(LatteParser.EAndContext context)
        {
            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);
            return new AndNode(left, right, new FilePlace(context));
        }

        public override IExpressionNode VisitEParen(LatteParser.EParenContext context)
        {
            return Visit(context.expr());
        }

        public override IExpressionNode VisitEFalse(LatteParser.EFalseContext context)
        {
            return new FalseNode(new FilePlace(context));
        }

        public override IExpressionNode VisitEAddOp(LatteParser.EAddOpContext context)
        { 
            var @operator = new BinaryOperatorVisitor().Visit(context.addOp());
            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);
            return new BinaryNode(@operator, left, right, new FilePlace(context));
        }

        public override IExpressionNode VisitECast(LatteParser.ECastContext context)
        {
            return new CastExpressionNode(new FilePlace(context), new LatteTypeGenerator().Visit(context.type_()),  Visit(context.expr()));
        }

        public override IExpressionNode VisitENull(LatteParser.ENullContext context)
        {
            return new NullNode(new FilePlace(context));
        }

        public override IExpressionNode VisitENewObject(LatteParser.ENewObjectContext context)
        {
            return new NewObjectNode(new FilePlace(context), context.ID().GetText());
        }

        public override IExpressionNode VisitEObjectField(LatteParser.EObjectFieldContext context)
        {
            return new ObjectFieldNode(new FilePlace(context), Visit(context.expr()), context.ID().GetText());
        }
    }
}