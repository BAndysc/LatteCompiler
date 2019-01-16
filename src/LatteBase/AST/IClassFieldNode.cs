namespace LatteBase.AST
{
    public interface IClassFieldNode : INode
    {
        string FiledName { get; }
        LatteType FieldType { get; }
    }
}