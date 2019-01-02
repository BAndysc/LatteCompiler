namespace QuadruplesCommon
{
    public interface IStore
    {
        void Free(string variable);
        int Alloc(string variable);
        IStore CopyForBlock();
        int Get(string variable);
    }
}