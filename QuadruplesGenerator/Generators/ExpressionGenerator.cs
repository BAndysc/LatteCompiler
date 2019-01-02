using System;
using System.Linq;
using LatteBase.AST;
using LatteBase.Visitors;
using QuadruplesCommon;
using QuadruplesCommon.Quadruples;

namespace QuadruplesGenerator.Generators
{
    public class ExpressionGenerator : ExpressionVisitor<IRegister>
    {
        private readonly QuadruplesProgram program;
        private readonly IStore store;

        public ExpressionGenerator(QuadruplesProgram program, IStore store)
        {
            this.program = program;
            this.store = store;
        }
        
        public override IRegister Visit(IIntNode node)
        {
            var register = program.GetNextRegister();
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(node.Value), register));
            return register;
        }

        public override IRegister Visit(ITrueNode node)
        {
            var register = program.GetNextRegister();
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(true), register));
            return register;
        }

        public override IRegister Visit(IFalseNode node)
        {
            var register = program.GetNextRegister();
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(false), register));
            return register;
        }

        public override IRegister Visit(IStringNode node)
        {
            var register = program.GetNextRegister();
            program.Emit(new LoadLabelPtrQuadruple(node.FilePlace, program.AllocString(node.Text), register));
            return register;
        }

        public override IRegister Visit(IVariableNode node)
        {
            var loc = store.Get(node.Variable);
            var register = program.GetNextRegister();

            program.Emit(new LoadQuadruple(node.FilePlace, loc, register));
            return register;
        }

        public override IRegister Visit(INegateNode node)
        {
            throw new System.NotImplementedException();
        }

        public override IRegister Visit(IAndNode node)
        {
            throw new System.NotImplementedException();
        }

        public override IRegister Visit(IOrNode node)
        {
            throw new System.NotImplementedException();
        }

        public override IRegister Visit(IBinaryNode node)
        {
            var register = program.GetNextRegister();

            var left = Visit(node.Left);
            var right = Visit(node.Right);
            
            switch (node.Operator)
            {
                case BinaryOperator.Add:
                    program.Emit(new AddQuadruple(node.FilePlace, left, right, register));
                    break;
                case BinaryOperator.Sub:
                    program.Emit(new SubQuadruple(node.FilePlace, left, right, register));
                    break;
                case BinaryOperator.Mul:
                    program.Emit(new MulQuadruple(node.FilePlace, left, right, register));
                    break;
                case BinaryOperator.Div:
                    program.Emit(new DivQuadruple(node.FilePlace, left, right, register));
                    break;
                case BinaryOperator.Mod:
                    program.Emit(new ModQuadruple(node.FilePlace, left, right, register));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return register;
        }

        public override IRegister Visit(ICompareNode node)
        {
            var register = program.GetNextRegister();

            var left = Visit(node.Left);
            var right = Visit(node.Right);

            program.Emit(new CompareQuadruple(node.FilePlace, left, right));
            
            program.Emit(new SetIfQuadruple(node.FilePlace, node.Operator, register));

            return register;
        }

        public override IRegister Visit(IFunctionCallNode node)
        {
            var result = program.GetNextRegister();
            var args = node.Arguments.Select(Visit).ToList();
            program.Emit(new FunctionCallQuadruple(node.FilePlace, node.FunctionName, result, args));
            return result;
        }
    }
}