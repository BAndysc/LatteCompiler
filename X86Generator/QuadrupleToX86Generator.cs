using System;
using System.Linq;
using System.Text;
using LatteBase.AST;
using QuadruplesCommon;
using QuadruplesCommon.Quadruples;

namespace X86Generator
{
    public class QuadrupleToX86Generator : QuadrupleVisitor<object>
    {
        private readonly StringBuilder builder;
        private readonly IRegisterAllocation mapping;
        private readonly int regsMaxUsedRegisters;

        public QuadrupleToX86Generator(StringBuilder builder, IRegisterAllocation mapping, int regsMaxUsedRegisters)
        {
            this.builder = builder;
            this.mapping = mapping;
            this.regsMaxUsedRegisters = regsMaxUsedRegisters;
        }

        private void Emit(string asm, QuadrupleBase quad)
        {
            EmitLabel("    " + asm, quad);
        }
        
        
        private void EmitLabel(string asm, QuadrupleBase quad)
        {
            builder.Append($"{asm}");

            for (int i = 0; i < 50 - asm.Length; ++i)
                builder.Append(" ");
            
            builder.AppendLine($"; {quad.FilePlace.Text.Split('\n')[0]} ; {quad}");
        }
        
        public override object Visit(AddQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit($"mov dword eax, {a}", quadruple);
            Emit($"add eax, {b}", quadruple);
            Emit($"mov {dest}, eax", quadruple);

            return null;
        }
        
        public override object Visit(NegateQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.Value);
            Emit($"mov dword eax, {a}", quadruple);
            Emit($"neg eax", quadruple);
            Emit($"mov {dest}, eax", quadruple);

            return null;
        }
        
        public override object Visit(LogicalNegateQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.Value);
            Emit($"cmp dword {a}, 0", quadruple);
            Emit($"sete al", quadruple);
            Emit($"movzx eax, al", quadruple);
            Emit($"mov {dest}, eax", quadruple);

