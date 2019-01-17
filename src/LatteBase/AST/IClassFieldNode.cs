namespace LatteBase.AST
{
    public interface IClassFieldNode : INode
    {
        string FiledName { get; }
        ILatteType FieldType { get; }
    }
}