using System.Collections.Generic;

namespace Common
{
    public class VariableEnvironment : IVariableEnvironment
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
        public IVariableEnvironment CopyForBlock()
        {
            return new VariableEnvironment(this);
        }
    }
}