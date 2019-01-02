using LatteBase.AST;

namespace QuadruplesCommon.Quadruples
{
    public class LoadLabelPtrQuadruple : QuadrupleBase
    {
        public readonly IRegister ResultRegister;
        public readonly Label LabelToLoad;
        
        public LoadLabelPtrQuadruple(IFilePlace filePlace, Label labelToLoad, IRegister resultRegister) : base(filePlace)
        {
            LabelToLoad = labelToLoad;
            ResultRegister = resultRegister;
        }

        public override string ToString()
        {
            return $"{ResultRegister} = getelementptr {LabelToLoad}";
        }
    }
}