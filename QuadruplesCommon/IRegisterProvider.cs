namespace QuadruplesCommon
{
    public interface IRegisterProvider<T>
    {
        T GetNextFreeRegister();
    }
}