using System.Collections.Generic;

namespace LatteBase.AST.Impl
{
    public class ClassDefinitionNode : IClassDefinitionNode
    {
        public IFilePlace FilePlace { get; }
        public string ClassName { get; }
        public IEnumerable<IClassFieldNode> Fields { get; }

        public ClassDefinitionNode(IFilePlace filePlace, string className, params IClassFieldNode[] fields)
        {
            FilePlace = filePlace;
            ClassName = className;
            Fields = fields;
        }
    }

    public class ClassFieldNode : IClassFieldNode
    {
        public ClassFieldNode(IFilePlace source, string filedName, LatteType fieldType)
        {
            FilePlace = source;
            FiledName = filedName;
            FieldType = fieldType;
        }

        public IFilePlace FilePlace { get; }
        public string FiledName { get; }
        public LatteType FieldType { get; }
    }
    
}