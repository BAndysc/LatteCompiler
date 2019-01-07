using System;
using LatteBase.AST;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Exceptions
{
    public class FunctionRedefinitionException : TypeCheckerException
    {
        private readonly IFunctionDefinition prevDecl;
        private readonly IFunctionDefinition currDecl;

        public FunctionRedefinitionException(IFunctionDefinition prevDecl,
            IFunctionDefinition currDecl,
            IFilePlace place) : base(place)
        {
            this.prevDecl = prevDecl;
            this.currDecl = currDecl;
        }

        public override string ToString()
        {
            return
                $"Function redeclaration. Previously: {prevDecl.ReturnType} {prevDecl.Name}. Now: {currDecl.ReturnType} {currDecl.Name}.\n{base.ToString()}";
        }
    }
}