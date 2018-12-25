
using System.Collections.Generic;
using LatteBase;

namespace LatteTypeChecker.Models
{
    public interface IFunctionDefinition
    {
        LatteType ReturnType { get; }
        string Name { get; }
        IList<LatteType> ArgumentTypes { get; }
        IList<string> ArgumentNames { get; }
    }
}