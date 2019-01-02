using System;
using System.Linq;
using LatteBase.AST;
using QuadruplesCommon;
using QuadruplesCommon.Quadruples;
using QuadruplesGenerator.RegisterAllocators;

namespace CLI
{
    public class X86Generator : QuadrupleVisitor<object>
    {
        private readonly IRegisterAllocation mapping;

        public X86Generator(IRegisterAllocation mapping)
        {
            this.mapping = mapping;
        }

        private void Emit(string asm, QuadrupleBase quad)
        {
            EmitLabel("    " + asm, quad);
        }
        
        
        private void EmitLabel(string asm, QuadrupleBase quad)
        {
            Console.Write($"{asm}");

            for (int i = 0; i < 50 - asm.Length; ++i)
                Console.Write(" ");
            
            Console.WriteLine($"; {quad.FilePlace.Text.Split('\n')[0]}");
        }
        
        public override object Visit(AddQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit($"mov {dest}, {a}", quadruple);
            Emit($"add {dest}, {b}", quadruple);

            return null;
        }

        public override object Visit(SubQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit($"mov {dest}, {a}", quadruple);
            Emit($"sub {dest}, {b}", quadruple);

            return null;
        }

        public override object Visit(MulQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            if (dest == X86Register.EAX)
                Emit($"push eax", quadruple);
            Emit($"mov eax, {a}", quadruple);
            Emit($"mul {b}", quadruple);
            if (dest == X86Register.EAX)
            {
                Emit($"mov {dest}, eax", quadruple);
                Emit($"pop eax", quadruple);
            }

            return null;
        }

        public override object Visit(DivQuadruple quadruple)
        {
            throw new NotImplementedException();
        }

        public override object Visit(ModQuadruple quadruple)
        {
            throw new NotImplementedException();
        }

        public override object Visit(ImmediateValueQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            Emit($"mov {dest}, {quadruple.Value}", quadruple);

            return null;
        }

        public override object Visit(LoadQuadruple quadruple)
        {
            var dest = mapping.Get(quadruple.ResultRegister);
            Emit($"mov {dest}, [ebp - {4 * (quadruple.Local+1)}]", quadruple);

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
            Emit("pop ebx", quadruple);
            Emit($"ret", quadruple);

            return null;
        }
        
        public override object Visit(ReturnVoidQuadruple quadruple)
        { 
            Emit($"leave", quadruple);
            Emit("pop ebx", quadruple);
            Emit($"ret", quadruple);

            return null;
        }

        public override object Visit(StoreQuadruple quadruple)
        {
            var value = mapping.Get(quadruple.Value);
            Emit($"mov [ebp - {4 * (quadruple.Local+1)}], {value}", quadruple);

            return null;
        }

        public override object Visit(FunctionCallQuadruple quadruple)
        {
            // todo: optimize
            
            if (!mapping.IsAllocated(quadruple.ResultRegister) || mapping.Get(quadruple.ResultRegister)!= X86Register.EAX)
                Emit($"push EAX", quadruple);

            if (!mapping.IsAllocated(quadruple.ResultRegister) || mapping.Get(quadruple.ResultRegister)!= X86Register.ECX)
                Emit($"push ECX", quadruple);
            
            if (!mapping.IsAllocated(quadruple.ResultRegister) || mapping.Get(quadruple.ResultRegister)!= X86Register.EDX)
                Emit($"push EDX", quadruple);
            
            foreach (var arg in quadruple.Arguments.Reverse())
            {
                Emit($"push {mapping.Get(arg)}", quadruple);
            }
            
            Emit($"call {quadruple.FunctionName}", quadruple);
            
            if (mapping.IsAllocated(quadruple.ResultRegister) && mapping.Get(quadruple.ResultRegister)!= X86Register.EAX)
                Emit($"mov {mapping.Get(quadruple.ResultRegister)}, eax", quadruple);

            if (!mapping.IsAllocated(quadruple.ResultRegister) || mapping.Get(quadruple.ResultRegister)!= X86Register.EDX)
                Emit($"pop EDX", quadruple);
   
            if (!mapping.IsAllocated(quadruple.ResultRegister) || mapping.Get(quadruple.ResultRegister)!= X86Register.ECX)
                Emit($"pop ECX", quadruple);
    
            if (!mapping.IsAllocated(quadruple.ResultRegister) || mapping.Get(quadruple.ResultRegister)!= X86Register.EAX)
                Emit($"pop EAX", quadruple);
            return null;
        }

        public override object Visit(CompareQuadruple quadruple)
        {
            Emit($"cmp {mapping.Get(quadruple.RegValue)}, {mapping.Get(quadruple.CompareTo)}", quadruple);
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

            return null;
        }

        public override object Visit(SetIfQuadruple quadruple)
        {
            if (mapping.Get(quadruple.Destination)!= X86Register.ECX)
                Emit($"push ecx", quadruple);
            
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

            if (mapping.Get(quadruple.Destination)!= X86Register.ECX)
            {
                Emit($"movzx {mapping.Get(quadruple.Destination)}, cl", quadruple);            
                Emit($"pop ecx", quadruple);
            }
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
            Emit($"mov {mapping.Get(quadruple.ResultRegister)}, {quadruple.LabelToLoad}", quadruple);
            return null;
        }

        public override object Visit(FuncDefQuadruple quadruple)
        {
            EmitLabel($"{quadruple.FunctionName}: ", quadruple);
            Emit($"push ebx", quadruple);
            Emit($"push ebp", quadruple);
            Emit($"mov ebp, esp", quadruple);

            return null;
        }
    }
}