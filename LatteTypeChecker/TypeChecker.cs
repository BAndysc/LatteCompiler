using System.Collections.Generic;
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

        public TypeChecker()
        {
            this.environment = new Environment();
            environment.Define(new FunctionDefinition(LatteType.Void, "printInt", new List<LatteType>(){LatteType.Int}, new List<string>(){"number"}));
            environment.Define(new FunctionDefinition(LatteType.Void, "printString", new List<LatteType>(){LatteType.String}, new List<string>(){"text"}));
            environment.Define(new FunctionDefinition(LatteType.Void, "error", null, null));
            environment.Define(new FunctionDefinition(LatteType.Int, "readInt", null, null));
            environment.Define(new FunctionDefinition(LatteType.String, "readString", null, null));
        }
        
        public TypeChecker(IEnvironment environment)
        {
            this.environment = environment;
        }
        
        public override bool Visit(IProgram program)
        {
            foreach (var function in program.Functions)
            {
                var functionDef = new FunctionDefinition(function.ReturnType, 
                    function.Name, 
                    function.Arguments.Select(t => t.Type).ToList(),
                    function.Arguments.Select(t => t.Name).ToList());

                if (functionDef.ArgumentNames.Distinct().Count() != functionDef.ArgumentNames.Count)
                    throw new RepeatedArgumentNameInFunctionDefinitionException(functionDef, function.FilePlace);
                
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
            }

            foreach (var function in program.Functions)
            {
                var variables = new VariableEnvironment();

                foreach (var arg in function.Arguments)
                    variables.Define(new VariableDefinition(arg.Name, arg.Type));
                
                var blockVisitor = new StatementTypeChecker(variables, environment, function.ReturnType);
                
                bool hasReturned = blockVisitor.Visit(function.Body);

                if (!hasReturned && function.ReturnType != LatteType.Void)
                    throw new ExpectedReturnInFunctionException(environment[function.Name], function.FilePlace);
            }
            
            if (!environment.IsDefined("main"))
                throw new NoStartingPointException("main");

            if (environment["main"].ReturnType != LatteType.Int)
                throw new StartingFunctionWrongReturnTypeException(environment["main"], LatteType.Int);

            if (environment["main"].ArgumentTypes.Count != 0)
                throw new StartingFunctionInvalidArgumentsCountException(environment["main"]);
            
            return true;
        }
    }
}