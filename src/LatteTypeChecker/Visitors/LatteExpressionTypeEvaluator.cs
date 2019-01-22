using System;
using System.Collections;
using System.Linq;
using Common;
using LatteBase;
using LatteBase.AST;
using LatteBase.Visitors;
using LatteTypeChecker.Exceptions;
using LatteTypeChecker.Models;

namespace LatteTypeChecker.Visitors
{
    public class LatteExpressionTypeEvaluator : ExpressionVisitor<ILatteType>
    {
        private readonly IVariableEnvironment variables;
        private readonly IEnvironment functions;

        public LatteExpressionTypeEvaluator(IVariableEnvironment variables, IEnvironment functions)
        {
            this.variables = variables;
            this.functions = functions;
        }

        public override ILatteType Visit(IIntNode node)
        {
            return LatteType.Int;
        }

        public override ILatteType Visit(ITrueNode node)
        {
            return LatteType.Bool;
        }

        public override ILatteType Visit(IFalseNode node)
        {
            return LatteType.Bool;
        }

        public override ILatteType Visit(IStringNode node)
        {
            return LatteType.String;
        }

        public override ILatteType Visit(IVariableNode node)
        {
            if (!variables.IsDefined(node.Variable))
                throw new UndeclaredVariableAnyTypeException(node.Variable, node.FilePlace);
            
            return variables[node.Variable].Type;
        }

        public override ILatteType Visit(INegateNode node)
        {
            var exprType = Visit(node.Expression);
            
            if (exprType != LatteType.Int)
                throw new InvalidOperatorUsageException(exprType, node.FilePlace, LatteType.Bool, LatteType.Int);
            
            return exprType;
        }

        public override ILatteType Visit(ILogicalNegateNode node)
        {
            var exprType = Visit(node.Expression);
            
            if (exprType != LatteType.Bool)
                throw new InvalidOperatorUsageException(exprType, node.FilePlace, LatteType.Bool, LatteType.Int);
            
            return exprType;
        }
        
        public override ILatteType Visit(IAndNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (left != LatteType.Bool)
                throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Bool);

            if (right != LatteType.Bool)
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Bool);
            
