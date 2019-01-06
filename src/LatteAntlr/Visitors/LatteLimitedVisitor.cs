using System;
using Antlr4.Runtime;

namespace LatteAntlr.Visitors
{
    internal class LatteLimitedVisitor<T> : LatteBaseEmptyVisitor<T>
    {
        protected T ThrowInvalidContext(ParserRuleContext context)
        {
            throw new FatalErrorInvalidContextException(context, this.GetType());
        }
    }

    internal class FatalErrorInvalidContextException : Exception
    {
        private readonly ParserRuleContext _context;
        private readonly Type _caller;

        public FatalErrorInvalidContextException(ParserRuleContext context, Type caller)
        {
            _context = context;
            _caller = caller;
        }

        public override string ToString()
        {
            return $"FATAL ERROR! Invalid context inside {_caller.FullName}: {_context.GetText()}";
        }
    }
    
}