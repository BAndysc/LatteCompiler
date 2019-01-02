using System.Collections.Generic;
using System.Threading;
using LatteBase.AST;
using LatteBase.Visitors;
using QuadruplesCommon;
using QuadruplesCommon.Quadruples;
using QuadruplesGenerator.Generators;

namespace QuadruplesGenerator
{
    public class Generator : ProgramFunctionVisitor<QuadruplesProgram>
    {
        private QuadruplesProgram prog;
        
        public override QuadruplesProgram Visit(IProgram program)
        {
            prog = new QuadruplesProgram();

            foreach (var func in program.Functions)
            {
                prog.Emit(new FuncDefQuadruple(func.FilePlace, func.Name));
                Visit(func);
            }

            return prog;
        }

        public override QuadruplesProgram Visit(ITopFunctionNode topFunction)
        {
            var counter = new ValueMaxCounter();
            new LocalValuesCounter(counter).Visit(topFunction.Body);

            var locals = counter.Max;
            IStore store = new Store(locals);

            for (int i = 0; i < locals; ++i)
            {
                prog.Emit(new LocalQuadruple(topFunction.FilePlace, i));
            }
            
            new StatementGenerator(prog, store).Visit(topFunction.Body);

            return prog;
        }
    }
}