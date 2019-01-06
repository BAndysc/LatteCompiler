using System;

namespace QuadruplesGenerator
{
    public class ValueMaxCounter
    {
        public int Value { get; private set; }
        public int Max { get; private set; }

        public void Add(int v)
        {
            Value += v;
            Max = Math.Max(Value, Max);
        }

        public void Sub(int v)
        {
            Value -= v;
        }
    }
}