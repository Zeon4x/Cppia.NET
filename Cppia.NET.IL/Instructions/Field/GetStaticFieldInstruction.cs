using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class GetStaticFieldInstruction : BaseFieldInstruction
{
    public GetStaticFieldInstruction(CppiaFile file, CppiaReader reader)
        : base(file, reader, false) { }

    public override object? Emit(ILProcessor processor, Context context)
    {
        if(context.ResolveType(Class) is not TypeReference reference)
            throw new Exception($"Class not found {Class}");

        TypeDefinition typeDefinition = context.ResolveTypeDeifinition(reference);

        if(typeDefinition.Methods
            .SingleOrDefault(m => m.Name.Equals("get_"+Field)) is MethodDefinition method)
        {
            var methodReference = context.Module.ImportReference(method);
            processor.Emit(OpCodes.Call, methodReference);
            return method.ReturnType;
        }
        else if(typeDefinition.Fields
            .SingleOrDefault(f => f.Name == Field) is FieldDefinition field)
        {
            FieldReference fieldReference = context.Module.ImportReference(field);
            processor.Emit(OpCodes.Ldfld, fieldReference);
            return field.FieldType;
        }
        return null;
    }
}