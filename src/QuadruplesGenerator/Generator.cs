using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LatteBase;
using LatteBase.AST;
using LatteBase.AST.Impl;
using LatteBase.Visitors;
using LatteTypeChecker.Visitors;
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

            program = new LatteTreeProcessor.ReplaceClassFieldAccessors().Visit(program);
            program = new LatteTreeProcessor.CalculateFieldOffsets.CalculateFieldOffsetProcessor().Visit(program);
            
            foreach (var cls in program.Classes)
                Visit(cls);
            
            foreach (var func in program.Functions)
                Visit(func);

            return prog;
        }

        public override QuadruplesProgram Visit(IClassDefinitionNode @class)
        {
            QuadrupleClass superClass = null;
            if (@class.SuperClass != null)
                superClass = prog.GetClass(@class.SuperClass);
            
            var cls = new QuadrupleClass(@class.ClassName, @class.Fields.Select(t => GetLatteTypeSize(t.FieldType)), @class.Fields.Select(t => t.FiledName), @class.Methods.Select(t => t.Name), superClass);
            prog.EmitClass(cls);

            foreach (var method in @class.Methods)
            {
                var args = new[] {new FunctionArgument(new LatteType(cls.ClassName), "this")}.Union(method.Arguments);
                var methodWithMangledName = new FunctionDefinitionNode(method.FilePlace, method.ReturnType,
                    $"{@class.ClassName}____{method.Name}", args, method.Body);
                Visit(methodWithMangledName);
            }
            return prog;
        }

        private int GetLatteTypeSize(ILatteType @type)
        {
            if (@type == LatteType.Void)
                throw new Exception();
            return 4;
        }
        
        public override QuadruplesProgram Visit(IFunctionDefinitionNode function)
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