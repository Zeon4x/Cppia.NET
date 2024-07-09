using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public class CallStaticInstruction : BaseCallInstruction
{
    public string Class { get; }
    public string Field { get; }

    public CallStaticInstruction(CppiaFile file, CppiaReader reader)
    {
        Class = file.Types[reader.ReadInt()];
        Field = file.Strings[reader.ReadInt()];
        ReadArguments(file, reader);
    }

    public override object? Emit(ILProcessor processor, Context context) 
    {
        if(context.ResolveMethod(Class, Field) is not MethodReference reference)
            throw new Exception($"Cannot resolve method {Class}.{Field}");
        if(reference.Parameters.Count != Arguments.Count)
            throw new Exception($"Parameters count mistmatch");

        EmitArguments(reference, processor, context);
        processor.Emit(OpCodes.Call, reference);
        return reference.ReturnType;
    }
}