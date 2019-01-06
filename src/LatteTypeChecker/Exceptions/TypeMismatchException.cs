using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class TypeMismatchException : TypeCheckerException
    {
        private readonly IVariableDefinition previousDeclaration;
        private readonly IVariableDefinition expectedDeclaration;

        public TypeMismatchException(
            IVariableDefinition previousDeclaration,
            IVariableDefinition expectedDeclaration,
            IFilePlace source) : base(source)
        {
            this.previousDeclaration = previousDeclaration;
            this.expectedDeclaration = expectedDeclaration;
        }

        public override string ToString()
        {
            return $"Variable {previousDeclaration.Name} declared as {previousDeclaration.Type}, but expected {expectedDeclaration.Type}. {base.ToString()}";
        }
    }
}