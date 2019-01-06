using LatteBase.AST;
using LatteBase.Visitors;
using LatteTreeOptimizer;

namespace LatteTypeChecker
{
    public class StaticAnalysisChecker : ProgramVisitor<bool>
    {
        private readonly TypeChecker typeChecker;
        private readonly ReturnPresenceChecker returnChecker;
        private readonly TreeOptimizer treeOptimizer;
        
        public StaticAnalysisChecker()
        {
            typeChecker = new TypeChecker();
            returnChecker = new ReturnPresenceChecker();
            treeOptimizer = new TreeOptimizer();
        }

        public override bool Visit(IProgram program)
        {
            typeChecker.Visit(program);
            var optimized = treeOptimizer.Visit(program);

            return returnChecker.Visit(optimized);
        }
    }
}