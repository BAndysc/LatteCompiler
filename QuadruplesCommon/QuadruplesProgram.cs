using System.Collections.Generic;
using System.Reflection.Emit;

namespace QuadruplesCommon
{
    public class QuadruplesProgram
    {
        public readonly List<QuadrupleBase> Program = new List<QuadrupleBase>();
        
        public readonly Dictionary<Label, string> ConstStrings = new Dictionary<Label, string>();
        
        private int nextReg = 0;
        private int nextLabel = 0;
        
        public void Emit(QuadrupleBase quadruple)
        {
            Program.Add(quadruple);
        }

        public IRegister GetNextRegister()
        {
            return new Register(nextReg++);
        }

        public Label GetNextLabel()
        {
            return new Label(nextLabel++);
        }

        public Label AllocString(string nodeText)
        {
            var lab = GetNextLabel();
            ConstStrings.Add(lab, nodeText);
            return lab;
        }
    }
}