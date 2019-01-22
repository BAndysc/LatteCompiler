using System;

namespace LatteBase.CodeGenerators
{
    public class LatteTypeCodeGenerator
    {
        public string Visit(ILatteType type)
        {
            if (type == LatteType.Int)
                return "LatteType.Int";
            if (type == LatteType.Void)
                return "LatteType.Void";
            if (type == LatteType.String)
                return "LatteType.String";
            if (type == LatteType.Bool)
                return "LatteType.Bool";
            if (type == LatteType.Null)
                return "LatteType.Null";
            if (type.IsArray)
                return $"new LatteType({Visit(type.BaseType)})";
            return $"new LatteType(\"{type.Name}\")";
        }
    }
}