namespace QuadruplesCommon
{
    public interface IRegisterProvider<T>
    {
        T GetNextFreeRegister();
        T GetConstRegister(int @const);
    }
}