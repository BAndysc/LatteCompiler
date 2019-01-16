using System.Collections.Generic;

namespace LatteTypeChecker.Models
{
    public interface IClassDefinition
    {
        string Name { get; }
        IList<IClassField> Fields { get; }
    }
}