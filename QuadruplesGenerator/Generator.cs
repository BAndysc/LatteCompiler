using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LatteBase;
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
                Visit(func);
            }

            return prog;
        }

        public override QuadruplesProgram Visit(ITopFunctionNode topFunction)
        {
            
            var counter = new ValueMaxCounter();
            new LocalValuesCounter(counter).Visit(topFunction.Body);

            var locals = counter.Max + topFunction.Arguments.Count();
            IStore store = new Store(locals);

            
            prog.EmitFunction(topFunction.Name, locals);
            prog.Emit(new FuncDefQuadruple(topFunction.FilePlace, topFunction.Name));
            
            for (int i = 0; i < locals; ++i)
            {
                prog.Emit(new LocalQuadruple(topFunction.FilePlace, i));
            }

            int j = 0;
            foreach (var arg in topFunction.Arguments)
            {
                var argIndex = store.Alloc(arg.Name);
                prog.Emit(new LoadArgumentQuadruple(topFunction.FilePlace, j++, argIndex));
            }

            var startLabel = prog.GetNextLabel();
            
            prog.Emit(new LabelQuadruple(topFunction.FilePlace, startLabel));
            
            new StatementGenerator(prog, store, topFunction, startLabel).Visit(topFunction.Body);

            if (topFunction.ReturnType == LatteType.Void)
                prog.Emit(new ReturnVoidQuadruple(topFunction.FilePlace));
            
            return prog;
        }
    }
}