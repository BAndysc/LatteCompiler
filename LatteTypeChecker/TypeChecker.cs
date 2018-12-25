using System;
using System.Collections.Generic;
using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using LatteTypeChecker.Exceptions;
using LatteTypeChecker.Models;

namespace LatteTypeChecker
{
    public class TypeChecker : ProgramVisitor<bool>
    {
        private readonly IEnvironment environment;

        public TypeChecker(IEnvironment environment)
        {
            this.environment = environment;
        }
        
        public override bool Visit(IProgram program)
        {
            foreach (var function in program.Functions)
            {
                var blockVisitor = new StatementTypeChecker(new VariableEnvironment(), environment);
                
                var functionDef = new FunctionDefinition(function.ReturnType, function.Name);
                
                if (environment.IsDefined(functionDef))
                {
                    throw new FunctionRedefinitionException(environment[function.Name], functionDef, function.FilePlace);
                }

                environment.Define(functionDef);
                blockVisitor.Visit(function.Body);
                Console.WriteLine($"Function {function.Name} declaration, return type: {function.ReturnType}");
            }
            return true;   
        }
    }
    
    public interface IEnvironment
    {
        bool IsDefined(string functionName);
        bool IsDefined(IFunctionDefinition function);
        void Define(IFunctionDefinition function);
        IFunctionDefinition this[string functionName] { get; }
    }

    public interface IVariableEnvironement
    {
        bool IsDefined(IVariableDefinition variable);

        bool IsDefined(string name);
        
        void Define(IVariableDefinition variable);
        bool CanRedefine(IVariableDefinition item);
        
        IVariableDefinition this[string variableName] { get; }
        IVariableEnvironement CopyForBlock();
    }

    public class VariableEnvironment : IVariableEnvironement
    {
        private readonly Dictionary<string, IVariableDefinition> definedVariables;

        private readonly HashSet<string> declaredHere;

        public VariableEnvironment()
        {
            definedVariables = new Dictionary<string, IVariableDefinition>();
            declaredHere = new HashSet<string>();
        }

        private VariableEnvironment(VariableEnvironment other)
        {
            definedVariables = new Dictionary<string, IVariableDefinition>(other.definedVariables);
            declaredHere = new HashSet<string>();
            
        }
        
        public bool IsDefined(IVariableDefinition variable)
        {
            return IsDefined(variable.Name);
        }

        public bool IsDefined(string name)
        {
            return definedVariables.ContainsKey(name);
        }

        public void Define(IVariableDefinition variable)
        {
            declaredHere.Add(variable.Name);
            definedVariables[variable.Name] = variable;
        }

        public bool CanRedefine(IVariableDefinition item)
        {
            return !declaredHere.Contains(item.Name);
        }

        public IVariableDefinition this[string variableName] => definedVariables[variableName];
        public IVariableEnvironement CopyForBlock()
        {
            return new VariableEnvironment(this);
        }
    }

    public class Environment : IEnvironment
    {
        private readonly Dictionary<string, IFunctionDefinition> definedFunctions = new Dictionary<string, IFunctionDefinition>();

        public bool IsDefined(string functionName)
        {
            return definedFunctions.ContainsKey(functionName);
        }

        public bool IsDefined(IFunctionDefinition function)
        {
            return IsDefined(function.Name);
        }

        public void Define(IFunctionDefinition function)
        {
            definedFunctions[function.Name] = function;
        }

        public IFunctionDefinition this[string functionName] => definedFunctions[functionName];
    }
    
}