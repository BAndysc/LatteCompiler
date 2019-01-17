namespace LatteTypeChecker.Models
{
    public interface IClassesEnvironment
    {
        bool IsDefined(string @class);
        
        IClassDefinition GetClass(string className);
        
        void DefineClass(IClassDefinition @class);

    }
}