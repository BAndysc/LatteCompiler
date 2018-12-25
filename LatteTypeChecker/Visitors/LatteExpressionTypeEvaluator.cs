using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using LatteTypeChecker.Exceptions;

namespace LatteTypeChecker.Visitors
{
    public class LatteExpressionTypeEvaluator : ExpressionVisitor<LatteType>
    {
        private readonly IVariableEnvironement variables;
        private readonly IEnvironment functions;

        public LatteExpressionTypeEvaluator(IVariableEnvironement variables, IEnvironment functions)
        {
            this.variables = variables;
            this.functions = functions;
        }

        public override LatteType Visit(IIntNode node)
        {
            return LatteType.Int;
        }

        public override LatteType Visit(ITrueNode node)
        {
            return LatteType.Bool;
        }

        public override LatteType Visit(IFalseNode node)
        {
            return LatteType.Bool;
        }

        public override LatteType Visit(IStringNode node)
        {
            return LatteType.String;
        }

        public override LatteType Visit(IVariableNode node)
        {
            return variables[node.Variable].Type;
        }

        public override LatteType Visit(INegateNode node)
        {
            var exprType = Visit(node.Expression);
            
            if (exprType != LatteType.Bool && exprType != LatteType.Int)
                throw new InvalidOperatorUsageException(exprType, node.FilePlace, LatteType.Bool, LatteType.Int);

            return exprType;
        }

        public override LatteType Visit(IAndNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (left != LatteType.Bool)
                throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Bool);

            if (right != LatteType.Bool)
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Bool);
            
            return LatteType.Bool;
        }

        public override LatteType Visit(IOrNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (left != LatteType.Bool)
                throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Bool);

            if (right != LatteType.Bool)
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Bool);
            
            return LatteType.Bool;
        }

        public override LatteType Visit(IBinaryNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (left != LatteType.Int)
                throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Int);

            if (right != LatteType.Int)
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Int);
            
            return LatteType.Int;
        }

        public override LatteType Visit(ICompareNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (left != LatteType.Int)
                throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Int);

            if (right != LatteType.Int)
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Int);
            
            return LatteType.Bool;
        }

        public override LatteType Visit(IFunctionCallNode node)
        { 
            if (!functions.IsDefined(node.FunctionName))
                throw new UndeclaredFunctionException(node.FunctionName, node.FilePlace);
            
            var function = functions[node.FunctionName];

            return function.ReturnType;
        }
    }
}