using System.Linq;
using System.Text;
using LatteBase.AST;
using QuadruplesCommon;
using QuadruplesGenerator.RegisterAllocators;
using X86Assembly;
using X86Assembly.Instructions;
using X86Assembly.Operands;
using X86IntelAsm;

namespace X86Generator
{
    public class X86Compiler
    {
        public string Compile(QuadruplesProgram program)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder dataBuilder = new StringBuilder();

            foreach (var str in program.ConstStrings)
                dataBuilder.AppendLine($"    {str.Key}: db `{str.Value.Replace("`", "\\`")}`, 0");

            bool hasVtable = false;
            
            foreach (var cls in program.Classes)
            {
                var vtableSize = cls.VtableSize();
                if (vtableSize > 0)
                {
                    cls.VTable = program.GetNextLabel();
                    hasVtable = true;
                    dataBuilder.AppendLine($"    {cls.VTable}: dd " +
                                           string.Join(", ", Enumerable.Repeat(0, vtableSize)));
                }
            }

            if (dataBuilder.Length > 0)
            {
                builder.AppendLine("segment .data");
                builder.Append(dataBuilder);
            }

            builder.AppendLine("segment .text");
            builder.AppendLine("    global main");
            builder.AppendLine("    extern printInt");
            builder.AppendLine("    extern printString");
            builder.AppendLine("    extern error");
            builder.AppendLine("    extern readInt");
            builder.AppendLine("    extern readString");
            builder.AppendLine("    extern concat_string");
            builder.AppendLine("    extern lat_malloc");
            builder.AppendLine("    extern lat_strcmp");

            var translator = new IntelAsmTranslator(withIndent: true);

            if (hasVtable)
            {
                builder.AppendLine(translator.Visit(new LabelInstruction(new X86Label("lat_initvtable"))));
                foreach (var cls in program.Classes)
                {
                    int offset = 0;
                    foreach (var method in cls.AllMethods())
                    {
                        var classWithMethod = cls.GetDefiningClass(method);
                        
                        var instr  = new MovInstruction(new Memory32(new X86Label(cls.VTable.Text), offset), new ImmediateValue32(new X86Label($"{classWithMethod.ClassName}____{method}")));

                        builder.AppendLine(translator.Visit(instr));
                        offset += 4;
                    }

                    builder.AppendLine();
                }

                builder.AppendLine(translator.Visit(new RetInstruction()));
            }
            
            foreach (var func in program.Functions)
            {
                var registerProvider = new EndlessStackRegisterProvider(-4 * (1 + func.Locals));
                var allocator = new NaiveRegisterAllocator<Memory32>(registerProvider);
                var regs = allocator.AllocateRegisters(func.Instructions);
                var generator = new QuadrupleToX86Generator(program, regs, registerProvider.MaxUsedRegisters + func.Locals, hasVtable);

                foreach (var quad in func.Instructions)
                {
                    var instrs = generator.Visit(quad).Select(translator.Visit);

                    foreach (var instr in instrs)
                    {
                        builder.AppendLine(instr);
                    }
                }
            }


            return builder.ToString();
        }

        internal class EndlessStackRegisterProvider : IRegisterProvider<Memory32>
        {
            private int nextOffset = 0;

            private int usedRegister = 0;

            public int MaxUsedRegisters => usedRegister;
            
            public EndlessStackRegisterProvider(int startOffset)
            {
                nextOffset = startOffset;
            }

            public Memory32 GetNextFreeRegister()
            {
                var offset = nextOffset;
                nextOffset -= 4;
                usedRegister++;
                return new Memory32(Register32.EBP, offset);
            }
        }
    }
}