using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace Cppia.NET.Instructions;

public class CallInstruction : BaseCallInstruction
{
    public CppiaInstruction Function { get; }

    public CallInstruction(CppiaFile file, CppiaReader reader)
    {
        int argsCount = reader.ReadByte();
        Function = ReadInstruction(file,reader);
        ReadArguments(file, reader, argsCount);
    }

    public override object? Emit(ILProcessor processor, Context context)
    {
        object? value = Function.Emit(processor, context);
        MethodDefinition method;
        if(value is MethodDefinition methodDefinition)
            method = methodDefinition;
        else if(value is TypeReference reference)
        {
            var type = context.ResolveTypeDeifinition(reference);
            method = type.Methods.SingleOrDefault(m => m.Name == "Invoke");
            if(reference is GenericInstanceType genericType)
                ((MethodReference)method).DeclaringType = genericType;
        }
        else
            throw new Exception();
        EmitArguments(method, processor, context);
        processor.Emit(OpCodes.Callvirt, context.Module.ImportReference(method));
        return method.ReturnType;
    }
    
}