            return null;
        }
        
        public override object Visit(SubQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit($"mov dword eax, {a}", quadruple);
            Emit($"sub eax, {b}", quadruple);
            Emit($"mov {dest}, eax", quadruple);

            return null;
        }

        public override object Visit(MulQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            
            Emit($"mov dword eax, {a}", quadruple);
            Emit($"mul dword {b}", quadruple);
            Emit($"mov {dest}, eax", quadruple);

            return null;
        }

        public override object Visit(DivQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);

            Emit($"mov dword eax, {a}", quadruple);
            Emit($"cdq", quadruple);
            Emit($"idiv dword {b}", quadruple);
            Emit($"mov {dest}, eax", quadruple);
            
            return null;
        }

        public override object Visit(ModQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit($"mov dword eax, {a}", quadruple);
            Emit($"cdq", quadruple);
            Emit($"idiv dword {b}", quadruple);
            Emit($"mov {dest}, edx", quadruple);
            return null;
        }

        public override object Visit(ConcatQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit($"push dword {b}", quadruple);
            Emit($"push dword {a}", quadruple);
            Emit($"call concat_string", quadruple);
            Emit($"mov {dest}, eax", quadruple);
            Emit($"add esp, 8", quadruple);

            return null;
        }
        
        public override object Visit(ImmediateValueQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            Emit($"mov dword {dest}, {quadruple.Value}", quadruple);

            return null;
        }

        public override object Visit(LoadQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            Emit($"mov eax, [ebp - {4 * (quadruple.Local+1)}]", quadruple);
            Emit($"mov {dest}, eax", quadruple);

            return null;
        }

        public override object Visit(LocalQuadruple quadruple)
        {
            Emit($"sub esp, 4", quadruple);
            return null;
        }

        public override object Visit(ReturnQuadruple quadruple)
        { 
            var value = mapping.Get(quadruple.ValueRegister);
            Emit($"mov eax, {value}", quadruple);
            Emit($"leave", quadruple);
            Emit($"ret", quadruple);

            return null;
        }
        
        public override object Visit(ReturnVoidQuadruple quadruple)
        { 
            Emit($"leave", quadruple);
            Emit($"ret", quadruple);

            return null;
        }

        public override object Visit(StoreQuadruple quadruple)
        {
            var value = mapping.Get(quadruple.Value);
            Emit($"mov dword eax, {value}", quadruple);
            Emit($"mov [ebp - {4 * (quadruple.Local+1)}], eax", quadruple);

            return null;
        }
        
        public override object Visit(FunctionCallQuadruple quadruple)
        {
            foreach (var arg in quadruple.Arguments.Reverse())
                Emit($"push dword {mapping.Get(arg)}", quadruple);
            
            Emit($"call {quadruple.FunctionName}", quadruple);
            
            if (mapping.IsAllocated(quadruple.ResultRegister) && mapping.Get(quadruple.ResultRegister)!= X86Register.EAX)
                Emit($"mov {mapping.Get(quadruple.ResultRegister)}, eax", quadruple);

            return null;
        }

        public override object Visit(CompareQuadruple quadruple)
        {
            Emit($"mov dword eax, {mapping.Get(quadruple.CompareTo)}", quadruple);
            Emit($"cmp {mapping.Get(quadruple.RegValue)}, eax", quadruple);
            return null;
        }

        public override object Visit(JumpQuadruple quadruple)
        {
            switch (quadruple.Operator)
            {
                case RelOperator.LessThan:
                    throw new ArgumentOutOfRangeException();
                    break;
                case RelOperator.LessEquals:
                    throw new ArgumentOutOfRangeException();
                    break;
                case RelOperator.GreaterThan:
                    throw new ArgumentOutOfRangeException();
                    break;
                case RelOperator.GreaterEquals:
                    throw new ArgumentOutOfRangeException();
                    break;
                case RelOperator.Equals:
                    Emit($"je {quadruple.Destination}", quadruple);
                    break;
                case RelOperator.NotEquals:
                    Emit($"jne {quadruple.Destination}", quadruple);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Emit($"jmp {quadruple.Else}", quadruple);

            return null;
        }

        public override object Visit(SetIfQuadruple quadruple)
        {
            switch (quadruple.Operator)
            {
                case RelOperator.LessThan:
                    Emit($"setl cl", quadruple);
                    break;
                case RelOperator.LessEquals:
                    Emit($"setle cl", quadruple);
                    break;
                case RelOperator.GreaterThan:
                    Emit($"setg cl", quadruple);
                    break;
                case RelOperator.GreaterEquals:
                    Emit($"setge cl", quadruple);
                    break;
                case RelOperator.Equals:
                    Emit($"sete cl", quadruple);
                    break;
                case RelOperator.NotEquals:
                    Emit($"setne cl", quadruple);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Emit($"and ecx, 1", quadruple);
            
            Emit($"mov dword {mapping.Get(quadruple.Destination)}, ecx", quadruple);
            return null;
        }

        public override object Visit(LabelQuadruple quadruple)
        {
            EmitLabel($"{quadruple.Label}:", quadruple);
            return null;
        }

        public override object Visit(JumpAlwaysQuadruple quadruple)
        {
            Emit($"jmp {quadruple.Destination}", quadruple);
            return null;
        }

        public override object Visit(LoadLabelPtrQuadruple quadruple)
        {
            Emit($"mov dword {mapping.Get(quadruple.ResultRegister)}, {quadruple.LabelToLoad}", quadruple);
            return null;
        }

        public override object Visit(FuncDefQuadruple quadruple)
        {
            EmitLabel($"{quadruple.FunctionName}: ", quadruple);
            Emit($"push ebp", quadruple);
            Emit($"mov ebp, esp", quadruple);
            Emit($"sub esp, {regsMaxUsedRegisters * 4}", quadruple);
            return null;
        }

        public override object Visit(LoadArgumentQuadruple quadruple)
        {
            Emit($"mov eax, [ebp + {4 * (quadruple.argumentIndex + 2)}]", quadruple);
            Emit($"mov [ebp - {4 * (quadruple.localIndex + 1)}], eax", quadruple);

            return null;
        }
    }
}