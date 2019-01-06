using System.Linq;
using System.Text;
using LatteBase.AST;
using QuadruplesCommon;
using QuadruplesGenerator.RegisterAllocators;
using X86Assembler.Operands;
using X86IntelAsm;

namespace X86Generator
{
    public class X86Compiler
    {
        public string Compile(QuadruplesProgram program)
        {
            

            StringBuilder builder = new StringBuilder();


            if (program.ConstStrings.Count > 0)
            {
                builder.AppendLine("segment .data");
                foreach (var str in program.ConstStrings)
                {
                    builder.AppendLine($"    {str.Key}: db `{str.Value.Replace("`", "\\`")}`, 0");
                }
            }

            builder.AppendLine("segment .text");
            builder.AppendLine("    global main");
            builder.AppendLine("    extern printInt");
            builder.AppendLine("    extern printString");
            builder.AppendLine("    extern error");
            builder.AppendLine("    extern readInt");
            builder.AppendLine("    extern readString");
            builder.AppendLine("    extern concat_string");

            var translator = new IntelAsmTranslator(withIndent: true);
            
            foreach (var func in program.Functions)
            {
                var allocator = new NaiveRegisterAllocator<Memory32>();
                for (int i = 10; i >= 0; --i)
                    allocator.AddRegisterToPool(new Memory32(Register32.EBP, - 4 * (1 + func.Locals + i)));
                
                var regs = allocator.AllocateRegisters(func.Instructions);
                var generator = new QuadrupleToX86Generator(regs, regs.MaxUsedRegisters);

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
    }
}