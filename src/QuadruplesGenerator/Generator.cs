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

        public override QuadruplesProgram Visit(IFunctionDefinition function)
        {
            
            var counter = new ValueMaxCounter();
            new LocalValuesCounter(counter).Visit(function.Body);

            var locals = counter.Max + function.Arguments.Count();
            IStore store = new Store(locals);

            
            prog.EmitFunction(function.Name, locals);
            prog.Emit(new FuncDefQuadruple(function.FilePlace, function.Name));
            
            for (int i = 0; i < locals; ++i)
            {
                prog.Emit(new LocalQuadruple(function.FilePlace, i));
            }

            int j = 0;
            foreach (var arg in function.Arguments)
            {
                var argIndex = store.Alloc(arg.Name);
                prog.Emit(new LoadArgumentQuadruple(function.FilePlace, j++, argIndex));
            }

            var startLabel = prog.GetNextLabel();
            
            prog.Emit(new LabelQuadruple(function.FilePlace, startLabel));
            
            new StatementGenerator(prog, store, function, startLabel).Visit(function.Body);

            if (function.ReturnType == LatteType.Void)
                prog.Emit(new ReturnVoidQuadruple(function.FilePlace));
            
            return prog;
        }
    }
}