
using System.Collections.Generic;
using LatteBase;

namespace LatteTypeChecker.Models
{
    public interface IFunctionDefinition
    {
        ILatteType ReturnType { get; }
        string Name { get; }
        IList<ILatteType> ArgumentTypes { get; }
        IList<string> ArgumentNames { get; }
    }
}