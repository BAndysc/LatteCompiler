namespace LatteBase
{
    public interface ILatteType
    {
        ILatteType BaseType { get; }
        string Name { get; }
        bool IsArray { get; }
    }

    public class LatteType : ILatteType
    {
        public ILatteType BaseType { get; }
        public string Name { get; }
        public bool IsArray { get; }
        public static readonly LatteType Int = new LatteType("int");
        public static readonly LatteType String = new LatteType("string");
        public static readonly LatteType Bool = new LatteType("boolean");
        public static readonly LatteType Void = new LatteType("void");
        public static readonly LatteType Null = new LatteType("null");

        public LatteType(string name)
        {
            Name = name;
            IsArray = false;
            BaseType = null;
        }

        public LatteType(ILatteType baseType)
        {
            BaseType = baseType;
            IsArray = true;
            Name = baseType.Name + "[]";
        }

        
        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(ILatteType lhs, LatteType rhs)
        {
            return lhs?.Equals(rhs) ?? object.ReferenceEquals(rhs, null);
        }

        public static bool operator ==(LatteType lhs, ILatteType rhs)
        {
            return rhs?.Equals(lhs) ?? object.ReferenceEquals(lhs, null);
        }
        
        public static bool operator !=(ILatteType lhs, LatteType rhs)
        {
            return !(lhs == rhs);
        }
        
        public static bool operator !=(LatteType lhs, ILatteType rhs)
        {
            return !(lhs == rhs);
        }
        
        protected bool Equals(ILatteType other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is ILatteType)) return false;
            return Equals((ILatteType) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}