using System.Collections;
using System.Collections.Generic;
using LatteBase;

namespace LatteTypeChecker.Models
{
    public interface IClassDefinition
    {
        string Name { get; }
        IClassDefinition SuperClass { get; }
        IList<IClassField> Fields { get; }
        IList<IClassField> AllFields { get; }
        IEnumerable<IFunctionDefinition> Methods { get; }
        ILatteType Type { get;  }

        bool HasField(string fieldName);
        IClassField GetField(string fieldName);
        int GetBaseClassFieldsCount();

        bool HasMethod(string methodName);
        bool DirectlyHasMethod(string methodName);
        IFunctionDefinition GetMethod(string methodName);
        ILatteType GetBaseTypeWithMethod(string methodName);
        void DefineMethod(IFunctionDefinition functionDef);
    }
}