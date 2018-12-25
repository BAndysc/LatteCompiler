using System;

namespace LatteTypeChecker.Exceptions
{
    public class NoStartingPointException : Exception
    {
        private readonly string expectedFunctionName;

        public NoStartingPointException(string expectedFunctionName)
        {
            this.expectedFunctionName = expectedFunctionName;
        }

        public override string ToString()
        {
            return $"No starting function ({expectedFunctionName}) defined.";
        }
    }
}