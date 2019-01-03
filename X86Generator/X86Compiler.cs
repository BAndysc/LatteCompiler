using System.Text;
using LatteBase.AST;
using QuadruplesCommon;
using QuadruplesGenerator.RegisterAllocators;

namespace X86Generator
{
    public class X86Compiler
    {
        public string Compile(QuadruplesProgram program)
        {
            var allocator = new NaiveRegisterAllocator();
            allocator.AddRegisterToPool(X86Register.EAX);
            allocator.AddRegisterToPool(X86Register.ECX);
            allocator.AddRegisterToPool(X86Register.EBX);
            allocator.AddRegisterToPool(X86Register.EDX);

            var regs = allocator.AllocateRegisters(program);

            StringBuilder builder = new StringBuilder();

            var generator = new QuadrupleToX86Generator(builder, regs);

            if (program.ConstStrings.Count > 0)
            {
                builder.AppendLine("segment .data");
                foreach (var str in program.ConstStrings)
                {
                    builder.AppendLine($"    {str.Key}: db {str.Value}, 0");
                }
            }

            builder.AppendLine("segment .text");
            builder.AppendLine("    global main");
            builder.AppendLine("    extern printInt");
            builder.AppendLine("    extern printString");
            builder.AppendLine("    extern error");
            builder.AppendLine("    extern readInt");
            builder.AppendLine("    extern readString");
            foreach (var quad in program.Program)
            {
                generator.Visit(quad);
            }

            return builder.ToString();
        }
    }
}