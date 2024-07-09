



using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Cppia.NET.Instructions;

public abstract class BaseCallInstruction : CppiaInstruction
{
    public List<CppiaInstruction> Arguments { get; } = new();

    protected void ReadArguments(CppiaFile file, CppiaReader reader, int count = -1)
    {
        if(count == -1)
            count = reader.ReadInt();
        ReadInstructions(Arguments, file, reader, count);
    }

    public void EmitArguments(MethodReference reference, ILProcessor processor, Context context)
    {
        for (int i = 0; i < Arguments.Count; i++)
        {
            CppiaInstruction? arg = Arguments[i];
            var returnValue = arg.Emit(processor, context);

            if (returnValue is TypeReference type)
            {
                if (reference.Parameters[i].ParameterType.IsValueType && type.IsValueType)
                {
                    processor.Emit(OpCodes.Unbox, type);
                }
                else if (!reference.Parameters[i].ParameterType.IsValueType && type.IsValueType)
                {
                    processor.Emit(OpCodes.Box, type);
                }
            }
        }
    }
}