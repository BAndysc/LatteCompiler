using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class VariableRedefinitionException : TypeCheckerException
    {
        private readonly IVariableDefinition prev;
        private readonly IVariableDefinition curr;

        public VariableRedefinitionException(
            IVariableDefinition prev,
            IVariableDefinition curr,
            IFilePlace source) : base(source)
        {
            this.prev = prev;
            this.curr = curr;
        }

        public override string ToString()
        {
            return $"Invalid redeclaration of variable {prev.Name} as {curr.Type} (previously: {prev.Type}).\n{base.ToString()}";
        }
    }
}