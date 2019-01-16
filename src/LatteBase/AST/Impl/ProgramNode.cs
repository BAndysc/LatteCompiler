using System.Collections.Generic;
using System.Linq;
using LatteBase.AST;

namespace LatteBase.AST.Impl
{
    public class ProgramNode : IProgram
    {
        public ProgramNode(IEnumerable<IFunctionDefinition> functions,
                            IEnumerable<IClassDefinitionNode> classes = null)
        {
            Functions = functions;
            if (classes == null)
                classes = new List<IClassDefinitionNode>();
            Classes = classes;
        }

        public ProgramNode(params IFunctionDefinition[] functions) : this(functions.ToList(), new List<IClassDefinitionNode>())
        {
        }
        
        public IEnumerable<IFunctionDefinition> Functions { get; }
        public IEnumerable<IClassDefinitionNode> Classes { get; }
    }
}