using System.Collections.Generic;
using System.Linq;
using LatteBase.AST;

namespace LatteBase.AST.Impl
{
    public class ProgramNode : IProgram
    {
        public ProgramNode(IEnumerable<IFunctionDefinitionNode> functions,
                            IEnumerable<IClassDefinitionNode> classes = null)
        {
            Functions = functions;
            if (classes == null)
                classes = new List<IClassDefinitionNode>();
            Classes = classes;
        }

        public ProgramNode(params IFunctionDefinitionNode[] functions) : this(functions.ToList(), new List<IClassDefinitionNode>())
        {
        }
        
        public IEnumerable<IFunctionDefinitionNode> Functions { get; }
        public IEnumerable<IClassDefinitionNode> Classes { get; }
    }
}