            return LatteType.Bool;
        }

        public override ILatteType Visit(IOrNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (left != LatteType.Bool)
                throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Bool);

            if (right != LatteType.Bool)
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Bool);
            
            return LatteType.Bool;
        }

        public override ILatteType Visit(IBinaryNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            
            if (left != LatteType.Int && (left != LatteType.String || node.Operator != BinaryOperator.Add))
                throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Int, LatteType.String);

            if (right != LatteType.Int && (right != LatteType.String || node.Operator != BinaryOperator.Add))
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Int, LatteType.String);
            
            if (!functions.IsTypeAssignable(left, right))
                throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Int, LatteType.String);

            if (left == LatteType.String)
                node.Operator = BinaryOperator.Concat;
            
            return left;
        }

        public override ILatteType Visit(ICompareNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (node.Operator == RelOperator.Equals || node.Operator == RelOperator.NotEquals)
            {
                if (!IsDefinedEquality(left))
                    throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Int, LatteType.Bool);

                if (!IsDefinedEquality(right))
                    throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Int, LatteType.Bool);
            }
            else
            {
                if (!IsDefinedComparison(left))
                    throw new InvalidOperatorUsageException(left, node.FilePlace, LatteType.Int);

                if (!IsDefinedComparison(right))
                    throw new InvalidOperatorUsageException(right, node.FilePlace, LatteType.Int);    
            }
            
            if (!functions.IsTypeAssignable(left, right) && !functions.IsTypeAssignable(right, left))
                throw new InvalidOperatorUsageException(right, node.FilePlace, left);
                        
            return LatteType.Bool;
        }

        public override ILatteType Visit(IStringCompareNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);

            if (!functions.IsTypeAssignable(left, LatteType.String))
                throw new InplaceTypeCheckerException(node.FilePlace, "Expected String, instead given: " + left);
            
            if (!functions.IsTypeAssignable(right, LatteType.String))
                throw new InplaceTypeCheckerException(node.FilePlace, "Expected String, instead given: " + right);
            
            return LatteType.Bool;
        }

        private bool IsDefinedEquality(ILatteType type)
        {
            return type != LatteType.Void;
        }

        private bool IsDefinedComparison(ILatteType type)
        {
            return type == LatteType.Int;
        }
        
        public override ILatteType Visit(IFunctionCallNode node)
        { 
            if (!functions.IsFunctionDefined(node.FunctionName))
                throw new UndeclaredFunctionException(node.FunctionName, node.FilePlace);
            
            var function = functions[node.FunctionName];

            if (function.ArgumentTypes.Count != node.Arguments.Count)
                throw new ArgumentsCountMismatchException(function, node.Arguments.Count, node.FilePlace);

            for (int i = 0; i < function.ArgumentTypes.Count; ++i)
            {
                var givenArgumentType = Visit(node.Arguments[i]);
                var expectedArgumentType = function.ArgumentTypes[i];

                if (!functions.IsTypeAssignable(givenArgumentType, expectedArgumentType))
                    throw new FunctionCallTypeMismatch(function, i, givenArgumentType, node.FilePlace);
            }
            
            return function.ReturnType;
        }

        public override ILatteType Visit(INullNode node)
        {
            return LatteType.Null;
        }

        public override ILatteType Visit(INewObjectNode node)
        {
            return node.Type;
        }

        public override ILatteType Visit(ICastExpressionNode node)
        {
            var exprType = Visit(node.Expression);
            if (!node.ForceCast && exprType != LatteType.Null && !functions.IsTypeAssignable(exprType, node.CastType))
            {
                throw new BadCastException(node.FilePlace, exprType, node.CastType);
            }
            return node.CastType;
        }

        public override ILatteType Visit(IObjectFieldNode node)
        {
            var classType = Visit(node.Object);

            if (classType.IsArray)
            {
                if (node.FieldName != "length")
                    throw new InplaceTypeCheckerException(node.FilePlace, $"Array has only property ::length, given: {node.FieldName}");
                
                return LatteType.Int;
            }
            else
            {
                var classDef = functions.GetClass(classType.Name);

                if (!classDef.HasField(node.FieldName))
                    throw new UnknownFieldInClassException(node.FilePlace, classDef, node.FieldName);

                var fieldType = classDef.GetField(node.FieldName).FieldType;

                return fieldType;       
            }
        }

        public override ILatteType Visit(IObjectFieldWithOffsetNode node)
        {
            throw new Exception("Unexpected node in type checker");
        }

        public override ILatteType Visit(IMethodCallNode node)
        {
            var classType = Visit(node.Object);

            var classDef = functions.GetClass(classType.Name);

            if (!classDef.HasMethod(node.MethodName))
                throw new UndeclaredFunctionException($"{classDef.Name}::{node.MethodName}", node.FilePlace);

            var method = classDef.GetMethod(node.MethodName);
            
            if (method.ArgumentTypes.Count != node.Arguments.Count)
                throw new ArgumentsCountMismatchException(method, node.Arguments.Count, node.FilePlace);

            for (int i = 0; i < method.ArgumentTypes.Count; ++i)
            {
                var givenArgumentType = Visit(node.Arguments[i]);
                var expectedArgumentType = method.ArgumentTypes[i];

                if (!functions.IsTypeAssignable(givenArgumentType, expectedArgumentType))
                    throw new FunctionCallTypeMismatch(method, i, givenArgumentType, node.FilePlace);
            }

            return method.ReturnType;
        }
        
        public override ILatteType Visit(IMethodCallWithOffsetNode node)
        {
            throw  new Exception("At this point, this node is not expected, use IMethodCallNode instead");
        }

        public override ILatteType Visit(IArrayAccessNode node)
        {
            var arrayType = Visit(node.Array);
            
            if (!arrayType.IsArray)
                throw new InplaceTypeCheckerException(node.FilePlace, "Type is not an array");

            var index = Visit(node.Index);

            if (index != LatteType.Int)
                throw new InplaceTypeCheckerException(node.FilePlace, "Array index is not an int!");

            return arrayType.BaseType;
        }

        public override ILatteType Visit(INewArrayNode node)
        {
            var sizeType = Visit(node.Size);
            
            if (sizeType != LatteType.Int)
                throw new InplaceTypeCheckerException(node.FilePlace, "Array size is not an int!");

            return new LatteType(node.ArrayType);
        }
    }
}