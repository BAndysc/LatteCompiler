using System;
using LatteBase;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class VariableDeclarationTypeMismatch : TypeCheckerException
    {
        private readonly IVariableDefinition variable;
        private readonly ILatteType itemValueType;

        public VariableDeclarationTypeMismatch(IVariableDefinition variable, ILatteType itemValueType, IFilePlace filePlace) : base(filePlace)
        {
            this.variable = variable;
            this.itemValueType = itemValueType;
        }

        public override string ToString()
        {
            return
                $"Variable {variable.Name} declared as {variable.Type}, but trying to assign {itemValueType} into it.\n{base.ToString()}";
        }
    }
}