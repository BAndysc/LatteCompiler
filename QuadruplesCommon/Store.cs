using System.Collections.Generic;

namespace QuadruplesCommon
{
    public class Store : IStore
    {
        private Store baseStore;
        private List<int> freeLocs;
        private Dictionary<string, int> varToLoc;

        public Store(Store other)
        {
            baseStore = other;
            freeLocs = new List<int>(other.freeLocs);
            varToLoc = new Dictionary<string, int>();
        }

        public Store(int frees)
        {
            freeLocs = new List<int>();
            varToLoc = new Dictionary<string, int>();

            for (int i = 0; i < frees; ++i)
                freeLocs.Add(i);
        }

        public IStore CopyForBlock()
        {
            return new Store(this);
        }
        
        public void Free(string variable)
        {
            if (varToLoc.ContainsKey(variable))
            {
                freeLocs.Add(varToLoc[variable]);
                varToLoc.Remove(variable);                
            }
            else
                baseStore.Free(variable);
        }

        public int Alloc(string variable)
        {
            var loc = freeLocs[freeLocs.Count - 1];
            freeLocs.RemoveAt(freeLocs.Count - 1);
            varToLoc[variable] = loc;

            return loc;
        }

        public int Get(string variable)
        {
            if (varToLoc.ContainsKey(variable))
                return varToLoc[variable];

            return baseStore.Get(variable);
        }
    }
}