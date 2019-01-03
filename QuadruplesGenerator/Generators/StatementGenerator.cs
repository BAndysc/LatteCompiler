using System;
using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using QuadruplesCommon;
using QuadruplesCommon.Quadruples;

namespace QuadruplesGenerator.Generators
{
    public class StatementGenerator : StatementVisitor<object>
    {
        private readonly QuadruplesProgram program;
        private readonly IStore store;
        private readonly ExpressionGenerator exprGen;

        public StatementGenerator(QuadruplesProgram program, IStore store)
        {
            this.program = program;
            this.store = store;
            exprGen = new ExpressionGenerator(program, store);
        }
        
        public override object Visit(IEmptyNode node)
        {
            return null;
        }

        public override object Visit(IBlockNode node)
        {
            var newVisitor = new StatementGenerator(program, store.CopyForBlock());
            foreach (var stmt in node.Statements)
                newVisitor.Visit(stmt);

            return null;
        }

        public override object Visit(IDeclarationNode node)
        {
            foreach (var decl in node.Declarations)
            {
                IRegister dest;

                if (decl.Value == null)
                {
                    dest = program.GetNextRegister();
                    switch (node.Type)
                    {
                        case LatteType.Int:
                            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), dest));
                            break;
                        case LatteType.String:
                            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), dest));
                            break;
                        case LatteType.Bool:
                            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(false), dest));
                            break;
                    }                    
                }
                else
                {
                    dest = exprGen.Visit(decl.Value);
                }
                int loc = store.Alloc(decl.Name);
                
                program.Emit(new StoreQuadruple(node.FilePlace, loc, dest));
            }

            return null;
        }

        public override object Visit(IAssignmentNode node)
        {
            var result = exprGen.Visit(node.Value);
            
            program.Emit(new StoreQuadruple(node.FilePlace, store.Get(node.Variable), result));

            return null;
        }

        public override object Visit(IIncrementNode node)
        {
            var loaded = program.GetNextRegister();
            var result = program.GetNextRegister();
            var m1 = program.GetNextRegister();
            var localIndex = store.Get(node.Variable);
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(1), m1));
            program.Emit(new LoadQuadruple(node.FilePlace, localIndex, loaded));
            program.Emit(new AddQuadruple(node.FilePlace, loaded, m1, result));
            program.Emit(new StoreQuadruple(node.FilePlace, localIndex, result));
            return null;
        }

        public override object Visit(IDecrementNode node)
        {
            var loaded = program.GetNextRegister();
            var result = program.GetNextRegister();
            var m1 = program.GetNextRegister();
            var localIndex = store.Get(node.Variable);
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(1), m1));
            program.Emit(new LoadQuadruple(node.FilePlace, localIndex, loaded));
            program.Emit(new SubQuadruple(node.FilePlace, loaded, m1, result));
            program.Emit(new StoreQuadruple(node.FilePlace, localIndex, result));
            return null;
        }

        public override object Visit(IReturnNode node)
        {
            var registerWithValue = exprGen.Visit(node.ReturnExpression);
            
            program.Emit(new ReturnQuadruple(node.FilePlace, registerWithValue));
            
            return null;
        }

        public override object Visit(IVoidReturnNode node)
        {            
            program.Emit(new ReturnVoidQuadruple(node.FilePlace));
            
            return null;
        }

        public override object Visit(IIfNode node)
        {
            var condExpr = exprGen.Visit(node.Condition);
            var zeroReg = program.GetNextRegister();
            
            var afterIfLabel = program.GetNextLabel();
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), zeroReg));
            
            program.Emit(new CompareQuadruple(node.FilePlace, condExpr, zeroReg));

            program.Emit(new JumpQuadruple(node.FilePlace, afterIfLabel, RelOperator.Equals));
            
            Visit(node.Statement);
            
            program.Emit(new LabelQuadruple(node.FilePlace, afterIfLabel));

            return null;
        }

        public override object Visit(IIfElseNode node)
        {
            var condExpr = exprGen.Visit(node.Condition);
            var zeroReg = program.GetNextRegister();
            
            var afterIfLabel = program.GetNextLabel();
            var elseLabel = program.GetNextLabel();
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), zeroReg));
            
            program.Emit(new CompareQuadruple(node.FilePlace, condExpr, zeroReg));

            program.Emit(new JumpQuadruple(node.FilePlace, elseLabel, RelOperator.Equals));
            
            Visit(node.Statement);
            
            program.Emit(new JumpAlwaysQuadruple(node.FilePlace, afterIfLabel));

            program.Emit(new LabelQuadruple(node.FilePlace, elseLabel));

            Visit(node.ElseStatement);
            
            program.Emit(new LabelQuadruple(node.FilePlace, afterIfLabel));

            return null;
        }

        public override object Visit(IWhileNode node)
        {
            var zeroReg = program.GetNextRegister();
            var bodyLabel = program.GetNextLabel();
            var conditionLabel = program.GetNextLabel();
            
            program.Emit(new JumpAlwaysQuadruple(node.FilePlace, conditionLabel));
            
            program.Emit(new LabelQuadruple(node.FilePlace, bodyLabel));

            Visit(node.Statement);
            
            program.Emit(new LabelQuadruple(node.FilePlace, conditionLabel));
            
            var condExpr = exprGen.Visit(node.Condition);
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), zeroReg));
            program.Emit(new CompareQuadruple(node.FilePlace, condExpr, zeroReg));

            program.Emit(new JumpQuadruple(node.FilePlace, bodyLabel, RelOperator.NotEquals));
            
            return null;
        }

        public override object Visit(IExpressionStatementNode node)
        {
            exprGen.Visit(node.Expression);
            return null;
        }
    }
}