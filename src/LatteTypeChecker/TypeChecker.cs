using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using LatteTypeChecker.Exceptions;
using LatteTypeChecker.Models;
using LatteTypeChecker.Visitors;
using Environment = LatteTypeChecker.Models.Environment;

namespace LatteTypeChecker
{
    internal class TypeChecker : ProgramVisitor<bool>
    {
        private readonly IEnvironment environment;

        public TypeChecker()
        {
            this.environment = new Environment();
            environment.DefineFunction(new FunctionDefinition(LatteType.Void, "printInt", new List<ILatteType>(){LatteType.Int}, new List<string>(){"number"}));
            environment.DefineFunction(new FunctionDefinition(LatteType.Void, "printString", new List<ILatteType>(){LatteType.String}, new List<string>(){"text"}));
            environment.DefineFunction(new FunctionDefinition(LatteType.Void, "error", null, null));
            environment.DefineFunction(new FunctionDefinition(LatteType.Int, "readInt", null, null));
            environment.DefineFunction(new FunctionDefinition(LatteType.String, "readString", null, null));
        }
        
        public TypeChecker(IEnvironment environment)
        {
            this.environment = environment;
        }
        
        public override bool Visit(IProgram program)
        {
            HashSet<string> classNames = new HashSet<string>();
            classNames.Add("int");
            classNames.Add("bool");
            classNames.Add("string");

            foreach (var @class in program.Classes)
            {
                if (classNames.Contains(@class.ClassName) || @class.ClassName == "void")
                    throw new DuplicateClassDefinitionException(@class, @class.FilePlace);

                classNames.Add(@class.ClassName);
            }

            foreach (var @class in program.Classes)
            {
                if (@class.SuperClass != null && !classNames.Contains(@class.SuperClass))
                    throw new Exception("Super class doesn't exist " + @class.SuperClass);
            }
            
            foreach (var @class in program.Classes)
            {
                List<IClassField> classFields = new List<IClassField>();
                foreach (var field in @class.Fields)
                {
                    if (classFields.Select(t => t.FieldName).Contains(field.FiledName))
                        throw new DuplicateClassFieldException(field.FiledName, @class.ClassName, @class.FilePlace);
                    
                    if (field.FieldType == LatteType.Void)
                        throw new InvalidVariableTypeException(field.FieldType, field.FilePlace);
                    
                    classFields.Add(new ClassField(field.FieldType, field.FiledName));
                }

                IClassDefinition superClass = null;
                if (@class.SuperClass != null)
                    superClass = environment.GetClass(@class.SuperClass);
                
                var classDefinition = new ClassDefinition(@class.ClassName, superClass, classFields);
                environment.DefineClass(classDefinition);
            }

            foreach (var @class in program.Classes)
            {
                var classDefinition = environment.GetClass(@class.ClassName);
                
                foreach (var function in @class.Methods)
                {
                    var functionDef = new FunctionDefinition(function.ReturnType, 
                        function.Name, 
                        function.Arguments.Select(t => t.Type).ToList(),
                        function.Arguments.Select(t => t.Name).ToList());

                    if (functionDef.ArgumentNames.Distinct().Count() != functionDef.ArgumentNames.Count)
                        throw new RepeatedArgumentNameInFunctionDefinitionException(functionDef, function.FilePlace);
                
                    if (classDefinition.DirectlyHasMethod(function.Name))
                        throw new FunctionRedefinitionException(classDefinition.GetMethod(function.Name), functionDef, function.FilePlace);

                    var voidArgument = function.Arguments.FirstOrDefault(t => t.Type == LatteType.Void);

                    if (voidArgument != null)
                        throw new InvalidFunctionArgumentTypeException(functionDef, voidArgument, function.FilePlace);
                
                    classDefinition.DefineMethod(functionDef);
                }
            }
            
            foreach (var function in program.Functions)
            {
                var functionDef = new FunctionDefinition(function.ReturnType, 
                    function.Name, 
                    function.Arguments.Select(t => t.Type).ToList(),
                    function.Arguments.Select(t => t.Name).ToList());

                if (functionDef.ArgumentNames.Distinct().Count() != functionDef.ArgumentNames.Count)
                    throw new RepeatedArgumentNameInFunctionDefinitionException(functionDef, function.FilePlace);
                
                if (environment.IsFunctionDefined(functionDef))
                    throw new FunctionRedefinitionException(environment[function.Name], functionDef, function.FilePlace);

                var voidArgument = function.Arguments.FirstOrDefault(t => t.Type == LatteType.Void);

                if (voidArgument != null)
                    throw new InvalidFunctionArgumentTypeException(functionDef, voidArgument, function.FilePlace);
                
                environment.DefineFunction(functionDef);
            }

            foreach (var function in program.Functions)
            {
                var variables = new VariableEnvironment();

                foreach (var arg in function.Arguments)
                    variables.Define(new VariableDefinition(arg.Name, arg.Type));
                
                var blockVisitor = new StatementTypeChecker(variables, environment, function.ReturnType);
                
                blockVisitor.Visit(function.Body);
            }

            foreach (var @class in program.Classes)
            {
                var classDefinition = environment.GetClass(@class.ClassName);

                foreach (var method in @class.Methods)
                {
                    var variables = new VariableEnvironment();

                    foreach (var arg in method.Arguments)
                        variables.Define(new VariableDefinition(arg.Name, arg.Type));
                
                    variables.Define(new VariableDefinition("this", classDefinition.Type));
                    
                    foreach (var field in classDefinition.AllFields)
                        variables.Define(new VariableDefinition(field.FieldName, field.FieldType));
                    
                    var blockVisitor = new StatementTypeChecker(variables, environment, method.ReturnType);
                
                    blockVisitor.Visit(method.Body);       
                }
            }
            
            if (!environment.IsFunctionDefined("main"))
                throw new NoStartingPointException("main");

            if (environment["main"].ReturnType != LatteType.Int)
                throw new StartingFunctionWrongReturnTypeException(environment["main"], LatteType.Int);

            if (environment["main"].ArgumentTypes.Count != 0)
                throw new StartingFunctionInvalidArgumentsCountException(environment["main"]);
            
            return true;
        }
    }
}