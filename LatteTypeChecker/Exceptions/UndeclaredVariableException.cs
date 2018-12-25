using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class UndeclaredVariableException : TypeCheckerException
    {
        private readonly IVariableDefinition expectedVariable;

        public UndeclaredVariableException(IVariableDefinition expectedVariable,
            IFilePlace source) : base(source)
        {
            this.expectedVariable = expectedVariable;
        }

        public override string ToString()
        {
            return $"Expected declaration of variable {expectedVariable.Type} {expectedVariable.Name}, but it is undeclared. {base.ToString()}";
        }
    }
}