using LatteBase.AST;

namespace QuadruplesCommon
{
    public class QuadrupleBase
    {
        public readonly IFilePlace FilePlace;

        public QuadrupleBase(IFilePlace filePlace)
        {
            FilePlace = filePlace;
        }
    }
}