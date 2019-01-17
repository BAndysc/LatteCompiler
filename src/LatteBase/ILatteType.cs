namespace LatteBase
{
    public interface ILatteType
    {
        string Name { get; }
    }

    public class LatteType : ILatteType
    {
        public string Name { get; }
        public static readonly LatteType Int = new LatteType("int");
        public static readonly LatteType String = new LatteType("string");
        public static readonly LatteType Bool = new LatteType("bool");
        public static readonly LatteType Void = new LatteType("void");
        public static readonly LatteType Null = new LatteType("null");

        public LatteType(string name)
        {
            Name = name;
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