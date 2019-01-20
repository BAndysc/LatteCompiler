using System.Collections.Generic;
using System.Linq;
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
            List<IFunctionDefinitionNode> methods = new List<IFunctionDefinitionNode>();

            foreach (var fieldOrMethod in context.fieldOrMethodDef())
            {
                var field = fieldOrMethod.fieldDef();
                var method = fieldOrMethod.methodDef();
                
                if (field != null)
                    fields.Add(new ClassFieldNode(new FilePlace(field), field.ID().GetText(), new LatteTypeGenerator().Visit(field.type_())));
                else
                {
                    var statement = new BlockGenerator().Visit(method.block());
                    
                    var arguments = new List<FunctionArgument>();

                    if (method.arg() != null)
                    {
                        var argsTypes = method.arg().type_().Select(t => new LatteTypeGenerator().Visit(t));
                        var argsNames = method.arg().ID().Select(t => t.GetText());
                        arguments = argsTypes.Zip(argsNames, (type_, name_) => new FunctionArgument(type_, name_)).ToList();                
                    }
                    
                    methods.Add(new FunctionDefinitionNode(new FilePlace(method), new LatteTypeGenerator().Visit(method.type_()), method.ID().GetText(), statement, arguments.ToArray()));
                }
            }
            
            return  new ClassDefinitionNode(new FilePlace(context), context.ID().GetText(), methods, fields.ToArray());
        }

        public override IClassDefinitionNode VisitFunctionDef(LatteParser.FunctionDefContext context)
        {
            return null;
        }
    }
}