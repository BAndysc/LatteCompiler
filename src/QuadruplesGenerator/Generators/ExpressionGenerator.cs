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
            var register = program.GetNextRegister();
            
            var expr = Visit(node.Expression);
            
            program.Emit(new NegateQuadruple(node.FilePlace, expr, register));

            return register;
        }

        public override IRegister Visit(ILogicalNegateNode node)
        {
            var register = program.GetNextRegister();
            
            var expr = Visit(node.Expression);
            
            program.Emit(new LogicalNegateQuadruple(node.FilePlace, expr, register));

            return register;
        }

        public override IRegister Visit(IAndNode node)
        {
            var register = program.GetNextRegister();
            var zero = program.GetNextRegister();

            var setfalse = program.GetNextLabel();
            var settrue = program.GetNextLabel();
            var checksecond = program.GetNextLabel();
            var afterset = program.GetNextLabel();
            
            
            var left = Visit(node.Left);
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(false), zero));
            program.Emit(new CompareQuadruple(node.FilePlace, left, zero));
            program.Emit(new JumpQuadruple(node.FilePlace, setfalse, checksecond, RelOperator.Equals));
            
            program.Emit(new LabelQuadruple(node.FilePlace, checksecond));
            
            var right = Visit(node.Right);
            
            var zero2 = program.GetNextRegister();
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(false), zero2));
            program.Emit(new CompareQuadruple(node.FilePlace, right, zero2));
            program.Emit(new JumpQuadruple(node.FilePlace, setfalse, settrue,RelOperator.Equals));
            
            program.Emit(new LabelQuadruple(node.FilePlace, settrue));
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(true), register));
            program.Emit(new JumpAlwaysQuadruple(node.FilePlace, afterset));
            
            program.Emit(new LabelQuadruple(node.FilePlace, setfalse));
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(false), register));
            
            program.Emit(new LabelQuadruple(node.FilePlace, afterset));
            return register;
        }

        public override IRegister Visit(IOrNode node)
        {
            var register = program.GetNextRegister();
            var zero = program.GetNextRegister();

            var secondcheck = program.GetNextLabel();
            var setfalse = program.GetNextLabel();
            var settrue = program.GetNextLabel();
            var afterset = program.GetNextLabel();
            
            
            var left = Visit(node.Left);
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(false), zero));
            program.Emit(new CompareQuadruple(node.FilePlace, left, zero));
            program.Emit(new JumpQuadruple(node.FilePlace, settrue, secondcheck, RelOperator.NotEquals));
            
            
            program.Emit(new LabelQuadruple(node.FilePlace, settrue));
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(true), register));
            program.Emit(new JumpAlwaysQuadruple(node.FilePlace, afterset));
            
            program.Emit(new LabelQuadruple(node.FilePlace, secondcheck));
            
            var right = Visit(node.Right);
            
            var zero2 = program.GetNextRegister();
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(false), zero2));
            program.Emit(new CompareQuadruple(node.FilePlace, right, zero2));
            program.Emit(new JumpQuadruple(node.FilePlace, setfalse, settrue, RelOperator.Equals));
            
            program.Emit(new LabelQuadruple(node.FilePlace, setfalse));
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectBoolValue(false), register));
            program.Emit(new JumpAlwaysQuadruple(node.FilePlace, afterset));
            
            program.Emit(new LabelQuadruple(node.FilePlace, afterset));
            return register;
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
                case BinaryOperator.Concat:
                    program.Emit(new ConcatQuadruple(node.FilePlace, left, right, register));
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

        public override IRegister Visit(IStringCompareNode node)
        {
            var register = program.GetNextRegister();

            var left = Visit(node.Left);
            var right = Visit(node.Right);
            
            program.Emit(new FunctionCallQuadruple(node.FilePlace, "lat_strcmp", register, new[]{left, right}));

            return register;
        }

        public override IRegister Visit(IFunctionCallNode node)
        {
            var result = program.GetNextRegister();
            var args = node.Arguments.Select(Visit).ToList();
            program.Emit(new FunctionCallQuadruple(node.FilePlace, node.FunctionName, result, args));
            return result;
        }

        public override IRegister Visit(IMethodCallNode node)
        {
            throw new Exception("At this point this node is not expected, use IMethodCallWithOffsetNode instead");
        }
        
        public override IRegister Visit(IMethodCallWithOffsetNode node)
        {
            var result = program.GetNextRegister();
            var args = node.Arguments.Select(Visit).ToList();
            var objectValue = Visit(node.Object);
            program.Emit(new VirtualCallQuadruple(node.FilePlace, node.MethodName, result, objectValue, node.MethodOffset, new []{objectValue}.Union(args)));
            return result;
        }
        public override IRegister Visit(INullNode node)
        {
            var register = program.GetNextRegister();

            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(0), register));
            
            return register;
        }

        public override IRegister Visit(INewObjectNode node)
        {
            var classDef = program.GetClass(node.Type.Name);
            var classSize = 0;
            var superClass = classDef;

            while (superClass != null)
            {
                classSize += superClass.FieldsSize.Aggregate(0, (sum, val) => sum + val);
                superClass = superClass.SuperClass;
            }

            classSize += 4; // place for vtable
            
            var registerWithSize = program.GetNextRegister();
            
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(classSize), registerWithSize));
            
            var register = program.GetNextRegister();
            program.Emit(new FunctionCallQuadruple(node.FilePlace, "lat_malloc", register, new []{registerWithSize}));
            program.Emit(new InitVtableQuadruple(node.FilePlace, register, node.Type));
            return register;
        }

        public override IRegister Visit(ICastExpressionNode node)
        {
            return Visit(node.Expression);
        }

        public override IRegister Visit(IObjectFieldNode node)
        {
            throw new Exception(
                "Unexpected node exception. At this point this node should be transformed to IObjectFieldWithOffsetNode");
        }

        public override IRegister Visit(IArrayAccessNode node)
        {
            var addr = Visit(node.Array);
            var index = Visit(node.Index);
            var result = program.GetNextRegister();
            
            program.Emit(new LoadIndirectQuadruple(node.FilePlace, addr, index, 4, 4, result));

            return result;
        }

        public override IRegister Visit(INewArrayNode node)
        {
            var size = Visit(node.Size);
            var m1 = program.GetNextRegister();
            var m4 = program.GetNextRegister();
            var realSize = program.GetNextRegister();
            var bytes = program.GetNextRegister();
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(1), m1));
            program.Emit(new AddQuadruple(node.FilePlace, size, m1, realSize));
            program.Emit(new ImmediateValueQuadruple(node.FilePlace, new DirectIntValue(4), m4));
            program.Emit(new MulQuadruple(node.FilePlace, realSize, m4, bytes));
            
            var register = program.GetNextRegister();
            program.Emit(new FunctionCallQuadruple(node.FilePlace, "lat_malloc", register, new []{bytes}));
            program.Emit(new StoreIndirectQuadruple(node.FilePlace, register, null, 0, 0, size));
            return register;
        }

        public override IRegister Visit(IObjectFieldWithOffsetNode node)
        {
            var addr = Visit(node.Object);
            var result = program.GetNextRegister();
            program.Emit(new LoadIndirectQuadruple(node.FilePlace, addr, null, 0, node.FieldOffset + 4, result));

            return result;
        }
    }
}