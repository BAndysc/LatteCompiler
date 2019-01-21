using System;
using System.Collections.Generic;
using System.Linq;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;
using QuadruplesCommon;
using QuadruplesCommon.Quadruples;

namespace QuadruplesGenerator.Generators
{
    public class StatementGenerator : StatementVisitor<object>
    {
        private readonly QuadruplesProgram program;
        private readonly IStore store;
        private readonly IFunctionDefinitionNode currentFunction;
        private readonly Label startLabel;
        private readonly ExpressionGenerator exprGen;

        public StatementGenerator(QuadruplesProgram program, IStore store, IFunctionDefinitionNode currentFunction, Label startLabel)
        {
            this.program = program;
            this.store = store;
            this.currentFunction = currentFunction;
            this.startLabel = startLabel;
            exprGen = new ExpressionGenerator(program, store);
        }
        
        public override object Visit(IEmptyNode node)
        {
            return null;
        }

        public override object Visit(IBlockNode node)
        {
            var newVisitor = new StatementGenerator(program, store.CopyForBlock(), currentFunction, startLabel);
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
                    if (dest == LatteType.Bool)
                        program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(false), dest));                
                    else
                        program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), dest));
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

        public override object Visit(IStructAssignmentNode node)
        {
            throw new Exception("Unexpected node here! At this point IStructAssignmentWithOffsetNode is expected instead of IStructAssignmentNode");
        }

        public override object Visit(IStructAssignmentWithOffsetNode node)
        {
            var objectAddr = exprGen.Visit(node.Object);
            var value = exprGen.Visit(node.Value);

            program.Emit(new StoreIndirectQuadruple(node.FilePlace, objectAddr, node.FieldOffset + 4, value));

            return null;
        }

        public override object Visit(IForEachNode node)
        {
            var blockStore = store.CopyForBlock();
            var newVisitor = new StatementGenerator(program, blockStore, currentFunction, startLabel);
            
            var arrayLength = newVisitor.exprGen.Visit(new ObjectFieldWithOffsetNode(node.FilePlace, node.Array, "length",
                -4 /* hack, because we add 4 because of vtable */));
            var addr = program.GetNextRegister();
            var m1 = program.GetNextRegister();
            var m4 = program.GetNextRegister();
            var indexMul4 = program.GetNextRegister();
            var indexMul4Plus4 = program.GetNextRegister();
            var result = program.GetNextRegister();
            var realAddr = program.GetNextRegister();

            
            var labelAfter = program.GetNextLabel();
            var labelBody = program.GetNextLabel();
            var labelCheck = program.GetNextLabel();

            int valueLoc = blockStore.Alloc(node.IteratorName);
            int iteratorLoc = blockStore.Alloc(node.IteratorName + "_____I_T_E_R_A_T_O_R");
            
            var m0 = program.GetNextRegister();
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), m0));
            program.Emit(new StoreQuadruple(node.FilePlace, iteratorLoc, m0));
            
            program.Emit(new JumpAlwaysQuadruple(node.FilePlace, labelCheck));
            program.Emit(new LabelQuadruple(node.FilePlace, labelBody));

            var index = program.GetNextRegister();
            program.Emit(new LoadQuadruple(node.FilePlace, iteratorLoc, index));
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(4), m4));
            program.Emit(new MulQuadruple(node.FilePlace, index, m4, indexMul4));
            program.Emit(new AddQuadruple(node.FilePlace, indexMul4, m4, indexMul4Plus4));
            addr = newVisitor.exprGen.Visit(node.Array);
            program.Emit(new AddQuadruple(node.FilePlace, addr, indexMul4Plus4, realAddr));
            program.Emit(new LoadIndirectQuadruple(node.FilePlace, realAddr, 0, result));            
            program.Emit(new StoreQuadruple(node.FilePlace, valueLoc, result));
            
            newVisitor.Visit(node.Body);

            index = program.GetNextRegister();
            var index2 = program.GetNextRegister();
            program.Emit(new LoadQuadruple(node.FilePlace, iteratorLoc, index));
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(1), m1));
            program.Emit(new AddQuadruple(node.FilePlace, m1, index, index2));
            program.Emit(new StoreQuadruple(node.FilePlace, iteratorLoc, index2));
            
            program.Emit(new LabelQuadruple(node.FilePlace, labelCheck));
            index = program.GetNextRegister();
            program.Emit(new LoadQuadruple(node.FilePlace, iteratorLoc, index));
            program.Emit(new CompareQuadruple(node.FilePlace, arrayLength, index));
            program.Emit(new JumpQuadruple(node.FilePlace, labelAfter, labelBody, RelOperator.Equals ));
            program.Emit(new LabelQuadruple(node.FilePlace, labelAfter));
            return null;
        }

        public override object Visit(IArrayAssignmentNode node)
        {
            var array = exprGen.Visit(node.Array);
            var index = exprGen.Visit(node.Index);
            var value = exprGen.Visit(node.Value);

            var m4 = program.GetNextRegister();
            var m1 = program.GetNextRegister();
            var offset = program.GetNextRegister();
            var offsetInBytes = program.GetNextRegister();
            var addr = program.GetNextRegister();
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(4), m4));
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(1), m1));
            program.Emit(new AddQuadruple(node.FilePlace, index, m1, offset));
            program.Emit(new MulQuadruple(node.FilePlace, offset, m4, offsetInBytes));
            program.Emit(new AddQuadruple(node.FilePlace, array, offsetInBytes, addr));
            program.Emit(new StoreIndirectQuadruple(node.FilePlace, addr, 0, value));

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

        public override object Visit(IStructIncrementNode node)
        {
            throw new Exception("Unexpected node here! At this point IStructIncrementWithOffsetNode is expected instead of IStructIncrementNode");
        }

        public override object Visit(IStructIncrementWithOffsetNode node)
        {
            var objectAddr = exprGen.Visit(node.Object);
            var curVal = program.GetNextRegister();
            var result = program.GetNextRegister();
            var m1 = program.GetNextRegister();
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(1), m1));
            program.Emit(new LoadIndirectQuadruple(node.FilePlace, objectAddr, node.FieldOffset + 4, curVal));
            program.Emit(new AddQuadruple(node.FilePlace, curVal, m1, result));
            program.Emit(new StoreIndirectQuadruple(node.FilePlace, objectAddr, node.FieldOffset + 4, result));

            return null;
        }

        public override object Visit(IStructDecrementNode node)
        {
            throw new Exception("Unexpected node here! At this point IStructDecrementWithOffsetNode is expected instead of IStructDecrementNode");
        }

        public override object Visit(IStructDecrementWithOffsetNode node)
        {
            var objectAddr = exprGen.Visit(node.Object);
            var curVal = program.GetNextRegister();
            var result = program.GetNextRegister();
            var m1 = program.GetNextRegister();
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(-1), m1));
            program.Emit(new LoadIndirectQuadruple(node.FilePlace, objectAddr, node.FieldOffset + 4, curVal));
            program.Emit(new AddQuadruple(node.FilePlace, curVal, m1, result));
            program.Emit(new StoreIndirectQuadruple(node.FilePlace, objectAddr, node.FieldOffset + 4, result));

            return null;
        }

        public override object Visit(IReturnNode node)
        {
            var functionCall = node.ReturnExpression as IFunctionCallNode;
            if (functionCall != null && functionCall.FunctionName == currentFunction.Name)
            { // tail call optimization
                var argumentValues = functionCall.Arguments.Select(exprGen.Visit).ToList();

                foreach (var arg in currentFunction.Arguments.Zip(argumentValues, (arg, val) => new KeyValuePair<string, IRegister>(arg.Name, val)))
                {
                    program.Emit(new StoreQuadruple(node.FilePlace, store.Get(arg.Key), arg.Value));
                }
                
                program.Emit(new JumpAlwaysQuadruple(node.FilePlace, startLabel));
            }
            else
            {
                var registerWithValue = exprGen.Visit(node.ReturnExpression);
                program.Emit(new ReturnQuadruple(node.FilePlace, registerWithValue));
            }
            
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
            var statementLabel = program.GetNextLabel();
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), zeroReg));
            
            program.Emit(new CompareQuadruple(node.FilePlace, condExpr, zeroReg));

            program.Emit(new JumpQuadruple(node.FilePlace, afterIfLabel, statementLabel,RelOperator.Equals));
            
            program.Emit(new LabelQuadruple(node.FilePlace, statementLabel));
            
            Visit(node.Statement);
            
            program.Emit(new LabelQuadruple(node.FilePlace, afterIfLabel));

            return null;
        }

        public override object Visit(IIfElseNode node)
        {
            var condExpr = exprGen.Visit(node.Condition);
            var zeroReg = program.GetNextRegister();
            
            var afterIfLabel = program.GetNextLabel();
            var statementLabel = program.GetNextLabel();
            var elseLabel = program.GetNextLabel();
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), zeroReg));
            
            program.Emit(new CompareQuadruple(node.FilePlace, condExpr, zeroReg));

            program.Emit(new JumpQuadruple(node.FilePlace, elseLabel, statementLabel, RelOperator.Equals));
            
            program.Emit(new LabelQuadruple(node.FilePlace, statementLabel));
            
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
            var outsideLabel = program.GetNextLabel();
            var conditionLabel = program.GetNextLabel();
            
            program.Emit(new JumpAlwaysQuadruple(node.FilePlace, conditionLabel));
            
            program.Emit(new LabelQuadruple(node.FilePlace, bodyLabel));

            Visit(node.Statement);
            
            program.Emit(new LabelQuadruple(node.FilePlace, conditionLabel));
            
            var condExpr = exprGen.Visit(node.Condition);
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), zeroReg));
            program.Emit(new CompareQuadruple(node.FilePlace, condExpr, zeroReg));

            program.Emit(new JumpQuadruple(node.FilePlace, bodyLabel, outsideLabel, RelOperator.NotEquals));
            
            program.Emit(new LabelQuadruple(node.FilePlace, outsideLabel));
            
            return null;
        }

        public override object Visit(IExpressionStatementNode node)
        {
            exprGen.Visit(node.Expression);
            return null;
        }
    }
}