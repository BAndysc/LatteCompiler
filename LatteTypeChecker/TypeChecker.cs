using System;
using System.Linq;
using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using LatteTypeChecker.Exceptions;
using LatteTypeChecker.Models;
using LatteTypeChecker.Visitors;
using Environment = LatteTypeChecker.Models.Environment;

namespace LatteTypeChecker
{
    public class TypeChecker : ProgramVisitor<bool>
    {
        private readonly IEnvironment environment;

        public TypeChecker() : this(new Environment())
        {
            
        }
        
        public TypeChecker(IEnvironment environment)
        {
            this.environment = environment;
        }
        
        public override bool Visit(IProgram program)
        {
            foreach (var function in program.Functions)
            {
                var blockVisitor = new StatementTypeChecker(new VariableEnvironment(), environment);
                
                var functionDef = new FunctionDefinition(function.ReturnType, 
                    function.Name, 
                    function.Arguments.Select(t => t.Type).ToList(),
                    function.Arguments.Select(t => t.Name).ToList());
                
                if (environment.IsDefined(functionDef))
                {
                    throw new FunctionRedefinitionException(environment[function.Name], functionDef, function.FilePlace);
                }

                var voidArgument = function.Arguments.FirstOrDefault(t => t.Type == LatteType.Void);

                if (voidArgument != null)
                {
                    throw new InvalidFunctionArgumentTypeException(functionDef, voidArgument, function.FilePlace);
                }
                
                environment.Define(functionDef);
                blockVisitor.Visit(function.Body);
                Console.WriteLine($"Function {function.Name} declaration, return type: {function.ReturnType}");
            }

            if (!environment.IsDefined("main"))
                throw new NoStartingPointException("main");

            if (environment["main"].ReturnType != LatteType.Int)
                throw new StartingFunctionWrongReturnTypeException(environment["main"], LatteType.Int);
            
            return true;
        }
    }
}