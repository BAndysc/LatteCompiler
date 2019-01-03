using System;

namespace Utils
{
    public class TempFileCreator : ITempFileCreator
    {
        public string GetTempFile()
        {
            return System.IO.Path.GetTempPath() + Guid.NewGuid(); 
        }
    }
}