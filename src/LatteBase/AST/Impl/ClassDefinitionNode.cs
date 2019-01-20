using System.Collections.Generic;

namespace LatteBase.AST.Impl
{
    public class ClassDefinitionNode : IClassDefinitionNode
    {
        public IFilePlace FilePlace { get; }
        public string ClassName { get; }
        public string SuperClass { get; }
        public IEnumerable<IClassFieldNode> Fields { get; }
        public IEnumerable<IFunctionDefinitionNode> Methods { get; }

        public ClassDefinitionNode(IFilePlace filePlace, string className, string superClass, IEnumerable<IFunctionDefinitionNode> methods = null, params IClassFieldNode[] fields)
        {
            FilePlace = filePlace;
            ClassName = className;
            SuperClass = superClass;
            Fields = fields;
            if (methods ==  null)
                methods = new List<IFunctionDefinitionNode>();
            Methods = methods;
        }
    }

    public class ClassFieldNode : IClassFieldNode
    {
        public ClassFieldNode(IFilePlace source, string filedName, ILatteType fieldType)
        {
            FilePlace = source;
            FiledName = filedName;
            FieldType = fieldType;
        }

        public IFilePlace FilePlace { get; }
        public string FiledName { get; }
        public ILatteType FieldType { get; }
    }
    
}