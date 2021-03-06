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
        private readonly QuadruplesProgram program;
        private readonly IRegisterAllocation<IOperand> mapping;
        private readonly int regsMaxUsedRegisters;
        private readonly List<IX86Instruction> instructions = new List<IX86Instruction>();
        private readonly bool UseVTable;

        public QuadrupleToX86Generator(QuadruplesProgram program, IRegisterAllocation<IOperand> mapping, int regsMaxUsedRegisters, bool useVTable)
        {
            this.program = program;
            this.mapping = mapping;
            this.regsMaxUsedRegisters = regsMaxUsedRegisters;
            this.UseVTable = useVTable;
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
            Emit(new MovInstruction(Register32.EAX, (dynamic)a), quadruple);
            Emit(new AddInstruction(Register32.EAX, (dynamic)b), quadruple);
            Emit(new MovInstruction((dynamic)dest, Register32.EAX), quadruple);

            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(NegateQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.Value);
            if (dest == a)
                Emit(new NegateInstruction((dynamic)a), quadruple);
            else
            {
                Emit(new MovInstruction(Register32.EAX, (dynamic)a), quadruple);
                Emit(new NegateInstruction(Register32.EAX), quadruple);
                Emit(new MovInstruction((dynamic)dest, Register32.EAX), quadruple);
            }

            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(LogicalNegateQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.Value);
            if (mapping.IsIntConst(quadruple.Value))
            {
                if ((a as ImmediateValue32).Value == 0)
                    Emit(new MovInstruction((dynamic)dest, new ImmediateValue32(1)), quadruple);
                else
                    Emit(new MovInstruction((dynamic)dest, new ImmediateValue32(0)), quadruple);
            }
            else
            {
                Emit(new CompareInstruction((dynamic)a, new ImmediateValue32(0)), quadruple);
                Emit(new SetEInstruction(Register8.AL), quadruple);
                Emit(new MovzxInstruction(Register32.EAX, Register8.AL), quadruple);
                Emit(new MovInstruction((dynamic)dest, Register32.EAX), quadruple);
            }

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(SubQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit(new MovInstruction(Register32.EAX, (dynamic)a), quadruple);
            Emit(new SubInstruction(Register32.EAX, (dynamic)b), quadruple);
            Emit(new MovInstruction((dynamic)dest, Register32.EAX), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(MulQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            Emit(new MovInstruction(Register32.EAX, (dynamic)a), quadruple);
            if (mapping.IsIntConst(quadruple.RegisterB))
            {
                Emit(new MovInstruction(Register32.EBX, (dynamic)b), quadruple);
                Emit(new MulInstruction(Register32.EBX), quadruple);
            }
            else
                Emit(new MulInstruction((dynamic)b), quadruple);
            Emit(new MovInstruction((dynamic)dest, Register32.EAX), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(DivQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);

            Emit(new MovInstruction(Register32.EAX, (dynamic)a), quadruple);
            Emit(new CdqInstruction(), quadruple);
            if (mapping.IsIntConst(quadruple.RegisterB))
            {
                Emit(new MovInstruction(Register32.EBX, (dynamic)b), quadruple);
                Emit(new SignedDivInstruction(Register32.EBX), quadruple);
            }
            else
            {
                Emit(new SignedDivInstruction((dynamic)b), quadruple);
            }
            Emit(new MovInstruction((dynamic)dest, Register32.EAX), quadruple);
            
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(ModQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);


            
            Emit(new MovInstruction(Register32.EAX, (dynamic)a), quadruple);
            Emit(new CdqInstruction(), quadruple);
            if (mapping.IsIntConst(quadruple.RegisterB))
            {
                Emit(new MovInstruction(Register32.EBX, (dynamic)b), quadruple);
                Emit(new SignedDivInstruction(Register32.EBX), quadruple);
            }
            else
            {
                Emit(new SignedDivInstruction((dynamic)b), quadruple);
            }
            Emit(new MovInstruction((dynamic)dest, Register32.EDX), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(ConcatQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            var a = mapping.Get(quadruple.RegisterA);
            var b = mapping.Get(quadruple.RegisterB);
            //alignment
            Emit(new SubInstruction(Register32.ESP, new ImmediateValue32(4 * 2)), quadruple);
            Emit(new PushInstruction((dynamic)b), quadruple);
            Emit(new PushInstruction((dynamic)a), quadruple);
            Emit(new CallInstruction(new X86Label("concat_string")), quadruple);
            Emit(new MovInstruction((dynamic)dest, Register32.EAX), quadruple);
            Emit(new AddInstruction(Register32.ESP, new ImmediateValue32(4 * 4)), quadruple);

            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(ImmediateValueQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            if (!mapping.IsIntConst(quadruple.ResultRegister))
                Emit(new MovInstruction((dynamic)dest, new ImmediateValue32(quadruple.Value.AsInt)), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(LoadQuadruple quadruple)
        {
            Clear();
            var dest = mapping.Get(quadruple.ResultRegister);
            Emit(new MovInstruction(Register32.EAX, new Memory32(Register32.EBP, -4 * (quadruple.Local+1))), quadruple);
            Emit(new MovInstruction((dynamic)dest, Register32.EAX), quadruple);

            return instructions.ToList();
        }

        
        public override IEnumerable<IX86Instruction> Visit(LoadIndirectQuadruple quadruple)
        {
            Clear();
            var addr = mapping.Get(quadruple.Address);
            var offsetReg = quadruple.OffsetReg == null ? null : mapping.Get(quadruple.OffsetReg);
            var dest = mapping.Get(quadruple.ResultRegister);
            Emit(new MovInstruction(Register32.EAX, (dynamic)addr), quadruple);
            if (offsetReg == null)
                Emit(new MovInstruction(Register32.EAX, new Memory32(Register32.EAX, quadruple.Offset)),quadruple);
            else
            {
                Emit(new MovInstruction(Register32.ECX, (dynamic)offsetReg), quadruple);
                Emit(new MovInstruction(Register32.EAX, new Memory32(Register32.EAX, quadruple.Offset, Register32.ECX, quadruple.OffsetRegMul)), quadruple);
            }
            Emit(new MovInstruction((dynamic)dest, Register32.EAX), quadruple);
            
            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(LocalQuadruple quadruple)
        {
            Clear();
            //Emit(new SubInstruction(Register32.ESP, new ImmediateValue32(4)), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(ReturnQuadruple quadruple)
        { 
            Clear();
            var value = mapping.Get(quadruple.ValueRegister);
            Emit(new MovInstruction(Register32.EAX, (dynamic)value), quadruple);
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
            Emit(new MovInstruction(Register32.EAX, (dynamic)value), quadruple);
            Emit(new MovInstruction(new Memory32(Register32.EBP, -4 * (quadruple.Local + 1)), Register32.EAX), quadruple);

            return instructions.ToList();
        }
        
        public override IEnumerable<IX86Instruction> Visit(StoreIndirectQuadruple quadruple)
        {
            Clear();
            var value = mapping.Get(quadruple.Value);
            var offset = quadruple.OffsetReg == null ? null : mapping.Get(quadruple.OffsetReg);
            var addr = mapping.Get(quadruple.ObjectAddr);
            Emit(new MovInstruction(Register32.EDX, (dynamic)addr), quadruple);
            Emit(new MovInstruction(Register32.EAX, (dynamic)value), quadruple);
            if (offset == null)
                Emit(new MovInstruction(new Memory32(Register32.EDX, quadruple.Offset), Register32.EAX), quadruple);
            else
            {
                Emit(new MovInstruction(Register32.ECX, (dynamic)offset), quadruple);   
                Emit(new MovInstruction(new Memory32(Register32.EDX, quadruple.Offset, Register32.ECX, quadruple.OffsetRegMul), Register32.EAX), quadruple);
            }
            
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(FunctionCallQuadruple quadruple)
        {
            Clear();
            int argsCount = quadruple.Arguments.Count();
            int alignment = (4 - (argsCount % 4)) % 4;
            if (alignment > 0)  
               Emit(new SubInstruction(Register32.ESP, new ImmediateValue32(4 * alignment)), quadruple);
            foreach (var arg in quadruple.Arguments.Reverse())
            {
                var value = mapping.Get(arg);
                Emit(new PushInstruction((dynamic)value), quadruple);
            }

            Emit(new CallInstruction(new X86Label(quadruple.FunctionName)), quadruple);

            Emit(new AddInstruction(Register32.ESP, new ImmediateValue32(4 * (alignment + argsCount))), quadruple);
                        
            if (mapping.IsAllocated(quadruple.ResultRegister))
                Emit(new MovInstruction((dynamic)mapping.Get(quadruple.ResultRegister), Register32.EAX), quadruple);

            return instructions.ToList();
        }

        
        public override IEnumerable<IX86Instruction> Visit(VirtualCallQuadruple quadruple)
        {
            Clear();
            int argsCount = quadruple.Arguments.Count();
            int alignment = (4 - (argsCount % 4)) % 4;
            
            Emit(new MovInstruction(Register32.EAX, (dynamic)mapping.Get(quadruple.This)), quadruple); // EAX = this
            Emit(new MovInstruction(Register32.EAX, new Memory32(Register32.EAX, 0)), quadruple); // EAX = vtable ptr 
            Emit(new MovInstruction(Register32.EAX, new Memory32(Register32.EAX, quadruple.MethodOffset)), quadruple);
            
            if (alignment > 0)  
                Emit(new SubInstruction(Register32.ESP, new ImmediateValue32(4 * alignment)), quadruple);
            foreach (var arg in quadruple.Arguments.Reverse())
            {
                var value = mapping.Get(arg);
                Emit(new PushInstruction((dynamic)value), quadruple);
            }

            Emit(new CallInstruction(Register32.EAX), quadruple);

            Emit(new AddInstruction(Register32.ESP, new ImmediateValue32(4 * (alignment + argsCount))), quadruple);
                        
            if (mapping.IsAllocated(quadruple.ResultRegister))
                Emit(new MovInstruction((dynamic)mapping.Get(quadruple.ResultRegister), Register32.EAX), quadruple);

            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(InitVtableQuadruple quadruple)
        {
            Clear();

            var @class = program.GetClass(quadruple.ObjectType.Name);

            if (@class.VTable == null)
                return instructions.ToList();
            
            var vTable = new X86Label(@class.VTable.Text);
            
            Emit(new MovInstruction(Register32.EAX, (dynamic)mapping.Get(quadruple.Addr)), quadruple);
            Emit(new MovInstruction(new Memory32(Register32.EAX, 0), new ImmediateValue32(vTable)), quadruple);
            
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(CompareQuadruple quadruple)
        {
            Clear();
            var a = mapping.Get(quadruple.RegValue);
            var b = mapping.Get(quadruple.CompareTo);
            Emit(new MovInstruction(Register32.EAX, (dynamic)b), quadruple);
            if (mapping.IsIntConst(quadruple.RegValue))
            {
                Emit(new MovInstruction(Register32.EBX, (dynamic)a), quadruple);
                Emit(new CompareInstruction(Register32.EBX, Register32.EAX), quadruple);
            }
            else
                Emit(new CompareInstruction((dynamic)a, Register32.EAX), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(JumpQuadruple quadruple)
        {
            Clear();
            switch (quadruple.Operator)
            {
                case RelOperator.LessThan:
                    throw new ArgumentOutOfRangeException();
                case RelOperator.LessEquals:
                    throw new ArgumentOutOfRangeException();
                case RelOperator.GreaterThan:
                    throw new ArgumentOutOfRangeException();
                case RelOperator.GreaterEquals:
                    throw new ArgumentOutOfRangeException();
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
            Emit(new MovInstruction((dynamic)dest, Register32.ECX), quadruple);
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
            Emit(new MovInstruction((dynamic)dest, new ImmediateValue32(new X86Label(quadruple.LabelToLoad.Text))), quadruple);
            return instructions.ToList();
        }

        public override IEnumerable<IX86Instruction> Visit(FuncDefQuadruple quadruple)
        {
            Clear();
            Emit(new LabelInstruction(new X86Label(quadruple.FunctionName)), quadruple);
            
            Emit(new PushInstruction(Register32.EBP), quadruple);
            Emit(new MovInstruction(Register32.EBP, Register32.ESP), quadruple);
            // alignment to 16 bytes
            int locals = regsMaxUsedRegisters + (4 - (regsMaxUsedRegisters + 2) % 4) % 4;
            Emit(new SubInstruction(Register32.ESP, new ImmediateValue32(locals * 4)), quadruple);
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