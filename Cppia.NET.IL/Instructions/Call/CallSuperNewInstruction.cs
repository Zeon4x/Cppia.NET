



using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace Cppia.NET.Instructions;

public class CallSuperNewInstruction : BaseCallInstruction
{
    public string ClassName { get; }

    public CallSuperNewInstruction(CppiaFile file, CppiaReader reader)
    {
        ClassName = file.Types[reader.ReadInt()];
        int argsCount = reader.ReadInt();
        ReadArguments(file, reader, argsCount);
    }

    public override object? Emit(Mono.Cecil.Cil.ILProcessor processor, Context context)
    {
        if(context.ResolveTypeDeifinition(ClassName) is not TypeDefinition type)
            throw new Exception($"Class not found {ClassName}");
        processor.Emit(OpCodes.Ldarg_0);
        var baseType = context.ResolveTypeDeifinition(type.BaseType);
        var baseConstructor = baseType.GetConstructors().First();
        EmitArguments(baseConstructor, processor, context);
        processor.Emit(OpCodes.Call, baseConstructor);
        return baseConstructor.ReturnType;
    }

    
}