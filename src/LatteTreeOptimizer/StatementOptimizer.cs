using System.Collections.Generic;
using System.Linq;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;

namespace LatteTreeOptimizer
{
    internal class StatementOptimizer : StatementVisitor<IStatement>
    {
        private ExpressionOptimizer expressionOptimizer = new ExpressionOptimizer();

        private BoolCompileTimeEvaluator boolCompileTimeEvaluator = new BoolCompileTimeEvaluator();
        
        public override IStatement Visit(IEmptyNode node)
        {
            return node;
        }

        public override IStatement Visit(IBlockNode node)
        {
            var returnDetector = new IsReturnStatement();

            var stmts = new List<IStatement>();
            
            foreach (var stmt in node.Statements)
            {
                var optimized = Visit(stmt);

                stmts.Add(optimized);
                
                if (returnDetector.Visit(optimized))
                    break;
            }
            
            return new BlockNode(node.FilePlace, stmts);
        }

        public override IStatement Visit(IDeclarationNode node)
        {
            var declarations = node.Declarations.Select(t =>
            {
                if (t.Value == null)
                    return t;

                return new SingleDeclaration(t.Name, expressionOptimizer.Visit(t.Value));
            });
            
            return new DeclarationNode(node.FilePlace, node.Type, declarations);
        }

        public override IStatement Visit(IAssignmentNode node)
        {
            var optimizedExpression = expressionOptimizer.Visit(node.Value);
            return new AssignmentNode(node.FilePlace, node.Variable, optimizedExpression);
        }

        public override IStatement Visit(IIncrementNode node)
        {
            return node; // nothing to optimize
        }

        public override IStatement Visit(IDecrementNode node)
        {
            return node; // nothing to optimize
        }

        public override IStatement Visit(IReturnNode node)
        {
            var optimizedExpression = expressionOptimizer.Visit(node.ReturnExpression);
            
            return new ReturnNode(node.FilePlace, optimizedExpression);
        }

        public override IStatement Visit(IVoidReturnNode node)
        {
            return node;
        }

        public override IStatement Visit(IIfNode node)
        {
            var optimizedExpression = expressionOptimizer.Visit(node.Condition);

            var compileTimeValue = boolCompileTimeEvaluator.Visit(optimizedExpression);
            
            if (compileTimeValue.HasValue && compileTimeValue.Value == false)
                return new EmptyNode(node.FilePlace); // optimize out

            if (compileTimeValue.HasValue && compileTimeValue.Value == true)
            {
                // always true - drop if, but put as block
                return new BlockNode(node.FilePlace, new List<IStatement>(){Visit(node.Statement)});
            }
            
            return new IfNode(node.FilePlace, optimizedExpression, Visit(node.Statement));
        }

        public override IStatement Visit(IIfElseNode node)
        {
            var optimizedExpression = expressionOptimizer.Visit(node.Condition);

            var compileTimeValue = boolCompileTimeEvaluator.Visit(optimizedExpression);

            if (compileTimeValue.HasValue)
            {
                if (compileTimeValue.Value) // always true, then just put first statement
                    return new BlockNode(node.FilePlace, new List<IStatement>(){Visit(node.Statement)});
                else // always false, put else statement
                    return new BlockNode(node.FilePlace, new List<IStatement>(){Visit(node.ElseStatement)});
                    
            }
            //else cannot decide during compile time
            
            return new IfElseNode(node.FilePlace, optimizedExpression, Visit(node.Statement), Visit(node.ElseStatement));
        }

        public override IStatement Visit(IWhileNode node)
        {
            var optimizedExpression = expressionOptimizer.Visit(node.Condition);

            var compileTimeValue = boolCompileTimeEvaluator.Visit(optimizedExpression);
            
            if (compileTimeValue.HasValue && compileTimeValue.Value == false)
                return new EmptyNode(node.FilePlace); // optimize out
           
            return new WhileNode(node.FilePlace, optimizedExpression, Visit(node.Statement));
        }

        public override IStatement Visit(IExpressionStatementNode node)
        {
            return new ExpressionStatementNode(node.FilePlace, expressionOptimizer.Visit(node.Expression));
        }

        public override IStatement Visit(IStructAssignmentNode node)
        {
            return new StructAssignmentNode(node.FilePlace, expressionOptimizer.Visit(node.Object), node.FieldName, expressionOptimizer.Visit(node.Value));
        }

        public override IStatement Visit(IStructAssignmentWithOffsetNode node)
        {
            return new StructAssignmentWithOffsetNode(node.FilePlace, expressionOptimizer.Visit(node.Object), node.FieldName, expressionOptimizer.Visit(node.Value), node.FieldOffset);
        }

        public override IStatement Visit(IStructIncrementNode node)
        {
            return node;
        }

        public override IStatement Visit(IStructIncrementWithOffsetNode node)
        {
            return node;
        }

        public override IStatement Visit(IStructDecrementNode node)
        {
            return node;
        }

        public override IStatement Visit(IStructDecrementWithOffsetNode node)
        {
            return node;
        }

        public override IStatement Visit(IArrayAssignmentNode node)
        {
            return new ArrayAssignmentNode(node.FilePlace, expressionOptimizer.Visit(node.Array), expressionOptimizer.Visit(node.Index), expressionOptimizer.Visit(node.Value));
        }

        public override IStatement Visit(IForEachNode node)
        {
            return new ForEachNode(node.FilePlace, node.IteratorType, node.IteratorName, expressionOptimizer.Visit(node.Array), Visit(node.Body));
        }
    }
}