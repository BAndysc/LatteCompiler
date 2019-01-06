using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LatteBase.AST;
using QuadruplesCommon;
using QuadruplesCommon.Quadruples;
using X86Assembly;
using X86Assembly.Instructions;
using X86Assembly.Operands;

namespace X86Generator
{
    public class QuadrupleToX86Generator : QuadrupleVisitor<IEnumerable<IX86Instruction>>
    {
        private readonly IRegisterAllocation<Memory32> mapping;
        private readonly int regsMaxUsedRegisters;
        private readonly List<IX86Instruction> instructions = new List<IX86Instruction>();

        public QuadrupleToX86Generator(IRegisterAllocation<Memory32> mapping, int regsMaxUsedRegisters)
        {
            this.mapping = mapping;
            this.regsMaxUsedRegisters = regsMaxUsedRegisters;
        }

        private void Clear()
        {
            instructions.Clear();
        }
        
        private void Emit(IX86Instruction instruction, QuadrupleBase quad)
        {
            instructions.Add(instruction);
        }
        
        public override IEnumerable<IX86Instruction> Visit(AddQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit(new MovInstruction(Register32.EAX, a), quadruple);
            Emit(new AddInstruction(Register32.EAX, b), quadruple);
            Emit(new MovInstruction(dest, Register32.EAX), quadruple);

            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(NegateQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.Value);
            if (dest == a)
                Emit(new NegateInstruction(a), quadruple);
            else
            {
                Emit(new MovInstruction(Register32.EAX, a), quadruple);
                Emit(new NegateInstruction(Register32.EAX), quadruple);
                Emit(new MovInstruction(dest, Register32.EAX), quadruple);
            }

            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(LogicalNegateQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.Value);
            Emit(new CompareInstruction(a, new ImmediateValue32(0)), quadruple);
            Emit(new SetEInstruction(Register8.AL), quadruple);
            Emit(new MovzxInstruction(Register32.EAX, Register8.AL), quadruple);
            Emit(new MovInstruction(dest, Register32.EAX), quadruple);

            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(SubQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit(new MovInstruction(Register32.EAX, a), quadruple);
            Emit(new SubInstruction(Register32.EAX, b), quadruple);
            Emit(new MovInstruction(dest, Register32.EAX), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(MulQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit(new MovInstruction(Register32.EAX, a), quadruple);
            Emit(new MulInstruction(b), quadruple);
            Emit(new MovInstruction(dest, Register32.EAX), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(DivQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);

            Emit(new MovInstruction(Register32.EAX, a), quadruple);
            Emit(new CdqInstruction(), quadruple);
            Emit(new SignedDivInstruction(b), quadruple);
            Emit(new MovInstruction(dest, Register32.EAX), quadruple);
            
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(ModQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            
            
            Emit(new MovInstruction(Register32.EAX, a), quadruple);
            Emit(new CdqInstruction(), quadruple);
            Emit(new SignedDivInstruction(b), quadruple);
            Emit(new MovInstruction(dest, Register32.EDX), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(ConcatQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit(new PushInstruction(b), quadruple);
            Emit(new PushInstruction(a), quadruple);
            Emit(new CallInstruction(new X86Label("concat_string")), quadruple);
            Emit(new MovInstruction(dest, Register32.EAX), quadruple);
            Emit(new AddInstruction(Register32.ESP, new ImmediateValue32(8)), quadruple);

            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(ImmediateValueQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            Emit(new MovInstruction(dest, new ImmediateValue32(quadruple.Value.AsInt)), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(LoadQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            Emit(new MovInstruction(Register32.EAX, new Memory32(Register32.EBP, -4 * (quadruple.Local+1))), quadruple);
            Emit(new MovInstruction(dest, Register32.EAX), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(LocalQuadruple quadruple)
        {
            Clear();
            Emit(new SubInstruction(Register32.ESP, new ImmediateValue32(4)), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(ReturnQuadruple quadruple)
        { 
            Clear();
            var value = mapping.Get(quadruple.ValueRegister);
            Emit(new MovInstruction(Register32.EAX, value), quadruple);
            Emit(new LeaveInstruction(), quadruple);
            Emit(new RetInstruction(), quadruple);

            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(ReturnVoidQuadruple quadruple)
        { 
            Clear();
            Emit(new LeaveInstruction(), quadruple);
            Emit(new RetInstruction(), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(StoreQuadruple quadruple)
        {
            Clear();
            var value = mapping.Get(quadruple.Value);
            Emit(new MovInstruction(Register32.EAX, value), quadruple);
            Emit(new MovInstruction(new Memory32(Register32.EBP, -4 * (quadruple.Local + 1)), Register32.EAX), quadruple);

            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(FunctionCallQuadruple quadruple)
        {
            Clear();
            foreach (var arg in quadruple.Arguments.Reverse())
            {
                var value = mapping.Get(arg);
                Emit(new PushInstruction(value), quadruple);
            }

            Emit(new CallInstruction(new X86Label(quadruple.FunctionName)), quadruple);
            
            if (mapping.IsAllocated(quadruple.ResultRegister))
                Emit(new MovInstruction(mapping.Get(quadruple.ResultRegister), Register32.EAX), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(CompareQuadruple quadruple)
        {
            Clear();
            var a = mapping.Get(quadruple.RegValue);
            var b = mapping.Get(quadruple.CompareTo);
            Emit(new MovInstruction(Register32.EAX, b), quadruple);
            Emit(new CompareInstruction(a, Register32.EAX), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(JumpQuadruple quadruple)
        {
            Clear();
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
                    Emit(new JeInstruction(new X86Label(quadruple.Destination.Text)), quadruple);
                    break;
                case RelOperator.NotEquals:
                    Emit(new JneInstruction(new X86Label(quadruple.Destination.Text)), quadruple);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Emit(new JmpInstruction(new X86Label(quadruple.Else.Text)), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(SetIfQuadruple quadruple)
        {
            Clear();
            switch (quadruple.Operator)
            {
                case RelOperator.LessThan:
                    Emit(new SetLInstruction(Register8.CL), quadruple);
                    break;
                case RelOperator.LessEquals:
                    Emit(new SetLeInstruction(Register8.CL), quadruple);
                    break;
                case RelOperator.GreaterThan:
                    Emit(new SetGInstruction(Register8.CL), quadruple);
                    break;
                case RelOperator.GreaterEquals:
                    Emit(new SetGeInstruction(Register8.CL), quadruple);
                    break;
                case RelOperator.Equals:
                    Emit(new SetEInstruction(Register8.CL), quadruple);
                    break;
                case RelOperator.NotEquals:
                    Emit(new SetNeInstruction(Register8.CL), quadruple);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var dest = mapping.Get(quadruple.Destination);
            
            Emit(new AndInstruction(Register32.ECX, new ImmediateValue32(1)), quadruple);
            Emit(new MovInstruction(dest, Register32.ECX), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(LabelQuadruple quadruple)
        {
            Clear();
            Emit(new LabelInstruction(new X86Label(quadruple.Label.Text)), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(JumpAlwaysQuadruple quadruple)
        {
            Clear();
            Emit(new JmpInstruction(new X86Label(quadruple.Destination.Text)), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(LoadLabelPtrQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            Emit(new MovInstruction(dest, new ImmediateValue32(new X86Label(quadruple.LabelToLoad.Text))), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(FuncDefQuadruple quadruple)
        {
            Clear();
            Emit(new LabelInstruction(new X86Label(quadruple.FunctionName)), quadruple);
            Emit(new PushInstruction(Register32.EBP), quadruple);
            Emit(new MovInstruction(Register32.EBP, Register32.ESP), quadruple);
            Emit(new SubInstruction(Register32.ESP, new ImmediateValue32(regsMaxUsedRegisters * 4)), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(LoadArgumentQuadruple quadruple)
        {
            Clear();
            Emit(new MovInstruction(Register32.EAX, new Memory32(Register32.EBP, 4 * (quadruple.argumentIndex + 2))), quadruple);
            Emit(new MovInstruction(new Memory32(Register32.EBP, -4 * (quadruple.localIndex + 1)), Register32.EAX), quadruple);

            return instructions.ToList();
        }
    }
}