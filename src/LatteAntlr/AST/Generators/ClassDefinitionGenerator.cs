using System.Collections.Generic;
using LatteAntlr.Visitors;
using LatteBase.AST;
using LatteBase.AST.Impl;

namespace LatteAntlr.AST.Generators
{
    internal class ClassDefinitionGenerator : LatteBaseClassDefVisitor<IClassDefinitionNode>
    {
        public override IClassDefinitionNode VisitClassDef(LatteParser.ClassDefContext context)
        {
            List<IClassFieldNode> fields = new List<IClassFieldNode>();

            foreach (var field in context.fieldDef())
            {
                fields.Add(new ClassFieldNode(new FilePlace(field), field.ID().GetText(), new LatteTypeGenerator().Visit(field.type_())));
            }
            
            return  new ClassDefinitionNode(new FilePlace(context), context.ID().GetText(), fields.ToArray());
        }

        public override IClassDefinitionNode VisitFunctionDef(LatteParser.FunctionDefContext context)
        {
            return null;
        }
    }
}