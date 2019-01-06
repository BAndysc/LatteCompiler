using System.Collections.Generic;
using System.Reflection.Emit;
using QuadruplesCommon.Quadruples;

namespace QuadruplesCommon
{
    public class QuadruplesProgram
    {
        public readonly List<QuadrupleFunction> Functions = new List<QuadrupleFunction>();
        
        public readonly Dictionary<Label, string> ConstStrings = new Dictionary<Label, string>();

        private QuadrupleFunction currentFunction;
        
        private int nextReg = 0;
        private int nextLabel = 0;

        public void EmitFunction(string functionName, int locals)
        {
            currentFunction = new QuadrupleFunction(functionName, locals);
            Functions.Add(currentFunction);
        }
        
        public void Emit(QuadrupleBase quadruple)
        {
//            if (quadruple is LabelQuadruple && (Program.Count > 0 &&
//                                                !(Program[Program.Count - 1] is JumpQuadruple ||
//                                                  Program[Program.Count - 1] is JumpAlwaysQuadruple)))
//            {
//                Program.Add(new JumpAlwaysQuadruple(quadruple.FilePlace, ((LabelQuadruple) quadruple).Label));
//            }
            currentFunction.Instructions.Add(quadruple);
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

    public class QuadrupleFunction
    {
        public readonly string FunctionName;
        public readonly int Locals;

        public readonly List<QuadrupleBase> Instructions;
        
        public QuadrupleFunction(string functionName, int locals)
        {
            FunctionName = functionName;
            Locals = locals;
            Instructions = new List<QuadrupleBase>();
        }
    }
}