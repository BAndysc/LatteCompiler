using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LatteBase.AST;
using QuadruplesCommon;
using QuadruplesGenerator.RegisterAllocators;
using X86Assembly;
using X86Assembly.Instructions;
using X86Assembly.Operands;
using X86IntelAsm;
using X86Optimizer;

namespace X86Generator
{
    public class X86Compiler
    {
        public string Compile(QuadruplesProgram program)
        {
            List<IX86Instruction> instructions = new List<IX86Instruction>();
            
            instructions.Add(new SegmentMetaInstruction("data"));
            
            foreach (var str in program.ConstStrings)
                instructions.Add(new DataMetaInstruction(str.Key.Text, str.Value));

            bool hasVtable = false;
            
            foreach (var cls in program.Classes)
            {
                var vtableSize = cls.VtableSize();
                if (vtableSize > 0)
                {
                    cls.VTable = program.GetNextLabel();
                    hasVtable = true;
                    instructions.Add(new DataMetaInstruction(cls.VTable.Text, vtableSize * 4));
                }
            }

            instructions.Add(new SegmentMetaInstruction("text"));
            instructions.Add(new GlobalMetaInstruction("main"));
            instructions.Add(new ExternMetaInstruction("printInt"));
            instructions.Add(new ExternMetaInstruction("printString"));
            instructions.Add(new ExternMetaInstruction("error"));
            instructions.Add(new ExternMetaInstruction("readInt"));
            instructions.Add(new ExternMetaInstruction("readString"));
            instructions.Add(new ExternMetaInstruction("concat_string"));
            instructions.Add(new ExternMetaInstruction("lat_malloc"));
            instructions.Add(new ExternMetaInstruction("lat_strcmp"));
            
            var translator = new IntelAsmTranslator(withIndent: true);

            if (hasVtable)
            {
                instructions.Add(new LabelInstruction(new X86Label("lat_initvtable")));
                
                foreach (var cls in program.Classes)
                {
                    int offset = 0;
                    foreach (var method in cls.AllMethods())
                    {
                        var classWithMethod = cls.GetDefiningClass(method);
                        
                        var instr  = new MovInstruction(new Memory32(new X86Label(cls.VTable.Text), offset), new ImmediateValue32(new X86Label($"{classWithMethod.ClassName}____{method}")));

                        instructions.Add(instr);
                        offset += 4;
                    }
                }

                instructions.Add(new RetInstruction());
            }
            
            foreach (var func in program.Functions)
            {
                var registerProvider = new EndlessStackRegisterProvider(-4 * (1 + func.Locals));
                var allocator = new NaiveRegisterAllocator<IOperand>(registerProvider);
                var regs = allocator.AllocateRegisters(func.Instructions);
                var generator = new QuadrupleToX86Generator(program, regs, registerProvider.MaxUsedRegisters + func.Locals, hasVtable);

                foreach (var quad in func.Instructions)
                {
                    var instrs = generator.Visit(quad).ToList();
                    foreach (var i in instrs)
                    {
                        i.Comment = quad.ToString();
                    }
                    instructions.AddRange(instrs);
                }
            }

            OptimizeX86 optimizer = new OptimizeX86();

            var optimized = optimizer.Optimize(instructions);

            if (optimized.Count != instructions.Count)
            {
                Console.WriteLine($"Optimized x86 assembly from {instructions.Count} to {optimized.Count} instructions");
            }
                
            return string.Join("\n", optimized.Select(x => $"{translator.Visit(x)}               ; {x.Comment}"));
        }

        internal class EndlessStackRegisterProvider : IRegisterProvider<IOperand>
        {
            private int nextOffset = 0;

            private int usedRegister = 0;

            public int MaxUsedRegisters => usedRegister;
            
            public EndlessStackRegisterProvider(int startOffset)
            {
                nextOffset = startOffset;
            }

            public IOperand GetNextFreeRegister()
            {
                var offset = nextOffset;
                nextOffset -= 4;
                usedRegister++;
                return new Memory32(Register32.EBP, offset);
            }

            public IOperand GetConstRegister(int @const)
            {
                return new ImmediateValue32(@const);
            }
        }
    }
}